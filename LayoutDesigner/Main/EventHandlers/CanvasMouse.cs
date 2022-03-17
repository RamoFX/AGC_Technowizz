using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using Core;
using Core.Extensions;
using Core.UI;



namespace LayoutDesigner {
  public partial class Main {
    private void Canvas_Layout_MouseDoubleClick(object sender, MouseEventArgs e) {
      if (this.CurrentSelection == null)
        return;



      bool isLeft = e.Button == MouseButtons.Left;
      bool isRight = e.Button == MouseButtons.Right;



      // Actual selection determination
      string selectionType = this.CurrentSelection.GetType().ToString();

      bool isZone = selectionType == "Core.Zone+Entity";
      bool isLayout = !isZone && selectionType == "Core.Layout+Entity";



      // No target - no business
      if (!isZone && !isLayout)
        return;



      // Zone edit, delete
      if (isZone) {
        var targetZone = (Zone.Entity) this.CurrentSelection;

        // Edit
        if (isLeft) {
          this.EditZone(targetZone);
        }

        // Delete
        else if (isRight) {
          this.DeleteZone(targetZone, false);
        }
      }
      


      // Layout edit
      else if (isLeft && isLayout) {
        this.EditLayout();
      }



      // Post-hooks
      this.UpdateState();
    }



    private void Canvas_Layout_MouseDown(object sender, MouseEventArgs e) {
      if (this.CurrentLayout == null)
        return;

      object target = Utilities.MatchEntity(e.Location, this.CurrentUnitSize, this.CurrentLayout);
      this.SetCurrentSelection(target);

      this.IsCreatingZone = target.GetType().ToString() == "Core.Layout+Entity";

      if (!this.IsCreatingZone)
        return;

      this.DragStart = e.Location.Unscale(this.CurrentUnitSize);
      this.DragEnd = new(this.DragStart.X, this.DragStart.Y);
    }



    private void Canvas_Layout_MouseMove(object sender, MouseEventArgs e) {
      if (this.CurrentLayout == null)
        return;

      if (!this.IsCreatingZone)
        return;

      this.DragEnd = e.Location.Unscale(this.CurrentUnitSize);
    }



    private void Canvas_Layout_MouseUp(object sender, MouseEventArgs e) {
      if (this.CurrentLayout == null)
        return;

      if (!this.IsCreatingZone)
        return;

      this.IsCreatingZone = false;

      // Validation
      Point location = new(
        Math.Min(this.DragStart.X, this.DragEnd.X),
        Math.Min(this.DragStart.Y, this.DragEnd.Y)
      );

      Size size = new(
        this.DragEnd
          .Subtract(this.DragStart)
          .Abs()
          .Add(new(1, 1))
      );

      bool willLayoutContainZone = this.CurrentLayout.Rectangle.Contains(new Rectangle(location, size));

      if (!willLayoutContainZone)
        return;

      // Zone creation
      var newZone = new Zone.Entity {
        Location = location,
        Size = size
      };

      // Selection
      Zone.Entity finalZone = this.NewZone(newZone);

      if (finalZone == null)
        return;

      this.SetCurrentSelection(finalZone);
    }
  }
}
