using System;
using System.Drawing;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;

using Communicator;
using Core.Storage;
using Core.UI;
using Core;



namespace ZoneAssigner
{
  public partial class Main : Form {
    public Main() {
      InitializeComponent();
    }

    private void Main_Load(object sender, EventArgs e)
    {
      Initialize_ComboBox_ValidLayoutNames();
      InitializeLayout();
      Initialize_ComboBox_ContainerCodes();
    }



    // Fields & Properties
    private const string FormName = "Přiřazovač zón";
    private static readonly Color color = Color.Red;
    private readonly List<string> ValidLayoutNames = LayoutManager.GetValidLayoutNames().ToList();

    private Layout CurrentLayout;
    private Zone zone;

    private int i = 0;
    private bool submitted = false;




    // Initializators
    private void Initialize_ComboBox_ValidLayoutNames() {
      this.Menu_ValidLayoutNames.ComboBox.BindingContext = this.BindingContext;
      this.Menu_ValidLayoutNames.ComboBox.SelectionChangeCommitted += this.ComboBox_ValidLayoutNames_SelectionChangeCommitted;
      this.Menu_ValidLayoutNames.ComboBox.DataSource = ValidLayoutNames;
    }

    private void InitializeLayout() {
      // Load initial layout
      if (ValidLayoutNames.Contains(DynamicSettings.StartupLayoutName.Value)) {
        // Startup
        this.SetActiveLayout(DynamicSettings.StartupLayoutName.Value);
      } else if (ValidLayoutNames.Count() > 0) {
        // First existing
        this.SetActiveLayout(ValidLayoutNames.First());
        MessageBoxes.StartupLayoutCorruptedOrDoesntExist();
      } else {
        // No layouts
        MessageBoxes.NoLayoutsExist();
        Environment.Exit(0);
      }
    }

    private void Initialize_ComboBox_ContainerCodes() {
      this.ComboBox_ContainerCodes.DataSource = this.CurrentLayout.Zones
        .SelectMany(zone => zone.CarBrands)
        .Select(carBrand => carBrand.Name)
        .Select((_, index) => index)
        .Distinct()
        .ToList();
    }



    // State update
    private void SetActiveLayout(string name) {
      this.CurrentLayout = Core.Storage.Layout.Import(name);
      this.CurrentLayout.Initialize(1);
      this.Text = $"{FormName} ({name})";
      this.Menu_ValidLayoutNames.SelectedItem = name;
      DynamicSettings.StartupLayoutName.Value = name;

      Initialize_ComboBox_ContainerCodes();
    }

    private void ShowError(string errorText) {
      ErrorLabel.Text = errorText;
      ErrorLabel.Visible = true;
    }

    private void HideError() {
      ErrorLabel.Text = "";
      ErrorLabel.Visible = false;
    }

    private void ShowZone(string zone) {
      ZoneLabel.Text = zone;
      ZoneLabel.Visible = true;
    }

    private void HideZone() {
      ZoneLabel.Text = "--";
      ZoneLabel.Visible = false;
    }

    private void ShowHelp()
    {
      Core.UI.Dialogs.Help help = new Core.UI.Dialogs.Help();
      help.Show();
    }



    // Events
    private void ComboBox_ValidLayoutNames_SelectionChangeCommitted(object sender, EventArgs e) {
      string selectedLayoutName = (string) this.Menu_ValidLayoutNames.SelectedItem;
      this.SetActiveLayout(selectedLayoutName);
    }

    private void ComboBox_ContainerCodes_SelectedIndexChanged(object sender, EventArgs e) {
      TextField_ContainerCode.Text = ComboBox_ContainerCodes.Text;
    }

    private void VisualizerPictureBox_Paint(object sender, PaintEventArgs e)
    {
      Graphics g = e.Graphics;
      // Highlight only on submit
      if (submitted)
      {
        // Last iteration
        if (i == Convert.ToInt32(DynamicSettings.Highlight_TotalFlashesCount.Value) * 2) 
        {
          i = 0;
          if (Convert.ToBoolean(DynamicSettings.Highlight_TotalFlashesCount.Value)) Drawer.Draw(zone, color, g);
        }

        // Turn highlight on and off
        else if (i % 2 == 0)
        {
          Drawer.Draw(zone, color, g);
          Utilities.DelayAction(Convert.ToInt32(DynamicSettings.Highlight_CycleDuration.Value) / 2, Refresh);
          i++;
        }
        else
        {
          Utilities.DelayAction(Convert.ToInt32(DynamicSettings.Highlight_CycleDuration.Value) / 2, Refresh);
          i++;
        }
      }
    }

    private void SubmitHandler(object sender, EventArgs e)
    {
      // Check text field
      bool containerCodeEmpty = TextField_ContainerCode.Text.Trim().Length == 0;
      bool containerCodeNotOnlyNumbers = !int.TryParse(TextField_ContainerCode.Text, out int palletCode);
      submitted = true;

      if (containerCodeEmpty)
      {
        HideZone();
        ShowError("Textové pole nesmí být prázdné.");
      }
      else if (containerCodeNotOnlyNumbers)
      {
        HideZone();
        ShowError("Textové pole smí obsahovat pouze čísla.");
      }
      else
      {
        // containerCode ---> zone
        string carBrand = DatabaseAccess.GetCarBrandName(this.CurrentLayout.WarehouseName, $"{ palletCode }");
        zone = this.CurrentLayout.GetFirstSuitableZoneOrDefault(carBrand);

        TextField_ContainerCode.Clear();
        HideError();
        ShowZone(zone?.Name ?? "×"); // Can be default(Zone) == null
        VisualizerPictureBox.Refresh();
      }
    }

    private void ToolStripMenuItem_Help_Click(object sender, EventArgs e)
    {
      ShowHelp();
    }
  }
}
