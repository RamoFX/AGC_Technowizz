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
      this.ComboBox_ContainerCodes.DataSource = this.CurrentLayout.Zones
        .SelectMany(zone => zone.CarBrands)
        .Distinct()
        .Select((_, index) => index)
        .ToList();
    }



    // Fields & Properties
    private const string FormName = "Přiřazovač zón";
    private Layout CurrentLayout;

    /* and so on... */



    // Events
    private void ComboBox_ValidLayoutNames_SelectionChangeCommitted(object sender, EventArgs e) {
      string selectedLayoutName = (string) this.ValidLayoutNames.SelectedItem;
      this.SetActiveLayout(selectedLayoutName);
    }

    private void ComboBox_ContainerCodes_SelectedIndexChanged(object sender, EventArgs e) {
      ContainerCodeTextField.Text = ComboBox_ContainerCodes.Text;
    }

    /* and so on... */



    // Initializators
    private void Initialize_ComboBox_ValidLayoutNames() {
      this.ValidLayoutNames.ComboBox.BindingContext = this.BindingContext;
      this.ValidLayoutNames.ComboBox.SelectionChangeCommitted += this.ComboBox_ValidLayoutNames_SelectionChangeCommitted;
      this.ValidLayoutNames.ComboBox.DataSource = LayoutManager.GetValidLayoutNames().ToList();
    }

    private void InitializeLayout() {
      IEnumerable<string> validLayoutNames = LayoutManager.GetValidLayoutNames();

      // Load initial layout
      if (validLayoutNames.Contains(DynamicSettings.ZA_StartupLayoutName.Value)) {
        // Startup
        this.SetActiveLayout(DynamicSettings.ZA_StartupLayoutName.Value);
      } else if (validLayoutNames.Count() > 0) {
        // First existing
        string firstAvailableLayoutName = validLayoutNames.First();
        this.SetActiveLayout(firstAvailableLayoutName);
        MessageBoxes.StartupLayoutCorruptedOrDoesntExist();
      } else {
        // No layouts
        MessageBoxes.NoLayoutsExist();
        Application.Exit();
      }
    }

    /* and so on... */



    // State update
    private void SetActiveLayout(string name) {
      try {
        this.CurrentLayout = Core.Storage.Layout.Import(name);
        this.ValidLayoutNames.ComboBox.DataSource = LayoutManager.GetExistingLayoutNames().ToList();
        this.ValidLayoutNames.SelectedItem = name;
        DynamicSettings.ZA_StartupLayoutName.Value = name;
        this.Text = $"{FormName} ({name})";
      } catch {
        MessageBoxes.LayoutInvalid(name);
        InitializeLayout();
      }
    }

    /* and so on... */



    public const int boxSize = 30;
    public const int borderWidth = 3;

    // výška na ose Y
    public const int upperSize = 240;
    public const int bottomSize = 150;

    // vzdálenost na ose X
    public const int Astart = 0, Cstart = 0;
    public const int Bstart = 510, Dstart = 870;

    const int HighlightTimeOnMs = 600;
    const int HighlightTimeOffMs = 300;
    const int TotalHighlights = 4;
    const bool LastHighlightOn = true;

    static Color color = Color.Red;

    Rectangle GetRectangleFromZone(string zone)
    {
      if (zone != "X")
      {
        Rectangle rect = new();
        switch (zone[0].ToString().ToLower())
        {
          case "a":
            rect.X = Astart + (Convert.ToInt32(zone.Substring(1)) - 1) * boxSize;
            rect.Y = 0;
            rect.Height = upperSize;
            break;
          case "b":
            rect.X = Bstart + (Convert.ToInt32(zone.Substring(1)) - 1) * boxSize;
            rect.Y = 0;
            rect.Height = upperSize;
            break;
          case "c":
            rect.X = Cstart + (Convert.ToInt32(zone.Substring(1)) - 1) * boxSize;
            rect.Y = upperSize + 4 * boxSize;
            rect.Height = bottomSize;
            break;
          case "d":
            rect.X = Dstart + (Convert.ToInt32(zone.Substring(1)) - 1) * boxSize;
            rect.Y = upperSize + 4 * boxSize;
            rect.Height = bottomSize;
            break;
        }
        rect.Width = boxSize;
        return rect;
      }
      else return new();
    }

    // Draw rectangle to highlight zone
    void HighlightZone(string zone, Graphics g)
    {
      Rectangle rect = GetRectangleFromZone(zone);
      g.FillRectangle(new SolidBrush(Color.FromArgb(50, color)), rect);
      g.DrawRectangle(new(color, borderWidth), rect);
    }

    int i = 0;
    private void VisualizerPictureBox_Paint(object sender, PaintEventArgs e)
    {
      Graphics g = e.Graphics;
      // Highlight only on submit
      if (submitted)
      {
        // Last iteration
        if (i == TotalHighlights * 2) 
        {
          i = 0;
          if (LastHighlightOn) HighlightZone(zone, g);
        }

        // Turn highlight on and off
        else if (i % 2 == 0)
        {
          HighlightZone(zone, g);
          Utilities.DelayAction(HighlightTimeOnMs, Refresh);
          i++;
        }
        else
        {
          Utilities.DelayAction(HighlightTimeOffMs, Refresh);
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

    bool submitted = false;
    string zone = "";

    private void SubmitHandler(object sender, EventArgs e)
    {
      // Check text field
      bool containerCodeEmpty = ContainerCodeTextField.Text.Trim().Length == 0;
      bool containerCodeNotOnlyNumbers = !int.TryParse(ContainerCodeTextField.Text, out int containerCode);
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
        var suitableZones = this.CurrentLayout.GetSuitableZones(carBrand);

        zone = suitableZones.Count() > 0
          ? suitableZones.First().Name
          : "×";

        ContainerCodeTextField.Clear();
        HideError();
        ShowZone(zone.ToUpper());
        VisualizerPictureBox.Refresh();
      }
    }

    private void SubmitOnEnter(object sender, EventArgs e)
    {

    }
  }
}
