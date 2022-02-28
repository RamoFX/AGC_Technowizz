using System;
using System.Windows.Forms;

using Core.UI;



namespace ZoneAssigner {
  public partial class Main {
    private void Main_Resize(object sender, EventArgs e) {
      // Upper panel
      this.Panel_Upper.Width = this.Width;

      // Canvas
      this.Panel_CanvasWrapper.Width = this.Width;
      this.Panel_CanvasWrapper.Height = this.Height - this.Panel_Upper.Height - Utilities.ComputeTitleBarHeight(this) - this.Menu.Height - this.MainHeightOffset;

      // Redraw, unit size may change
      this.Canvas_Layout.Refresh();
    }



    private void Main_FormClosing(object sender, FormClosingEventArgs e) {
      this.UnloadLayout();
    }
  }
}
