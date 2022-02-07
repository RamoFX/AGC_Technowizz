using System;
using System.Windows.Forms;
using Core.Extensions;

namespace Core.UI.Dialogs {
  public partial class Help : Form
  {
    public Help()
    {
      InitializeComponent();
    }

    private void Help_Load(object sender, EventArgs e)
    {
      Color100_PictureBox.BackColor = DynamicSettings.CarBrandColor_Full.Value.ToColor();
      Color99_75_PictureBox.BackColor = DynamicSettings.CarBrandColor_AlmostFull.Value.ToColor();
      Color74_50_PictureBox.BackColor = DynamicSettings.CarBrandColor_AboveHalf.Value.ToColor();
      Color49_25_PictureBox.BackColor = DynamicSettings.CarBrandColor_BelowHalf.Value.ToColor();
      Color24_1_PictureBox.BackColor = DynamicSettings.CarBrandColor_AlmostEmpty.Value.ToColor();
      Color0_PictureBox.BackColor = DynamicSettings.CarBrandColor_Empty.Value.ToColor();
    }
  }
}
