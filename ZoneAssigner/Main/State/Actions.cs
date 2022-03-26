using Core;



namespace ZoneAssigner {
  public partial class Main {
    private void SetCurrentLayout(Layout.Entity layout) {
      CurrentLayout = layout;

      if (CurrentLayout != null) {
        CurrentLayout.Initialize(DAYS_PERIOD);
      }

      // Post-hooks
      UpdateState();
    }



    private void SetCurrentSelection(object target) {
      // Change and fire handler only if not same
      if (CurrentSelection == target)
        return;

      CurrentSelection = target;

      // Label
      if (target == null)
        ZoneName.Text = "";

      else if (target.GetType().ToString() == "Core.Zone+Entity")
        ZoneName.Text = ( (Zone.Entity) target ).Name;

      // Post-hooks
      CurrentSelectionChangedHandler();
    }
  }
}
