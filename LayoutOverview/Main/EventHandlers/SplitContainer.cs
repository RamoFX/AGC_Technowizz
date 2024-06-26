﻿using System;
using System.Drawing;
using System.Windows.Forms;



namespace LayoutOverview {
  public partial class Main {
    // Vertical (Tree layout _ Properties current selection)
    private void SplitContainer_Vertical_Panel1_Resize(object sender, EventArgs e) {
      SplitterPanel panel = SplitContainer_Vertical.Panel1;
      Size size = new(panel.Width, panel.Height);

      SplitContainer_Horizontal.Size = size;
    }



    // Horizontal (Split container vertical | Canvas layout)
    private void SplitContainer_Horizontal_Panel1_Resize(object sender, EventArgs e) {
      SplitterPanel panel = SplitContainer_Horizontal.Panel1;
      Size size = new(panel.Width, panel.Height);

      Tree_Layout.Size = size;
    }

    private void SplitContainer_Horizontal_Panel2_Resize(object sender, EventArgs e) {
      SplitterPanel panel = SplitContainer_Horizontal.Panel2;
      Size size = new(panel.Width, panel.Height);

      Properties_CurrentSelection.Size = size;
    }
  }
}
