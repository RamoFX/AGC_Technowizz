﻿using System;
using System.Drawing;
using System.Windows.Forms;

using Core;
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

        currentSelection = Utilities.MatchEntity(path, pathSeparator, layout);
      }

      this.SetCurrentSelection(currentSelection);
    }



    private void Tree_Layout_MouseDoubleClick(object sender, MouseEventArgs e) {
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



    private void Properties_CurrentSelection_Enter(object sender, EventArgs e) {
      // Lose focus (shouldn't be editable)
      this.Properties_CurrentSelection.Enabled = false;
      this.Properties_CurrentSelection.Enabled = true;

      if (this.CurrentLayout == null || this.CurrentSelection == null)
        return;
      
      // Edit matched entity
      bool isZone = this.CurrentSelection.GetType().ToString() == "Core.Zone+Entity";
      bool isLayout = this.CurrentSelection.GetType().ToString() == "Core.Layout+Entity";

      if (isZone) {
        var zone = (Zone.Entity) this.CurrentSelection;
        this.EditZone(zone);
      } else if (isLayout) {
        this.EditLayout();
      }
    }



    private void Canvas_Layout_Paint(object sender, PaintEventArgs e) {
      // Remove previous paintings
      e.Graphics.Clear(this.Canvas_Layout.BackColor);

      // Continue is layout present
      if (this.CurrentLayout == null)
        return;

      // Update unit size
      this.CurrentUnitSize = Utilities.ComputeOptimalUnitSize(
        DynamicSettings.UnitSize.Value.ToInt(),
        SplitContainer_Vertical.Panel2.Size,
        this.CurrentLayout.Size
      );
      
      // Resize canvas
      this.Canvas_Layout.Size = this.CurrentLayout.Size.Scale(this.CurrentUnitSize) + new Size(StaticSettings.OUTLINE_SIZE / 2, StaticSettings.OUTLINE_SIZE / 2);

      // Draw
      Drawer.DrawLayout(e.Graphics, e.ClipRectangle, this.CurrentUnitSize, this.CurrentLayout, this.CurrentSelection, false);
    }
  }
}
