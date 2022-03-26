using System.Linq;



namespace LayoutDesigner {
  public partial class Main {
    private void UpdateTitle() {
      if (CurrentLayout != null) {
        Text = $"{ TITLE_BASE } - { CurrentLayout.Name } ({( Core.Layout.State.IsUpToDate(CurrentLayout) ? "uloženo" : "neuloženo" )})";
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



    private void UpdateSaveControl_Enabled() {
      if (CurrentLayout != null) {
        MenuItem_Save.Enabled = !Core.Layout.State.IsUpToDate(CurrentLayout);
      } else {
        MenuItem_Save.Enabled = false;
      }
    }



    private void UpdateSaveAsControl_Enabled() {
      MenuItem_SaveAs.Enabled = CurrentLayout != null;
    }



    private void UpdateRenameControl_Enabled() {
      MenuItem_Rename.Enabled = CurrentLayout != null;
    }



    private void UpdateDeleteControl_Enabled() {
      MenuItem_Delete.Enabled = CurrentLayout != null && Core.Layout.FileSystem.Exists(CurrentLayout.Name);
    }



    private void UpdateState() {
      UpdateTitle();
      UpdateOpenControl_Enabled();
      UpdateCloseControl_Enabled();
      UpdateSaveControl_Enabled();
      UpdateSaveAsControl_Enabled();
      UpdateRenameControl_Enabled();
      UpdateDeleteControl_Enabled();

      // Post-hooks
      CurrentLayoutChangedHandler();
      CurrentSelectionChangedHandler();
    }
  }
}
