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

      Point unscaled = new Point(e.X, e.Y).Unscale(StaticSettings.UNIT_SIZE);

      Zone.Entity targetZone = this.CurrentLayout.Zones.FirstOrDefault(zone => zone.Rectangle.Contains(unscaled));

      bool isTargetZone = targetZone != default;
      bool isTargetLayout = targetZone == default && this.CurrentLayout.Rectangle.Contains(unscaled);

      if (isTargetZone)
        this.SetCurrentSelection(targetZone);

      else if (isTargetLayout)
        this.SetCurrentSelection(this.CurrentLayout);

    }

    private void PictureBox_Layout_MouseDoubleClick(object sender, MouseEventArgs e) {
      if (this.CurrentSelection == null)
        return;



      bool isLeft = e.Button == MouseButtons.Left;
      bool isRight = e.Button == MouseButtons.Right;

      // Actual selection detection
      string selectionType = this.CurrentSelection.GetType().ToString();

      bool isTargetZone = selectionType == "Core.Zone+Entity";
      bool isTargetLayout = !isTargetZone && selectionType == "Core.Layout+Entity";



      // No target - no business
      if (!isTargetZone && !isTargetLayout)
        return;



      // Zone
      if (isTargetZone) {
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
      
      // Edit layout
      else if (isLeft && isTargetLayout) {
        this.EditLayout();
      }

      // Post-hooks
      this.UpdateState();
    }

    private void PictureBox_Layout_MouseDown(object sender, MouseEventArgs e) {
      this.IsDragging = true;
    }

    private void PictureBox_Layout_MouseUp(object sender, MouseEventArgs e) {
      this.IsDragging = false;
    }

    private void PictureBox_Layout_MouseMove(object sender, MouseEventArgs e) {
      
    }

    private void PictureBox_Layout_MouseLeave(object sender, EventArgs e) {
      Cursor.Current = Cursors.Default;
      this.IsDragging = false;
    }
  }
}
