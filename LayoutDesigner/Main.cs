﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

using Core;
using Core.Extensions;
using Core.Helpers;
using Core.Storage;
using Core.UI;
using Core.UI.Dialogs;



namespace LayoutDesigner {
  public partial class Main : Form {
    // Constants
    private const string TITLE_BASE = "Návrhář rozložení";



    // Data
    private Layout CurrentLayout;

    private bool IsLayoutPresent {
      get => this.CurrentLayout != null;
    }

    private object CurrentSelection;

    private List<string> ValidLayoutNames {
      get => LayoutManager.GetExistingLayoutNames().ToList();
    }

    private readonly int TitleBarHeight;



    // Constructor
    public Main() {
      InitializeComponent();

      this.TitleBarHeight = this.RectangleToScreen(this.ClientRectangle).Top - this.Top;

      // Minimum size
      int left = this.SplitContainer_Vertical.Panel1MinSize;
      int right = this.SplitContainer_Vertical.Panel2MinSize;
      int splitterWidth = this.SplitContainer_Vertical.SplitterWidth;

      int top = this.SplitContainer_Horizontal.Panel1MinSize;
      int bottom = this.SplitContainer_Horizontal.Panel2MinSize;
      int splittedHeight = this.SplitContainer_Horizontal.SplitterWidth;

      int minimalWidth = left + right + splitterWidth;
      int minimalHeight = top + bottom + splittedHeight + this.TitleBarHeight + this.MenuStrip.Height;

      this.MinimumSize = new Size(minimalWidth, minimalHeight);

      // Post-hooks
      this.SetCurrentLayout(null);
      this.UpdateState();

      //this.Open("grid-test");
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
      // Pre-hooks
      this.Unload();

      // Setup new object
      UserNewObject newLayout = this.CreateNewLayout();

      if (newLayout.DialogResult == DialogResult.OK) {
        // Post-hooks
        this.SetCurrentLayout((Layout) newLayout.FinalValue);
      }
    }

    private void Open(string layoutName) {
      Layout layout = Core.Storage.Layout.Import(layoutName);
      this.SetCurrentLayout(layout);
    }

    private void Open() {
      UserSelect selectLayoutName = GetSelect(LayoutManager.GetValidLayoutNames(), "Vyberte rozložení");

      if (selectLayoutName.DialogResult == DialogResult.OK) {
        string layoutName = (string) selectLayoutName.FinalValue;

        this.Open(layoutName);
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
        bool layoutHasAvailableArea = this.CurrentLayout.Area > this.CurrentLayout.Area_Zones;

        if (!layoutHasAvailableArea) {
          MessageBoxes.AreaFull();
        } else {
          UserNewObject newZone = CreateNewZone();

          if (newZone.DialogResult == DialogResult.OK) {
            this.CurrentLayout.Add((Zone) newZone.FinalValue);

            // Post-hooks
            this.UpdateState();
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
          MessageBoxes.NameCannotBeEmpty();
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

      UserTextInput userTextInput = new(valueValidator, "Nový název rozložení");

      userTextInput.ShowDialog(this);

      return userTextInput;
    }

    private UserNewObject CreateNewLayout() {
      Func<object, bool> validator = obj => {
        Layout layout = (Layout) obj;



        bool isNameEmpty = layout.Name.Trim().Length == 0;

        bool isNameAlreadyInUse = LayoutManager.GetExistingLayoutNames().Contains(layout.Name);

        bool hasInvalidSize = layout.Size.Width < 1 || layout.Size.Height < 1;



        if (isNameEmpty) {
          MessageBoxes.NameCannotBeEmpty();
          return false;
        }
        
        if (isNameAlreadyInUse) {
          MessageBoxes.NameAlreadyInUse();
          return false;
        }

        if (hasInvalidSize) {
          MessageBoxes.InvalidSize();
          return false;
        }



        return true;
      };

      Layout initialLayout = new("Nové rozložení", "warehouse-1", new(10, 10));

      UserNewObject newLayout = new(validator, initialLayout, "Nová zóna");

      newLayout.ShowDialog(this);

      return newLayout;
    }

    private UserNewObject CreateNewZone() {
      Func<object, bool> validator = obj => {
        Zone zone = (Zone) obj;



        bool isNameEmpty = zone.Name.Trim().Length == 0;

        bool isNameAlreadyInUse = this.CurrentLayout.Any(currentZone => currentZone.Name == zone.Name);

        bool isVerticalCapacityGreaterThanZero = zone.VerticalCapacity > 0;

        bool isVerticalCapacityZero = zone.VerticalCapacity == 0;

        bool isOutOfBounds = !this.CurrentLayout.Rectangle.Contains(zone.Rectangle);

        bool doesIntersectWithOtherZone = this.CurrentLayout.Zones.Any(currentZone => zone.Rectangle.IntersectsWith(currentZone.Rectangle));

        bool hasInvalidSize = zone.Size.Width < 1 || zone.Size.Height < 1;



        if (isNameEmpty) {
          MessageBoxes.NameCannotBeEmpty();
          return false;
        }
        
        if (isNameAlreadyInUse) {
          MessageBoxes.NameAlreadyInUse();
          return false;
        }
        
        if (zone.Type == ZoneType.Storage && !isVerticalCapacityGreaterThanZero) {
          MessageBoxes.VerticalCapacityGreaterThanZero();
          return false;
        }

        if (zone.Type == ZoneType.Other && !isVerticalCapacityZero) {
          MessageBoxes.VerticalCapacityMustBeZero();
          return false;
        }

        if (isOutOfBounds) {
          MessageBoxes.CantBeOutOfBounds();
          return false;
        }

        if (doesIntersectWithOtherZone) {
          MessageBoxes.CantIntersect();
          return false;
        }

        if (hasInvalidSize) {
          MessageBoxes.InvalidSize();
          return false;
        }



        return true;
      };

      Zone initialZone = new("Nová zóna", ZoneType.Storage, 4, "značka", new(1, 1), new(0, 0));

      UserNewObject newZone = new(validator, initialZone, "Nová zóna");

      newZone.ShowDialog(this);

      return newZone;
    }



    // Update state
    private void UpdateTitle() {
      if (this.IsLayoutPresent) {
        this.Text = $"{ TITLE_BASE } - { this.CurrentLayout.Name } ({( this.CurrentLayout.IsCorrespondingFileUpToDate() ? "uloženo" : "neuloženo" )})";
      } else {
        this.Text = $"{ TITLE_BASE }";
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

    private void UpdateRemoveZoneControl_Enabled() {
      this.ToolStripMenuItem_RemoveZone.Enabled = this.IsLayoutPresent && this.CurrentLayout.Zones.Count > 0;
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
      this.UpdateRemoveZoneControl_Enabled();

      // Post-hooks
      this.CurrentLayoutChangedHandler();
      this.CurrentSelectionChangedHandler();
    }



    // Set state
    private void SetCurrentLayout(Layout layout) {
      this.CurrentLayout = layout;

      if (this.IsLayoutPresent) {
        this.CurrentLayout.Initialize(0);
      }

      // Post-hooks
      this.UpdateState();
    }

    private void SetCurrentSelection(string path) {
      string[] pathPieces = path.Split(this.TreeView_Layout.PathSeparator.ToCharArray());
      int level = pathPieces.Length - 1;
      object currentSelection = null;

      // Find currentSelection which can be Layout, Zone or CarBrand
      if (level == 0 || level == 1) {
        if (level == 0) {
          if (pathPieces[level] == this.CurrentLayout.Name) {
            currentSelection = this.CurrentLayout;
          }
        } else {
          foreach (Zone zone in this.CurrentLayout) {
            if (level == 1) {
              if (pathPieces[level] == zone.Name) {
                currentSelection = zone;

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
      // Draw
      this.PictureBox_Layout.Refresh();

      // TreeView
      this.TreeView_Layout.Nodes.Clear();

      if (this.IsLayoutPresent) {
        var rootNode = TreeView_Layout.Nodes.Add(this.CurrentLayout.Name);

        foreach (Zone zone in this.CurrentLayout.Zones) {
          rootNode.Nodes.Add(zone.Name);
        }

        this.TreeView_Layout.ExpandAll();
      }
    }

    private void CurrentSelectionChangedHandler() {
      this.PropertyGrid_CurrentSelection.SelectedObject = this.CurrentSelection;
    }



    // Visual
    private void DrawLayout(Graphics graphics) {
      graphics.Clear(this.PictureBox_Layout.BackColor);

      if (this.IsLayoutPresent) {
        this.PictureBox_Layout.Size = this.CurrentLayout.Size.Scale(StaticSettings.UNIT_SIZE);
        Drawer.DrawLayout(graphics, this.CurrentLayout);
      }
    }



    // File (Tool strip menu item)
    private void ToolStripMenuItem_New_Click(object sender, EventArgs e) {
      this.New();
    }

    private void ToolStripMenuItem_Open_Click(object sender, EventArgs e) {
      this.Open();
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



    // Layout (Tool strip menu item)
    private void ToolStripMenuItem_NewZone_Click(object sender, EventArgs e) {
      this.NewZone();
    }

    private void ToolStripMenuItem_RemoveZone_Click(object sender, EventArgs e) {
      this.RemoveZone();
    }



    // Window (Main)
    private void Main_Resize(object sender, EventArgs e) {
      // Split containers
      this.SplitContainer_Vertical.Width = this.Width;
      this.SplitContainer_Vertical.Height = this.Height - this.TitleBarHeight - this.MenuStrip.Height;
    }

    private void Main_FormClosing(object sender, FormClosingEventArgs e) {
      this.Unload();
    }



    // Split container vertical
    private void SplitContainer_Vertical_Panel1_Resize(object sender, EventArgs e) {
      SplitterPanel panel = this.SplitContainer_Vertical.Panel1;
      Size size = new(panel.Width, panel.Height);

      this.SplitContainer_Horizontal.Size = size;
    }



    // Split container horizontal
    private void SplitContainer_Horizontal_Panel1_Resize(object sender, EventArgs e) {
      SplitterPanel panel = this.SplitContainer_Horizontal.Panel1;
      Size size = new(panel.Width, panel.Height);

      this.TreeView_Layout.Size = size;
    }

    private void SplitContainer_Horizontal_Panel2_Resize(object sender, EventArgs e) {
      SplitterPanel panel = this.SplitContainer_Horizontal.Panel2;
      Size size = new(panel.Width, panel.Height);

      this.PropertyGrid_CurrentSelection.Size = size;
    }



    // Other
    private void TreeView_Layout_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e) {
      this.SetCurrentSelection(e.Node.FullPath);
    }

    private void PropertyGrid_CurrentSelection_PropertyValueChanged(object s, PropertyValueChangedEventArgs e) {
      this.UpdateState();
    }

    private void PictureBox_Layout_Paint(object sender, PaintEventArgs e) {
      this.DrawLayout(e.Graphics);
    }
  }
}
