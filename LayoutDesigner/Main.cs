using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

using Core;
using Core.Helpers;
using Core.Storage;
using Core.UI;
using Core.UI.Dialogs;



namespace LayoutDesigner {
  public partial class Main : Form {
    // Constants
    private const string TitleBase = "Návrhář rozvržení";
    private const string SelectBelow = "Vyberte níže...";



    // Data
    private Layout CurrentLayout;

    private bool IsLayoutPresent {
      get => this.CurrentLayout != null;
    }

    private object CurrentSelection;

    private List<string> ValidLayoutNames {
      get => LayoutManager.GetExistingLayoutNames().ToList();
    }

    private int HeightOffset;



    // Constructor
    public Main() {
      InitializeComponent();
    }



    // File
    private void Unload(bool force) {
      if (!this.IsLayoutPresent) {
        return;
      }

      // If not saved ask user if he wants to save
      // If forced then do not ask
      if (!force && !this.CurrentLayout.IsCorrespondingFileUpToDate()) {
        var dialogResult = MessageBoxes.SaveUnsavedLayout();

        if (dialogResult == DialogResult.Cancel) {
          return;
        }

        if (dialogResult == DialogResult.Yes) {
          this.Save();
        }
      }

      // Unload
      this.CurrentLayout = null;
      this.CurrentSelection = null;

      // Post-hooks
      this.UpdateState();
    }

    private void Unload() {
      this.Unload(false);
    }

    private void New() {
      // Ask for new name
      NewObject newLayout = this.CreateNewLayout();

      if (newLayout.DialogResult == DialogResult.OK) {
        // Pre-hooks
        this.Unload();

        // Post-hooks
        this.SetCurrentLayout((Layout) newLayout.FinalValue);
      }
    }

    private void Open() {
      UserSelect selectLayoutName = GetSelect(LayoutManager.GetValidLayoutNames(), "Vyberte rozvržení");

      if (selectLayoutName.DialogResult == DialogResult.OK) {
        string layoutName = (string) selectLayoutName.FinalValue;

        Layout layout = Core.Storage.Layout.Import(layoutName);

        this.SetCurrentLayout(layout);
      }
    }

    private void Save() {
      if (this.IsLayoutPresent) {
        // Save if not saved
        if (!this.CurrentLayout.IsCorrespondingFileUpToDate()) {
          this.CurrentLayout.Export();

          // Post-hooks
          this.UpdateState();
        }
      }
    }

    private void SaveAs() {
      // Save if layout present
      if (this.IsLayoutPresent) {
        var userTextInput = this.GetNewName();

        if (userTextInput.DialogResult == DialogResult.OK) {
          this.CurrentLayout.ExportAs(userTextInput.FinalValue);

          // Post-hooks
          this.UpdateState();
        }
      }
    }

    private void Rename() {
      // Rename if layout present
      if (this.IsLayoutPresent) {
        var userTextInput = this.GetNewName();

        if (userTextInput.DialogResult == DialogResult.OK) {
          this.CurrentLayout.Rename(userTextInput.FinalValue);

          // Post-hooks
          this.UpdateState();
        }
      }
    }

    private void Delete() {
      // Delete if layout opened
      if (this.IsLayoutPresent) {
        // Ask if user is sure
        var dialogResult = MessageBoxes.UndoableDeletion(this.CurrentLayout.Name);

        if (dialogResult == DialogResult.Yes) {
          this.CurrentLayout.Delete();

          // Post-hooks
          this.Unload(true);
          this.UpdateState();
        }
      }
    }



    // Layout
    private void NewZone() {
      if (this.IsLayoutPresent) {
        int totalLayoutArea = this.CurrentLayout.Size.Width * this.CurrentLayout.Size.Height; // Implement
        int totalZonesArea = this.CurrentLayout.Zones.Aggregate(0, (sum, zone) => sum + zone.Size.Width * zone.Size.Height); // Implement

        bool layoutHasAvailableArea = totalLayoutArea > totalZonesArea;

        if (!layoutHasAvailableArea) {
          MessageBoxes.AreaFull();
        } else {
          NewObject newZone = CreateNewZone();

          if (newZone.DialogResult == DialogResult.OK) {
            this.CurrentLayout.Zones.Add((Zone) newZone.FinalValue);

            // Post-hooks
            this.UpdateState();
          }
        }
      }
    }

    private void NewCarBrand() {
      if (this.IsLayoutPresent && this.CurrentLayout.Zones.Count > 0) {
        IEnumerable<Zone> zones = this.CurrentLayout.Zones.Where(zone => zone.Type == ZoneType.Storage);

        // Implement line 161, 162

        if (zones.Count() == 0) {
          MessageBoxes.NoAvailableZone();
        } else {
          UserSelect zoneSelect = GetSelect(zones, "Name", "Vyberte zónu");

          if (zoneSelect.DialogResult == DialogResult.OK) {
            Zone zone = (Zone) zoneSelect.FinalValue;

            // Calculate areas for Zone and its CarBrands
            int zoneArea = zone.Size.Width * zone.Size.Height;
            int zoneCarBrandsArea = zone.CarBrands.Aggregate(0, (sum, carBrand) => sum + carBrand.Size.Width * carBrand.Size.Height);

            bool hasSuitableArea = zoneCarBrandsArea < zoneArea;

            if (!hasSuitableArea) {
              MessageBoxes.AreaFull();
            } else {
              NewObject newCarBrand = CreateNewCarBrand(zone);

              if (newCarBrand.DialogResult == DialogResult.OK) {
                zone.CarBrands.Add((CarBrand) newCarBrand.FinalValue);

                // Post-hooks
                this.UpdateState();
              }
            }
          }
        }
      }
    }

    private void RemoveZone() {
      if (this.IsLayoutPresent && this.CurrentLayout.Zones.Count > 0) {
        UserSelect zoneSelect = GetSelect(this.CurrentLayout.Zones, "Name", "Vyberte zónu");

        if (zoneSelect.DialogResult == DialogResult.OK) {
          Zone zone = (Zone) zoneSelect.FinalValue;

          this.CurrentLayout.Zones.Remove(zone);

          // Post-hooks
          this.UpdateState();
        }
      }
    }

    private void RemoveCarBrand() {
      if (this.IsLayoutPresent && this.CurrentLayout.Zones.Count > 0
        && this.CurrentLayout.Zones.SelectMany(zone => zone.CarBrands).Count() > 0) {
        UserSelect zoneSelect = GetSelect(this.CurrentLayout.Zones.Where(zone => zone.CarBrands.Count() > 0), "Name", "Vyberte zónu");

        if (zoneSelect.DialogResult == DialogResult.OK) {
          Zone zone = (Zone) zoneSelect.FinalValue;

          UserSelect carBrandSelect = GetSelect(zone.CarBrands, "Name", "Vyberte značku auta");

          if (carBrandSelect.DialogResult == DialogResult.OK) {
            CarBrand carBrand = (CarBrand) carBrandSelect.FinalValue;

            zone.CarBrands.Remove(carBrand);

            // Post-hooks
            this.UpdateState();
          }
        }
      }
    }



    // User interaction
    private UserSelect GetSelect(IEnumerable<object> selectItems, string displayMember, string label) {
      UserSelect userSelect = new(selectItems.ToList(), displayMember, label);

      userSelect.ShowDialog(this);

      return userSelect;
    }

    private UserSelect GetSelect(IEnumerable<object> selectItems, string label) {
      return this.GetSelect(selectItems, "", label);
    }

    private UserTextInput GetNewName() {
      Func<string, bool> valueValidator = newName => {
        newName = newName.Trim();
        char[] invalidFileNameChars = Path.GetInvalidFileNameChars();

        bool isEmpty = newName.Length == 0;
        bool newNameContainsInvalidChars = newName.ToCharArray().Any(newNameChar => invalidFileNameChars.Contains(newNameChar));
        bool nameAlreadyTaken = LayoutManager.IsNameAlreadyTaken(newName);

        if (isEmpty) {
          MessageBoxes.ValueCannotBeEmpty();
          return false;
        } else if (newNameContainsInvalidChars) {
          MessageBoxes.TextFieldCannotContainInvalidChars();
          return false;
        } else if (nameAlreadyTaken) {
          MessageBoxes.NameAlreadyInUse();
          return false;
        } else {
          return true;
        }
      };

      UserTextInput userTextInput = new(valueValidator, "Nový název rozvržení");

      userTextInput.ShowDialog(this);

      return userTextInput;
    }

    private NewObject CreateNewLayout() {
      Func<object, bool> validator = obj => {
        Layout layout = (Layout) obj;

        bool isNameEmpty = layout.Name.Trim().Length == 0;
        bool isNameAlreadyInUse = LayoutManager.GetExistingLayoutNames().Contains(layout.Name);

        if (isNameEmpty) {
          MessageBoxes.ValueCannotBeEmpty();
          return false;
        } else if (isNameAlreadyInUse) {
          MessageBoxes.NameAlreadyInUse();
          return false;
        } else {
          return true;
        }
      };

      Layout initialLayout = new("Nové rozvržení", "", new(10, 10), 4);

      NewObject newLayout = new(validator, initialLayout, "Nová zóna");

      newLayout.ShowDialog(this);

      return newLayout;
    }

    private NewObject CreateNewZone() {
      Func<object, bool> validator = obj => {
        Zone zone = (Zone) obj;



        bool isNameEmpty = zone.Name.Trim().Length == 0;

        bool isNameAlreadyInUse = this.CurrentLayout.Zones.Select(zone => zone.Name).Contains(zone.Name);

        bool isBeyond = zone.Location.X < this.CurrentLayout.Location.X
                     || zone.Location.Y < this.CurrentLayout.Location.Y
                     || zone.Location.X + zone.Size.Width > this.CurrentLayout.Size.Width
                     || zone.Location.Y + zone.Size.Height > this.CurrentLayout.Size.Height;

        bool doesIntersectWithOtherZone = this.CurrentLayout.Zones.Any(currentZone => zone.Rectangle.IntersectsWith(currentZone.Rectangle));



        if (isNameEmpty) {
          MessageBoxes.ValueCannotBeEmpty();
          return false;
        } else if (isNameAlreadyInUse) {
          MessageBoxes.NameAlreadyInUse();
          return false;
        } else if (isBeyond) {
          MessageBoxes.CantBeBeyond();
          return false;
        } else if (doesIntersectWithOtherZone) {
          MessageBoxes.CantIntersect();
          return false;
        } else {
          return true;
        }
      };

      Zone initialZone = new("Nová zóna", new(0, 0), new(1, 1), ZoneType.Storage);

      NewObject newZone = new(validator, initialZone, "Nová zóna");

      newZone.ShowDialog(this);

      return newZone;
    }

    private NewObject CreateNewCarBrand(Zone parentZone) {
      Func<object, bool> validator = obj => {
        CarBrand carBrand = (CarBrand) obj;

        bool isNameEmpty = carBrand.Name.Trim().Length == 0;

        bool isNameAlreadyInUse = parentZone.CarBrands.Select(currentCarBrand => currentCarBrand.Name).Contains(carBrand.Name);

        bool isBeyond = carBrand.Location.X < parentZone.Location.X
                     || carBrand.Location.Y < parentZone.Location.Y
                     || carBrand.Location.X + carBrand.Size.Width > parentZone.Location.X + parentZone.Size.Width
                     || carBrand.Location.Y + carBrand.Size.Height > parentZone.Location.Y + parentZone.Size.Height;

        bool doesIntersectWithOtherCarBrand = parentZone.CarBrands.Any(currentCarBrand => carBrand.Rectangle.IntersectsWith(currentCarBrand.Rectangle)); // Bug



        if (isNameEmpty) {
          MessageBoxes.ValueCannotBeEmpty();
          return false;
        } else if (isNameAlreadyInUse) {
          MessageBoxes.NameAlreadyInUse();
          return false;
        } else if (isBeyond) {
          MessageBoxes.CantBeBeyond();
          return false;
        } else if (doesIntersectWithOtherCarBrand) {
          MessageBoxes.CantIntersect();
          return false;
        } else {
          return true;
        }
      };


      CarBrand initialCarBrand = new("Nová značka auta", new(0, 0), new(1, 1));

      NewObject newCarBrand = new(validator, initialCarBrand, "Nová značka auta");

      newCarBrand.ShowDialog(this);

      return newCarBrand;
    }



    // Update state
    private void UpdateTitle() {
      if (this.IsLayoutPresent) {
        this.Text = $"{ TitleBase } - { this.CurrentLayout.Name } ({( this.CurrentLayout.IsCorrespondingFileUpToDate() ? "uloženo" : "neuloženo" )})";
      } else {
        this.Text = $"{ TitleBase }";
      }
    }

    private void UpdateOpenControl_Enabled() {
      ToolStripMenuItem_Open.Enabled = this.ValidLayoutNames.Count() > 0;
    }

    private void UpdateCloseControl_Enabled() {
      ToolStripMenuItem_Close.Enabled = this.IsLayoutPresent;
    }

    private void UpdateSaveControl_Enabled() {
      if (this.IsLayoutPresent) {
        this.ToolStripMenuItem_Save.Enabled = !this.CurrentLayout.IsCorrespondingFileUpToDate();
      } else {
        this.ToolStripMenuItem_Save.Enabled = false;
      }
    }

    private void UpdateSaveAsControl_Enabled() {
      this.ToolStripMenuItem_SaveAs.Enabled = this.IsLayoutPresent;
    }

    private void UpdateRenameControl_Enabled() {
      this.ToolStripMenuItem_Rename.Enabled = this.IsLayoutPresent;
    }

    private void UpdateDeleteControl_Enabled() {
      this.ToolStripMenuItem_Delete.Enabled = this.IsLayoutPresent && this.CurrentLayout.HasValidCorrespondingFile();
    }

    private void UpdateNewZoneControl_Enabled() {
      this.ToolStripMenuItem_NewZone.Enabled = this.IsLayoutPresent;
    }

    private void UpdateNewCarBrandControl_Enabled() {
      this.ToolStripMenuItem_NewCarBrand.Enabled = this.IsLayoutPresent && this.CurrentLayout.Zones.Count > 0;
    }

    private void UpdateRemoveZoneControl_Enabled() {
      this.ToolStripMenuItem_RemoveZone.Enabled = this.IsLayoutPresent && this.CurrentLayout.Zones.Count > 0;
    }

    private void UpdateRemoveCarBrandControl_Enabled() {
      this.ToolStripMenuItem_RemoveCarBrand.Enabled = this.IsLayoutPresent
        && this.CurrentLayout.Zones.Count > 0
        && this.CurrentLayout.Zones.SelectMany(zone => zone.CarBrands).Count() > 0;
    }

    private void UpdateState() {
      this.UpdateTitle();
      this.UpdateOpenControl_Enabled();
      this.UpdateCloseControl_Enabled();
      this.UpdateSaveControl_Enabled();
      this.UpdateSaveAsControl_Enabled();
      this.UpdateRenameControl_Enabled();
      this.UpdateDeleteControl_Enabled();
      this.UpdateNewZoneControl_Enabled();
      this.UpdateNewCarBrandControl_Enabled();
      this.UpdateRemoveZoneControl_Enabled();
      this.UpdateRemoveCarBrandControl_Enabled();

      // Post-hooks
      this.CurrentLayoutChangedHandler();
      this.CurrentSelectionChangedHandler();
    }



    // Set state
    private void SetCurrentLayout(Layout layout) {
      this.CurrentLayout = layout;

      if (this.IsLayoutPresent) {
        this.CurrentLayout.Initialize(false);
      }

      // Post-hooks
      this.UpdateState();
    }

    private void SetCurrentSelection(string path) {
      string[] pathPieces = path.Split(this.TreeView_Layout.PathSeparator.ToCharArray());
      int level = pathPieces.Length - 1;
      object currentSelection = null;

      // Find currentSelection which can be Layout, Zone or CarBrand
      if (level >= 0 && level <= 2) {
        if (level == 0) {
          if (pathPieces[level] == this.CurrentLayout.Name) {
            currentSelection = this.CurrentLayout;
          }
        } else {
          foreach (Zone zone in this.CurrentLayout.Zones) {
            if (level == 1) {
              if (pathPieces[level] == zone.Name) {
                currentSelection = zone;

                break;
              }
            } else {
              if (pathPieces[1] == zone.Name) {
                foreach (CarBrand carBrand in zone.CarBrands) {
                  if (pathPieces[level] == carBrand.Name) {
                    currentSelection = carBrand;

                    break;
                  }
                }

                break;
              }
            }
          }
        }
      }

      this.CurrentSelection = currentSelection;

      // Post-hooks
      this.CurrentSelectionChangedHandler();
    }



    // Handle state
    private void CurrentLayoutChangedHandler() {
      // TreeView
      this.TreeView_Layout.Nodes.Clear();

      if (this.IsLayoutPresent) {
        // Main
        int Main_MinimumWidth = this.CurrentLayout.Size.Width * StaticSettings.UnitSize + this.TreeView_Layout.Width + SystemInformation.VerticalScrollBarWidth;
        int Main_MinimumHeight = this.CurrentLayout.Size.Height * StaticSettings.UnitSize + this.HeightOffset;

        this.MinimumSize = new Size(Main_MinimumWidth, Main_MinimumHeight);

        // TreeView
        var rootNode = TreeView_Layout.Nodes.Add(this.CurrentLayout.Name);

        foreach (Zone zone in this.CurrentLayout.Zones) {
          var zoneNode = rootNode.Nodes.Add(zone.Name);

          foreach (CarBrand carBrand in zone.CarBrands) {
            zoneNode.Nodes.Add(carBrand.Name);
          }
        }

        this.TreeView_Layout.ExpandAll();

        // Draw
        this.DrawLayout();
      } else {
        // Set current form minimum size
        this.MinimumSize = new Size(
          TreeView_Layout.Width + SystemInformation.VerticalScrollBarWidth,
          this.PropertyGrid_CurrentSelection.Height * 2
        );

        // Clear last drawing
        this.PictureBox_Layout.CreateGraphics().Clear(this.PictureBox_Layout.BackColor);
      }
    }

    private void CurrentSelectionChangedHandler() {
      this.PropertyGrid_CurrentSelection.SelectedObject = this.CurrentSelection;
    }



    // Visual
    private void DrawLayout() {
      if (this.IsLayoutPresent) {
        Drawer.DrawLayout(this.PictureBox_Layout, this.CurrentLayout, new(SystemInformation.VerticalScrollBarWidth, 0));
      }
    }



    // File
    private void ToolStripMenuItem_New_Click(object sender, EventArgs e) {
      this.New();
    }


    private void ToolStripMenuItem_Open_Click(object sender, EventArgs e) {
      this.Open();
    }

    private void ToolStripComboBox_ImportableLayoutNames_ComboBox_SelectionChangeCommitted(object sender, EventArgs e) {
    }

    private void ToolStripMenuItem_Close_Click(object sender, EventArgs e) {
      this.Unload();
    }

    private void ToolStripMenuItem_Save_Click(object sender, EventArgs e) {
      this.Save();
    }

    private void ToolStripMenuItem_SaveAs_Click(object sender, EventArgs e) {
      this.SaveAs();
    }

    private void ToolStripMenuItem_Rename_Click(object sender, EventArgs e) {
      this.Rename();
    }

    private void ToolStripMenuItem_Delete_Click(object sender, EventArgs e) {
      this.Delete();
    }

    private void ToolStripMenuItem_OpenInFileExplorer_Click(object sender, EventArgs e) {
      if (Directory.Exists(StaticSettings.LayoutsPath)) {
        Process.Start("explorer.exe", StaticSettings.LayoutsPath);
      } else {
        MessageBoxes.NoLayoutsExist();
      }
    }

    private void ToolStripMenuItem_Exit_Click(object sender, EventArgs e) {
      this.Close();
    }



    // Layout
    private void ToolStripMenuItem_NewZone_Click(object sender, EventArgs e) {
      this.NewZone();
    }

    private void ToolStripMenuItem_NewCarBrand_Click(object sender, EventArgs e) {
      this.NewCarBrand();
    }

    private void ToolStripMenuItem_RemoveZone_Click(object sender, EventArgs e) {
      this.RemoveZone();
    }

    private void ToolStripMenuItem_RemoveCarBrand_Click(object sender, EventArgs e) {
      this.RemoveCarBrand();
    }



    // Main events
    private void Main_Load(object sender, EventArgs e) {
      this.HeightOffset = this.Height - this.TreeView_Layout.Height;

      // Post-hooks
      this.SetCurrentLayout(null);
      this.UpdateState();
    }

    private void Main_Resize(object sender, EventArgs e) {
      this.TreeView_Layout.Height = this.Height - HeightOffset;

      this.PropertyGrid_CurrentSelection.Location = new(0, this.TreeView_Layout.Location.Y + this.TreeView_Layout.Height);

      this.PictureBox_Layout.Width = this.Width - this.TreeView_Layout.Width;
      //this.PictureBox_Layout.Height = this.Height - this.HeightOffset;
      this.PictureBox_Layout.Height = this.TreeView_Layout.Height + this.PropertyGrid_CurrentSelection.Height;

      this.DrawLayout();
    }

    private void Main_FormClosing(object sender, FormClosingEventArgs e) {
      this.Unload();
    }

    private void Main_Paint(object sender, PaintEventArgs e) {
      this.DrawLayout();
    }



    // Other
    private void TreeView_Layout_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e) {
      this.SetCurrentSelection(e.Node.FullPath);
    }

    private void PropertyGrid_CurrentSelection_PropertyValueChanged(object s, PropertyValueChangedEventArgs e) {
      this.UpdateState();
    }
  }
}
