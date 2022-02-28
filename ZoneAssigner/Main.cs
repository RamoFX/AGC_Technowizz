using System;
using System.Drawing;
using System.Windows.Forms;

using Core.UI;



namespace ZoneAssigner {
  public partial class Main : Form {
    public Main() {
      // Initialization
      InitializeComponent();

      // Offset of height (this.Height and real height)
      this.MainHeightOffset = this.Height - Utilities.ComputeTitleBarHeight(this) - this.Menu.Height - this.Panel_Upper.Height - this.Canvas_Layout.Height;

      // Minimum size
      int minimalWidth = this.Menu.Width + SystemInformation.VerticalScrollBarWidth;
      int minimalHeight = this.Panel_Upper.Height + this.Panel_CanvasWrapper.Height + Utilities.ComputeTitleBarHeight(this) + this.Menu.Height + this.MainHeightOffset;

      this.MinimumSize = new Size(minimalWidth, minimalHeight);

      // Hide label text
      this.ZoneName.Text = "";

      // Post-hooks
      this.SetCurrentLayout(null);
      this.UpdateState();
    }
  }
}
