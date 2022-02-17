using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Core.Extensions;
using Core.Settings;
using Core.UI;



namespace LayoutDesigner {
  public partial class Main {
    private void Tree_Layout_MouseDown(object sender, MouseEventArgs e) {
      object currentSelection = null;

      var node = this.Tree_Layout.HitTest(e.X, e.Y).Node;

      if (node != null) {
        if (this.CurrentLayout == null)
          return;

        string path = node.FullPath;
        char[] pathSeparator = this.Tree_Layout.PathSeparator.ToCharArray();
        var layout = this.CurrentLayout;

        currentSelection = Utilities.GetEntityFromTreePath(path, pathSeparator, layout);
      }

      this.SetCurrentSelection(currentSelection);
    }



    private void PropertyGrid_CurrentSelection_PropertyValueChanged(object s, PropertyValueChangedEventArgs e) {
      this.UpdateState();
    }




    private void Canvas_Layout_Paint(object sender, PaintEventArgs e) {
      e.Graphics.Clear(this.Canvas_Layout.BackColor);

      if (this.CurrentLayout == null)
        return;

      this.Canvas_Layout.Size = this.CurrentLayout.Size.Scale(StaticSettings.UNIT_SIZE);

      Drawer.DrawLayout(e.Graphics, e.ClipRectangle, this.CurrentLayout);
    }
  }
}
