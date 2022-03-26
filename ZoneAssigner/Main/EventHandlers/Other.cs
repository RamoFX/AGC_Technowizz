using System.Drawing;
using System.Windows.Forms;
using Core.Settings;
using Core.UI;



namespace ZoneAssigner {
  public partial class Main {
    private void Canvas_Layout_Paint(object sender, PaintEventArgs e) {
      // Remove previous paintings
      e.Graphics.Clear(Canvas_Layout.BackColor);

      // Continue is layout present
      if (CurrentLayout == null)
        return;

      // Update unit size
      CurrentUnitSize = Utilities.ComputeOptimalUnitSize(
        DynamicSettings.UnitSize.Value.ToInt(),
        Panel_CanvasWrapper.Size,
        CurrentLayout.Size
      );

      // Resize canvas
      Canvas_Layout.Size = CurrentLayout.Size.Scale(CurrentUnitSize) + new Size(StaticSettings.OUTLINE_SIZE / 2, StaticSettings.OUTLINE_SIZE / 2);

      // Draw
      Drawer.DrawLayout(e.Graphics, e.ClipRectangle, CurrentUnitSize, CurrentLayout, CurrentSelection, true);
    }
  }
}
