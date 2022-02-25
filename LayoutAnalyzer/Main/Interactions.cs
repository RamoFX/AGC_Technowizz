using System.Windows.Forms;

using Core.UI.Dialogs;



namespace LayoutOverview {
  public partial class Main {
    private void UnloadLayout() {
      if (this.CurrentLayout == null)
        return;

      // Unload
      this.CurrentLayout = null;
      this.CurrentSelection = null;

      // Post-hooks
      this.UpdateState();
    }



    private void OpenLayout(string layoutName) {
      Core.Layout.Entity layout = Core.Layout.FileSystem.Import(layoutName);
      this.SetCurrentLayout(layout);
    }



    private void OpenLayout() {
      ListSelection selectLayoutName = SelectionPrompt(Core.Layout.FileSystem.GetValidNames(), "Vyberte rozložení");

      if (selectLayoutName.DialogResult != DialogResult.OK)
        return;

      string layoutName = (string) selectLayoutName.FinalValue;

      this.OpenLayout(layoutName);
    }
  }
}
