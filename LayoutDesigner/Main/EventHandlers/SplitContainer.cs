using System;
using System.Drawing;
using System.Windows.Forms;



namespace LayoutDesigner {
  public partial class Main {
    // Split container vertical
    private void SplitContainer_Vertical_Panel1_Resize(object sender, EventArgs e) {
      SplitterPanel panel = this.SplitContainer_Vertical.Panel1;
      Size size = new(panel.Width, panel.Height);

      this.SplitContainer_Horizontal.Size = size;
    }

    private void SplitContainer_Vertical_Panel2_Resize(object sender, EventArgs e) {
      SplitterPanel panel = this.SplitContainer_Vertical.Panel2;

      this.Panel_Tools.Width = panel.Width;

      this.PictureBox_Layout.Width = panel.Width;
      this.PictureBox_Layout.Height = panel.Height - this.Panel_Tools.Height;
    }



    // Split container horizontal
    private void SplitContainer_Horizontal_Panel1_Resize(object sender, EventArgs e) {
      SplitterPanel panel = this.SplitContainer_Horizontal.Panel1;
      Size size = new(panel.Width, panel.Height);

      this.Tree_Layout.Size = size;
    }

    private void SplitContainer_Horizontal_Panel2_Resize(object sender, EventArgs e) {
      SplitterPanel panel = this.SplitContainer_Horizontal.Panel2;
      Size size = new(panel.Width, panel.Height);

      this.Properties_CurrentSelection.Size = size;
    }
  }
}
