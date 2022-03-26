using System;
using System.Windows.Forms;

using Core.UI;



namespace ZoneAssigner {
  public partial class Main {
    private void Main_Resize(object sender, EventArgs e) {
      // Upper panel
      Panel_Upper.Width = Width;

      // Canvas
      Panel_CanvasWrapper.Width = Width;
      Panel_CanvasWrapper.Height = Height - Panel_Upper.Height - Utilities.ComputeTitleBarHeight(this) - Menu.Height - MainHeightOffset;

      // Redraw, unit size may change
      Canvas_Layout.Refresh();
    }



    private void Main_FormClosing(object sender, FormClosingEventArgs e) {
      UnloadLayout();
    }
  }
}
