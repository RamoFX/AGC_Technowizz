using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using Core;
using Core.Extensions;
using Core.Settings;
using Core.UI;



namespace LayoutDesigner {
  public partial class Main {
    private void Canvas_Layout_MouseClick(object sender, MouseEventArgs e) {
      if (this.CurrentLayout == null)
        return;

      var target = Utilities.MatchEntity(e.Location, this.CurrentUnitSize, this.CurrentLayout);

      // Create new zone
      bool doCreateZone = target.GetType().ToString() == "Core.Layout+Entity";

      if (doCreateZone) {
        var newZone = new Zone.Entity {
          Location = e.Location.Unscale(this.CurrentUnitSize)
        };

        this.NewZone(newZone);
      }

      // Hooks
      this.SetCurrentSelection(target);
    }



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

      this.IsDragging = true;
    }



    private void Canvas_Layout_MouseUp(object sender, MouseEventArgs e) {
      this.IsDragging = false;
    }



    private void Canvas_Layout_MouseLeave(object sender, EventArgs e) {
      Cursor.Current = Cursors.Default;
      this.IsDragging = false;
    }
  }
}
