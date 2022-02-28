using System.Linq;



namespace LayoutOverview {
  public partial class Main {
    private void UpdateTitle() {
      if (this.CurrentLayout != null) {
        this.Text = $"{ TITLE_BASE } - { this.CurrentLayout.Name }";
      } else {
        this.Text = $"{ TITLE_BASE }";
      }
    }



    private void UpdateOpenControl_Enabled() {
      MenuItem_Open.Enabled = Core.Layout.FileSystem.GetValidNames().Count() > 0;
    }



    private void UpdateCloseControl_Enabled() {
      MenuItem_Close.Enabled = this.CurrentLayout != null;
    }



    private void UpdateState() {
      this.UpdateTitle();
      this.UpdateOpenControl_Enabled();
      this.UpdateCloseControl_Enabled();

      // Post-hooks
      this.CurrentLayoutChangedHandler();
      this.CurrentSelectionChangedHandler();
    }
  }
}
