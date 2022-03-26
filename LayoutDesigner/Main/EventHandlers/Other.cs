using System;
using System.Drawing;
using System.Windows.Forms;

using Core;
using Core.Settings;
using Core.UI;



namespace LayoutDesigner {
  public partial class Main {
    private void Tree_Layout_MouseDown(object sender, MouseEventArgs e) {
      object currentSelection = null;

      var node = Tree_Layout.HitTest(e.X, e.Y).Node;

      if (node != null) {
        if (CurrentLayout == null)
          return;

        string path = node.FullPath;
        char[] pathSeparator = Tree_Layout.PathSeparator.ToCharArray();
        var layout = CurrentLayout;

        currentSelection = Utilities.MatchEntity(path, pathSeparator, layout);
      }

      SetCurrentSelection(currentSelection);
    }



    private void Tree_Layout_MouseDoubleClick(object sender, MouseEventArgs e) {
      if (CurrentSelection == null)
        return;



      bool isLeft = e.Button == MouseButtons.Left;
      bool isRight = e.Button == MouseButtons.Right;



      // Actual selection determination
      string selectionType = CurrentSelection.GetType().ToString();

      bool isZone = selectionType == "Core.Zone+Entity";
      bool isLayout = !isZone && selectionType == "Core.Layout+Entity";



      // No target - no business
      if (!isZone && !isLayout)
        return;



      // Zone edit, delete
      if (isZone) {
        var targetZone = (Zone.Entity) CurrentSelection;

        // Edit
        if (isLeft) {
          EditZone(targetZone);
        }

        // Delete
        else if (isRight) {
          DeleteZone(targetZone, false);
        }
      }



      // Layout edit
      else if (isLeft && isLayout) {
        EditLayout();
      }



      // Post-hooks
      UpdateState();
    }



    private void Properties_CurrentSelection_Enter(object sender, EventArgs e) {
      // Lose focus (shouldn't be editable)
      Properties_CurrentSelection.Enabled = false;
      Properties_CurrentSelection.Enabled = true;

      if (CurrentLayout == null || CurrentSelection == null)
        return;

      // Edit matched entity
      bool isZone = CurrentSelection.GetType().ToString() == "Core.Zone+Entity";
      bool isLayout = CurrentSelection.GetType().ToString() == "Core.Layout+Entity";

      if (isZone) {
        var zone = (Zone.Entity) CurrentSelection;
        EditZone(zone);
      } else if (isLayout) {
        EditLayout();
      }
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
      Drawer.DrawLayout(e.Graphics, e.ClipRectangle, CurrentUnitSize, CurrentLayout, CurrentSelection, false, IsCreatingZone, DragStart, DragEnd);
    }
  }
}
