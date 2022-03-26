using System;
using System.Windows.Forms;

using Core.UI;



namespace LayoutOverview {
  public partial class Main {
    private void Main_Resize(object sender, EventArgs e) {
      // Split containers
      SplitContainer_Vertical.Width = Width - SystemInformation.VerticalScrollBarWidth;
      SplitContainer_Vertical.Height = Height - Utilities.ComputeTitleBarHeight(this) - Menu.Height - StatusStrip.Height + MainHeightOffset - SystemInformation.HorizontalScrollBarHeight;

      // Redraw, unit size may change
      Canvas_Layout.Refresh();
    }



    private void Main_FormClosing(object sender, FormClosingEventArgs e) {
      UnloadLayout();
    }
  }
}
