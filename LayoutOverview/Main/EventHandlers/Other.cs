using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Core.Settings;
using Core.UI;



namespace LayoutOverview {
  public partial class Main {
    private void Tree_Layout_MouseDown(object sender, MouseEventArgs e) {
      object currentSelection = null;

      var node = Tree_Layout.HitTest(e.X, e.Y).Node;

      if (node != null) {
        if (CurrentLayout == null)
          return;

        string path = Regex.Replace(node.FullPath, @" \(\d+ %\)$", "");
        char[] pathSeparator = Tree_Layout.PathSeparator.ToCharArray();
        var layout = CurrentLayout;

        currentSelection = Utilities.MatchEntity(path, pathSeparator, layout);
      }

      SetCurrentSelection(currentSelection);
    }



    private void Properties_CurrentSelection_Enter(object sender, EventArgs e) {
      // Lose focus (shouldn't be editable)
      Properties_CurrentSelection.Enabled = false;
      Properties_CurrentSelection.Enabled = true;

      if (CurrentLayout == null || CurrentSelection == null)
        return;
    }



    private void Canvas_Layout_Paint(object sender, PaintEventArgs e) {
      // Remove previous paintings
      e.Graphics.Clear(Canvas_Layout.BackColor);

      // Continue is layout present
      if (CurrentLayout == null)
        return;

      // Update unit size
      CurrentUnitSize = Utilities.ComputeOptimalUnitSize(
        DynamicSettings.UnitSize.Value.ToInt(),
        SplitContainer_Vertical.Panel2.Size,
        CurrentLayout.Size
      );

      // Resize canvas
      Canvas_Layout.Size = CurrentLayout.Size.Scale(CurrentUnitSize) + new Size(StaticSettings.OUTLINE_SIZE / 2, StaticSettings.OUTLINE_SIZE / 2);

      // Draw
      Drawer.DrawLayout(e.Graphics, e.ClipRectangle, CurrentUnitSize, CurrentLayout, CurrentSelection, false);
    }
  }
}
