using System;
using System.Drawing;
using System.Windows.Forms;

using Core.UI;



namespace LayoutDesigner {
  public partial class Main : Form {
    private const string TITLE_BASE = "Návrhář rozložení";
    private readonly int MainHeightOffset;

    public Main() {
      InitializeComponent();

      // Preparation
      int left = this.SplitContainer_Vertical.Panel1MinSize;
      int right = this.SplitContainer_Vertical.Panel2MinSize;
      int splitterWidth = this.SplitContainer_Vertical.SplitterWidth;

      int top = this.SplitContainer_Horizontal.Panel1MinSize;
      int bottom = this.SplitContainer_Horizontal.Panel2MinSize;
      int splitterHeight = this.SplitContainer_Horizontal.SplitterWidth;

      // Offset of height (this.Height and real height)
      this.MainHeightOffset = this.Height - Utilities.ComputeTitleBarHeight(this) - this.Menu.Height - this.SplitContainer_Vertical.Height;
      Console.WriteLine();

      // Minimum size
      int minimalWidth = left + right + splitterWidth + SystemInformation.VerticalScrollBarWidth;
      int minimalHeight = top + bottom + splitterHeight + Utilities.ComputeTitleBarHeight(this) + this.Menu.Height + this.MainHeightOffset;

      this.MinimumSize = new Size(minimalWidth, minimalHeight);

      // Post-hooks
      this.SetCurrentLayout(null);
      this.UpdateState();

      //this.Open("grid-test");
    }
  }
}
