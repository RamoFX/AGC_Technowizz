using System.Drawing;
using System.Windows.Forms;

using Core.UI;



namespace ZoneAssigner {
  public partial class Main : Form {
    public Main() {
      // Initialization
      InitializeComponent();

      // Offset of height (this.Height and real height)
      MainHeightOffset = Height - Utilities.ComputeTitleBarHeight(this) - Menu.Height - Panel_Upper.Height - Canvas_Layout.Height;

      // Minimum size
      int minimalWidth = Menu.Width + SystemInformation.VerticalScrollBarWidth;
      int minimalHeight = Panel_Upper.Height + Panel_CanvasWrapper.Height + Utilities.ComputeTitleBarHeight(this) + Menu.Height + MainHeightOffset;

      MinimumSize = new Size(minimalWidth, minimalHeight);

      // Hide label text
      ZoneName.Text = "";

      // Post-hooks
      SetCurrentLayout(null);
      UpdateState();
    }
  }
}
