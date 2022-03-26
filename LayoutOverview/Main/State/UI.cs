using System.Linq;



namespace LayoutOverview {
  public partial class Main {
    private void UpdateTitle() {
      if (CurrentLayout != null) {
        Text = $"{ TITLE_BASE } - { CurrentLayout.Name }";
      } else {
        Text = $"{ TITLE_BASE }";
      }
    }



    private void UpdateOpenControl_Enabled() {
      MenuItem_Open.Enabled = Core.Layout.FileSystem.GetValidNames().Count() > 0;
    }



    private void UpdateCloseControl_Enabled() {
      MenuItem_Close.Enabled = CurrentLayout != null;
    }



    private void UpdateState() {
      UpdateTitle();
      UpdateOpenControl_Enabled();
      UpdateCloseControl_Enabled();

      // Post-hooks
      CurrentLayoutChangedHandler();
      CurrentSelectionChangedHandler();
    }
  }
}
