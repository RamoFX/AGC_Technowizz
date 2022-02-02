using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Communicator;

namespace ZoneAssigner {
  public partial class Form1 : Form {
    public Form1() {
      InitializeComponent();
      DataProcessing.Setup();
    }

    private Random random = new Random();

    protected const int boxSize = 30;
    protected const int upperSize = 240;
    protected const int bottomSize = 150;

    private const int Astart = 0, Cstart = 0;
    private const int Bstart = 510, Dstart = 870;

    private const int borderWidth = 3;

    private const int HighlightTimeOnMs = 600;
    private const int HighlightTimeOffMs = 300;
    private const int TotalHighlights = 4;
    private const bool LastHighlightOn = true;

    public static Color color = Color.Red;

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
        switch (zone[0].ToString().ToUpper())
        {
          case "A":
            rect.X = Astart + (Convert.ToInt32(zone.Substring(1)) - 1) * boxSize;
            rect.Y = 0;
            rect.Height = upperSize;
            break;
          case "B":
            rect.X = Bstart + (Convert.ToInt32(zone.Substring(1)) - 1) * boxSize;
            rect.Y = 0;
            rect.Height = upperSize;
            break;
          case "C":
            rect.X = Cstart + (Convert.ToInt32(zone.Substring(1)) - 1) * boxSize;
            rect.Y = upperSize + 4 * boxSize;
            rect.Height = bottomSize;
            break;
          case "D":
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
      if (submitted)
      {
        if (i == TotalHighlights * 2) 
        {
          i = 0;
          if (LastHighlightOn)
            HighlightZone(zone, g);
        }
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
        ShowZone(zone);
        VisualizerPictureBox.Refresh();
      }
    }

    private void SubmitOnEnter(object sender, EventArgs e)
    {

    }
  }
}
