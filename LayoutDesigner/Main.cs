using System.Drawing;
using System.Windows.Forms;

using Core.UI;



namespace LayoutDesigner {
  public partial class Main : Form {
    public Main() {
      InitializeComponent();

      // Preparation
      int left = SplitContainer_Vertical.Panel1MinSize;
      int right = SplitContainer_Vertical.Panel2MinSize;
      int splitterWidth = SplitContainer_Vertical.SplitterWidth;

      int top = SplitContainer_Horizontal.Panel1MinSize;
      int bottom = SplitContainer_Horizontal.Panel2MinSize;
      int splitterHeight = SplitContainer_Horizontal.SplitterWidth;

      // Offset of height (this.Height and real height)
      MainHeightOffset = Height - Utilities.ComputeTitleBarHeight(this) - Menu.Height - SplitContainer_Vertical.Height;

      // Minimum size
      int minimalWidth = left + right + splitterWidth + SystemInformation.VerticalScrollBarWidth;
      int minimalHeight = top + bottom + splitterHeight + Utilities.ComputeTitleBarHeight(this) + Menu.Height + MainHeightOffset;

      MinimumSize = new Size(minimalWidth, minimalHeight);

      // Post-hooks
      SetCurrentLayout(null);
      UpdateState();
    }
  }
}
