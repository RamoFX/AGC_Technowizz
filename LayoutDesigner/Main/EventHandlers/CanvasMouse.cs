using System.Windows.Forms;

using Core;
using Core.UI;



namespace LayoutDesigner {
  public partial class Main {
    private void Canvas_Layout_MouseDoubleClick(object sender, MouseEventArgs e) {
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



    private void Canvas_Layout_MouseDown(object sender, MouseEventArgs e) {
      if (CurrentLayout == null)
        return;

      object target = Utilities.MatchEntity(e.Location, CurrentUnitSize, CurrentLayout);
      SetCurrentSelection(target);

      IsCreatingZone = target.GetType().ToString() == "Core.Layout+Entity";

      if (!IsCreatingZone)
        return;

      DragStart = e.Location.Unscale(CurrentUnitSize);
      DragEnd = new(DragStart.X, DragStart.Y);

      Canvas_Layout.Refresh();
    }



    private void Canvas_Layout_MouseMove(object sender, MouseEventArgs e) {
      if (CurrentLayout == null)
        return;

      if (!IsCreatingZone)
        return;

      DragEnd = e.Location.Unscale(CurrentUnitSize);

      Canvas_Layout.Refresh();
    }



    private void Canvas_Layout_MouseUp(object sender, MouseEventArgs e) {
      if (CurrentLayout == null)
        return;

      if (!IsCreatingZone)
        return;

      IsCreatingZone = false;

      Canvas_Layout.Refresh();

      // Validation
      var rectangle = Utilities.CreateRectangleFromPoints(DragStart, DragEnd);

      bool willLayoutContainZone = CurrentLayout.Rectangle.Contains(rectangle);

      if (!willLayoutContainZone)
        return;

      // Zone creation
      var newZone = new Zone.Entity {
        Location = rectangle.Location,
        Size = rectangle.Size
      };

      // Selection
      Zone.Entity finalZone = NewZone(newZone);

      if (finalZone == null)
        return;

      SetCurrentSelection(finalZone);
    }
  }
}
