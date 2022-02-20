using System.Linq;



namespace LayoutDesigner {
  public partial class Main {
    private void UpdateTitle() {
      if (this.CurrentLayout != null) {
        this.Text = $"{ TITLE_BASE } - { this.CurrentLayout.Name } ({( Core.Layout.State.IsUpToDate(this.CurrentLayout) ? "uloženo" : "neuloženo" )})";
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



    private void UpdateSaveControl_Enabled() {
      if (this.CurrentLayout != null) {
        this.MenuItem_Save.Enabled = !Core.Layout.State.IsUpToDate(this.CurrentLayout);
      } else {
        this.MenuItem_Save.Enabled = false;
      }
    }



    private void UpdateSaveAsControl_Enabled() {
      this.MenuItem_SaveAs.Enabled = this.CurrentLayout != null;
    }



    private void UpdateRenameControl_Enabled() {
      this.MenuItem_Rename.Enabled = this.CurrentLayout != null;
    }



    private void UpdateDeleteControl_Enabled() {
      this.MenuItem_Delete.Enabled = this.CurrentLayout != null && Core.Layout.FileSystem.Exists(this.CurrentLayout.Name);
    }



    private void UpdateState() {
      this.UpdateTitle();
      this.UpdateOpenControl_Enabled();
      this.UpdateCloseControl_Enabled();
      this.UpdateSaveControl_Enabled();
      this.UpdateSaveAsControl_Enabled();
      this.UpdateRenameControl_Enabled();
      this.UpdateDeleteControl_Enabled();

      // Post-hooks
      this.CurrentLayoutChangedHandler();
      this.CurrentSelectionChangedHandler();
    }
  }
}
