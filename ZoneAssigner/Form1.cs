using Core.Communicator;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Core.Storage;

namespace ZoneAssigner
{
  public partial class Form1 : Form {
    public Form1() {
      InitializeComponent();

      string PathToLastLayout = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
        "AGC_Technowizz_Layouts",
        "Layout.last"
      );

      if (File.Exists(PathToLastLayout))
        DataProcessing.Setup(File.ReadAllText(PathToLastLayout));
      else
        DataProcessing.Setup();

      this.Text = $"{FormName} ({DataProcessing.ActiveLayout.Name})";
    }

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

    const string FormName = "Přiřazovač zón";

    static Color color = Color.Red;

    void DelayAction(int millisecond, Action action)
    {
      Timer timer = new Timer();
      timer.Tick += delegate
      {
        action.Invoke();
        timer.Stop();
      };

      timer.Interval = millisecond;
      timer.Start();
    }

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
          DelayAction(HighlightTimeOnMs, Refresh);
          i++;
        }
        else
        {
          DelayAction(HighlightTimeOffMs, Refresh);
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

    private void TestDataComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
      ContainerCodeTextField.Text = TestDataComboBox.Text;
    }

    private void ToolStripMenuItem_Open_Click(object sender, EventArgs e)
    {
      OpenFileDialog openFileDialog = new OpenFileDialog()
      {
        Filter = "Layout files | *.xml",
        FileName = DataProcessing.ActiveLayout.Name,
        DefaultExt = "xml",
        AddExtension = true,
        InitialDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "AGC_Technowizz_Layouts")
      };
      openFileDialog.ShowDialog();
      DataProcessing.ActiveLayout = Core.Storage.Layout.Import(openFileDialog.FileName);
      this.Text = $"{FormName} ({DataProcessing.ActiveLayout.Name})";
    }

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
        zone = DataProcessing.GetZoneFromCarBrand(carBrand);

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
