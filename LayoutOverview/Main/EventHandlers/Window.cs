using System;
using System.Windows.Forms;

using Core.UI;



namespace LayoutOverview {
  public partial class Main {
    private void Main_Resize(object sender, EventArgs e) {
      // Split containers
      this.SplitContainer_Vertical.Width = this.Width - SystemInformation.VerticalScrollBarWidth;
      this.SplitContainer_Vertical.Height = this.Height - Utilities.ComputeTitleBarHeight(this) - this.Menu.Height - this.StatusStrip.Height + this.MainHeightOffset - SystemInformation.HorizontalScrollBarHeight;

      // Redraw, unit size may change
      this.Canvas_Layout.Refresh();
    }



    private void Main_FormClosing(object sender, FormClosingEventArgs e) {
      this.UnloadLayout();
    }
  }
}
