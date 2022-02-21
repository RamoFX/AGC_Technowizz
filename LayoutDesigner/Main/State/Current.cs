using Core;
using Core.Settings;

namespace LayoutDesigner {
  public partial class Main {
    // Entities
    private Layout.Entity CurrentLayout = null;
    private object CurrentSelection = null;

    // Drawing
    private int CurrentUnitSize = StaticSettings.UNIT_SIZE;

    // Mouse activity
    private bool IsDragging = false;
  }
}
