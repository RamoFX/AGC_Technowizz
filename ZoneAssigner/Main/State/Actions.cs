using Core;



namespace ZoneAssigner {
  public partial class Main {
    private void SetCurrentLayout(Layout.Entity layout) {
      this.CurrentLayout = layout;

      if (this.CurrentLayout != null) {
        this.CurrentLayout.Initialize(DAYS_PERIOD);
      }

      // Post-hooks
      this.UpdateState();
    }



    private void SetCurrentSelection(object target) {
      // Change and fire handler only if not same
      if (this.CurrentSelection == target)
        return;

      this.CurrentSelection = target;

      // Label
      if (target == null)
        this.ZoneName.Text = "";

      else if (target.GetType().ToString() == "Core.Zone+Entity")
        this.ZoneName.Text = ((Zone.Entity) target).Name;

      // Post-hooks
      this.CurrentSelectionChangedHandler();
    }
  }
}
