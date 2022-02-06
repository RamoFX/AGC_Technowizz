using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Core;
using Core.UI;
using Core.Storage;

namespace LayoutAnalyzer
{
  public partial class Main : Form
  {
    Layout CurrentLayout;

    public Main()
    {
      InitializeComponent();
    }

    private void Main_Load(object sender, EventArgs e)
    {
      SetCurrentLayout(Core.Storage.Layout.Import(DynamicSettings.ZA_StartupLayoutName.Value));
      CurrentLayout.Initialize(true);

      foreach (var zone in CurrentLayout.Zones)
      {
        foreach (var carBrand in zone.CarBrands)
        {
          panelProperties.Add(new EditableNode
          {
            LabelTitle = zone.Name,
            Label = carBrand.Name,
            DefaultValue = carBrand.PalletsCurrentlyStoredPercent.ToString(),
          });
        }
      }
    }


    private void panel1_Paint(object sender, PaintEventArgs e)
    {
      DrawLayout();
    }

    private bool IsLayoutPresent
    {
      get => this.CurrentLayout != null;
    }

    private void SetCurrentLayout(Layout layout)
    {
      this.CurrentLayout = layout;

      if (this.IsLayoutPresent)
      {
        this.CurrentLayout.Initialize(false);
      }
    }

    private void DrawLayout()
    {
      if (this.IsLayoutPresent)
      {
        Drawer.DrawLayout(this.panel1, this.CurrentLayout, new Size(SystemInformation.VerticalScrollBarWidth, 0));
      }
    }
  }
}
