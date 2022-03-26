using System.Drawing;

using Core;
using Core.Settings;



namespace LayoutDesigner {
  public partial class Main {
    // Entities
    private Layout.Entity CurrentLayout = null;
    private object CurrentSelection = null;

    // Drawing
    private int CurrentUnitSize = DynamicSettings.UnitSize.Value.ToInt();

    // Zone creation
    private bool IsCreatingZone = false;

    private Point DragStart = new(0, 0);
    private Point DragEnd = new(0, 0);
  }
}
