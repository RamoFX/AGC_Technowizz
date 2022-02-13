using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Core;
using Core.Extensions;
using Core.Settings;
using Core.UI;
using Core.UI.Dialogs;



namespace LayoutDesigner {
  public partial class Main {
    // Split container vertical
    private void SplitContainer_Vertical_Panel1_Resize(object sender, EventArgs e) {
      SplitterPanel panel = this.SplitContainer_Vertical.Panel1;
      Size size = new(panel.Width, panel.Height);

      this.SplitContainer_Horizontal.Size = size;
    }



    // Split container horizontal
    private void SplitContainer_Horizontal_Panel1_Resize(object sender, EventArgs e) {
      SplitterPanel panel = this.SplitContainer_Horizontal.Panel1;
      Size size = new(panel.Width, panel.Height);

      this.Tree_Layout.Size = size;
    }

    private void SplitContainer_Horizontal_Panel2_Resize(object sender, EventArgs e) {
      SplitterPanel panel = this.SplitContainer_Horizontal.Panel2;
      Size size = new(panel.Width, panel.Height);

      this.Properties_CurrentSelection.Size = size;
    }
  }
}
