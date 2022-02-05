using System;
using System.Drawing;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;

using Core;
using Core.Storage;
using Core.Communicator;
using Core.UI;
using Core.Helpers;



namespace ZoneAssigner
{
  public partial class Main : Form {
    public Main() {
      InitializeComponent();
      Initialize_ComboBox_ValidLayoutNames();
      InitializeLayout();
      Initialize_ComboBox_ContainerCodes();
    }



    // Fields & Properties
    private const string FormName = "Přiřazovač zón";

    private Layout CurrentLayout;

    private readonly List<string> ValidLayoutNames = LayoutManager.GetValidLayoutNames().ToList();



    /* and so on... */



    // Events
    private void ComboBox_ValidLayoutNames_SelectionChangeCommitted(object sender, EventArgs e) {
      string selectedLayoutName = (string) this.Menu_ValidLayoutNames.SelectedItem;
      this.SetActiveLayout(selectedLayoutName);
    }

    private void ComboBox_ContainerCodes_SelectedIndexChanged(object sender, EventArgs e) {
      TextField_ContainerCode.Text = ComboBox_ContainerCodes.Text;
    }

    /* and so on... */



    // Initializators
    private void Initialize_ComboBox_ValidLayoutNames() {
      this.Menu_ValidLayoutNames.ComboBox.BindingContext = this.BindingContext;
      this.Menu_ValidLayoutNames.ComboBox.SelectionChangeCommitted += this.ComboBox_ValidLayoutNames_SelectionChangeCommitted;
      this.Menu_ValidLayoutNames.ComboBox.DataSource = ValidLayoutNames;
    }

    private void InitializeLayout() {
      // Load initial layout
      if (ValidLayoutNames.Contains(DynamicSettings.ZA_StartupLayoutName.Value)) {
        // Startup
        this.SetActiveLayout(DynamicSettings.ZA_StartupLayoutName.Value);
      } else if (ValidLayoutNames.Count() > 0) {
        // First existing
        this.SetActiveLayout(ValidLayoutNames.First());
        MessageBoxes.StartupLayoutCorruptedOrDoesntExist();
      } else {
        // No layouts
        MessageBoxes.NoLayoutsExist();
        Application.Exit();
      }
    }

    private void Initialize_ComboBox_ContainerCodes() {
      this.ComboBox_ContainerCodes.DataSource = this.CurrentLayout.Zones
        .SelectMany(zone => zone.CarBrands)
        .Distinct()
        .Select((_, index) => index)
        .ToList();
    }

    /* and so on... */



    // State update
    private void SetActiveLayout(string name) {
      this.CurrentLayout = Core.Storage.Layout.Import(name);
      this.Text = $"{FormName} ({name})";
      this.Menu_ValidLayoutNames.SelectedItem = name;
      DynamicSettings.ZA_StartupLayoutName.Value = name;

      Initialize_ComboBox_ContainerCodes();
    }

    /* and so on... */

    static Color color = Color.Red;


    int i = 0;
    bool submitted = false;
    Zone zone;


    private void VisualizerPictureBox_Paint(object sender, PaintEventArgs e)
    {
      Graphics g = e.Graphics;
      // Highlight only on submit
      if (submitted)
      {
        // Last iteration
        if (i == Convert.ToInt32(DynamicSettings.ZA_TotalHighlightFlashes.Value) * 2) 
        {
          i = 0;
          if (Convert.ToBoolean(DynamicSettings.ZA_LastHighlightOnOff.Value)) Utilities.Drawer.Draw(zone, color, g);
        }

        // Turn highlight on and off
        else if (i % 2 == 0)
        {
          Utilities.Drawer.Draw(zone, color, g);
          Utilities.DelayAction(Convert.ToInt32(DynamicSettings.ZA_HighlightTimeOn.Value), Refresh);
          i++;
        }
        else
        {
          Utilities.DelayAction(Convert.ToInt32(DynamicSettings.ZA_HighlightTimeOff.Value), Refresh);
          i++;
        }
      }
    }
    
    // Error
    private void ShowError(string errorText)
    {
      ErrorLabel.Text = errorText;
      ErrorLabel.Visible = true;
    }

    private void HideError()
    {
      ErrorLabel.Text = "";
      ErrorLabel.Visible = false;
    }

    // Zone
    private void ShowZone(string zone)
    {
      ZoneLabel.Text = zone;
      ZoneLabel.Visible = true;
    }

    private void HideZone()
    {
      ZoneLabel.Text = "--";
      ZoneLabel.Visible = false;
    }

    private void SubmitHandler(object sender, EventArgs e)
    {
      // Check text field
      bool containerCodeEmpty = TextField_ContainerCode.Text.Trim().Length == 0;
      bool containerCodeNotOnlyNumbers = !int.TryParse(TextField_ContainerCode.Text, out int containerCode);
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
        string carBrand = DatabaseAccess.GetCarBrandFromContainerCode($"{ containerCode }");
        zone = this.CurrentLayout.GetFirstSuitableZoneOrDefault(carBrand);

        TextField_ContainerCode.Clear();
        HideError();
        ShowZone(zone?.Name ?? "×"); // Can be default(Zone) == null
        VisualizerPictureBox.Refresh();
      }
    }

    private void SubmitOnEnter(object sender, EventArgs e)
    {

    }
  }
}
