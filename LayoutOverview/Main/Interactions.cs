using System.Windows.Forms;

using Core.UI.Dialogs;



namespace LayoutOverview {
  public partial class Main {
    private void UnloadLayout() {
      if (CurrentLayout == null)
        return;

      // Unload
      CurrentLayout = null;
      CurrentSelection = null;

      // Post-hooks
      UpdateState();
    }



    private void OpenLayout(string layoutName) {
      Core.Layout.Entity layout = Core.Layout.FileSystem.Import(layoutName);
      SetCurrentLayout(layout);
    }



    private void OpenLayout() {
      ListSelection selectLayoutName = SelectionPrompt(Core.Layout.FileSystem.GetValidNames(), "Vyberte rozložení");

      if (selectLayoutName.DialogResult != DialogResult.OK)
        return;

      string layoutName = (string) selectLayoutName.FinalValue;

      OpenLayout(layoutName);
    }
  }
}
