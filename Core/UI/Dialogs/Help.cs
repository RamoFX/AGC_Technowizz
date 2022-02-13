using System;
using System.Windows.Forms;
using Core.Extensions;

using Core.Settings;



namespace Core.UI.Dialogs {
  public partial class Help : Form {
    public Help() {
      InitializeComponent();
    }

    private void Help_Load(object sender, EventArgs e) {
      Color100_PictureBox.BackColor = DynamicSettings.ZoneColor_Full.Value.ToColor();
      Color99_75_PictureBox.BackColor = DynamicSettings.ZoneColor_AlmostFull.Value.ToColor();
      Color74_50_PictureBox.BackColor = DynamicSettings.ZoneColor_AboveHalf.Value.ToColor();
      Color49_25_PictureBox.BackColor = DynamicSettings.ZoneColor_BelowHalf.Value.ToColor();
      Color24_1_PictureBox.BackColor = DynamicSettings.ZoneColor_AlmostEmpty.Value.ToColor();
      Color0_PictureBox.BackColor = DynamicSettings.ZoneColor_Empty.Value.ToColor();
    }
  }
}
