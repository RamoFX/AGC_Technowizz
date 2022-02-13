using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

using Core;
using Core.Extensions;
using Core.Settings;
using Core.UI;
using Core.UI.Dialogs;



namespace LayoutDesigner {
  public partial class Main : Form {
    public Main() {
      InitializeComponent();

      // Minimum size
      int left = this.SplitContainer_Vertical.Panel1MinSize;
      int right = this.SplitContainer_Vertical.Panel2MinSize;
      int splitterWidth = this.SplitContainer_Vertical.SplitterWidth;

      int top = this.SplitContainer_Horizontal.Panel1MinSize;
      int bottom = this.SplitContainer_Horizontal.Panel2MinSize;
      int splittedHeight = this.SplitContainer_Horizontal.SplitterWidth;

      int minimalWidth = left + right + splitterWidth;
      int minimalHeight = top + bottom + splittedHeight + this.TitleBarHeight + this.Menu.Height;

      this.MinimumSize = new Size(minimalWidth, minimalHeight);

      // Post-hooks
      this.SetCurrentLayout(null);
      this.UpdateState();

      //this.Open("grid-test");
    }
  }
}
