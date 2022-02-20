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
      object currentSelection = Utilities.MatchEntity(e.Location, this.CurrentLayout);
      this.SetCurrentSelection(currentSelection);
    }



    private void Canvas_Layout_MouseDoubleClick(object sender, MouseEventArgs e) {
      bool isLeft = e.Button == MouseButtons.Left;
      bool isRight = e.Button == MouseButtons.Right;



      // Actual selection determination
      if (this.CurrentSelection == null)
        return;

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
      this.IsDragging = true;
    }



    private void Canvas_Layout_MouseUp(object sender, MouseEventArgs e) {
      this.IsDragging = false;
    }



    private void Canvas_Layout_MouseMove(object sender, MouseEventArgs e) {
      if (this.CurrentLayout == null || this.IsDragging)
        return;



      //// Hovered entity
      //var hoveredEntity = Utilities.MatchEntity(e.Location, this.CurrentLayout);

      //if (hoveredEntity == null)
      //  return;

      //string type = hoveredEntity.GetType().ToString();

      //bool isZone = type == "Core.Zone+Entity";
      //bool isLayout = type == "Core.Layout+Entity";



      //// Entity bounds
      //Rectangle entityBounds;

      //if (isLayout)
      //  entityBounds = ((Layout.Entity) hoveredEntity).Rectangle;

      //else if (isZone)
      //  entityBounds = ((Zone.Entity) hoveredEntity).Rectangle;

      //else
      //  return;

      //entityBounds.Scale(StaticSettings.UNIT_SIZE);



      //// Entity clips
      //var movingClip = Utilities.CreateMovingClip(entityBounds);
      //var resizingClip = Utilities.CreateResizingClip(entityBounds);

      //bool canZoneMove = isZone && movingClip.Contains(e.Location);
      //bool canZoneResize = isZone && !canZoneMove && resizingClip.Contains(e.Location);

      //bool canLayoutMove = isLayout && movingClip.Contains(e.Location);
      //bool canLayoutResize = isLayout && !canLayoutMove && resizingClip.Contains(e.Location);

      //bool canMove = canZoneMove;
      //bool canResize = !canMove && (canZoneResize || canLayoutResize);



      //// Cursor
      //if (canMove)
      //  Cursor.Current = Cursors.Hand;

      //else if (canResize)
      //  Cursor.Current = Cursors.SizeAll; 

      //else
      //  Cursor.Current = Cursors.Default;



      //// Moving, resizing
      //if (isZone) {
      //  var zone = (Zone.Entity) this.CurrentSelection;

      //  if (canZoneMove && this.IsDragging) {
      //    zone.Location = new(1, 1);
      //  }
      //}
    }



    private void Canvas_Layout_MouseLeave(object sender, EventArgs e) {
      Cursor.Current = Cursors.Default;
      this.IsDragging = false;
    }
  }
}
