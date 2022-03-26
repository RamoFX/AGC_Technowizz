using Core;
using Core.Settings;



namespace LayoutOverview {
  public partial class Main {
    // Entities
    private Layout.Entity CurrentLayout = null;
    private object CurrentSelection = null;

    // Drawing
    private int CurrentUnitSize = DynamicSettings.UnitSize.Value.ToInt();
  }
}
