using Core;



namespace LayoutDesigner {
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

      // Post-hooks
      this.CurrentSelectionChangedHandler();
    }
  }
}
