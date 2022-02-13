using System;
using System.Collections.Generic;
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
    private void Main_Resize(object sender, EventArgs e) {
      // Split containers
      this.SplitContainer_Vertical.Width = this.Width;
      this.SplitContainer_Vertical.Height = this.Height - Utilities.GetTitleBarHeight(this) - this.Menu.Height;
    }

    private void Main_FormClosing(object sender, FormClosingEventArgs e) {
      this.UnloadLayout();
    }
  }
}
