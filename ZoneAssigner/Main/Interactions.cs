using System.Windows.Forms;
using Core.UI;
using Core.UI.Dialogs;



namespace ZoneAssigner {
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



    private void EvalueatePalletCode() {
      if (CurrentLayout == null)
        return;

      // Evaluation
      string palletCode = TextField_PalletCode.Text.Trim();

      // Validation
      bool isEmpty = palletCode.Length == 0;

      if (isEmpty) {
        MessageBoxes.TextValueCannotBeEmpty();
        SetCurrentSelection(null);
        return;
      }

      // Matching zone
      string carBrand = Communicator.DatabaseAccess.GetCarBrandName(CurrentLayout.WarehouseName, palletCode);
      bool isCarBrandEmpty = carBrand.Length == 0;

      if (isCarBrandEmpty) {
        MessageBoxes.CarBrandNotLoadable();
        SetCurrentSelection(null);
        return;
      }

      var zone = CurrentLayout.GetFirstSuitableZoneOrDefault(carBrand);

      if (zone == default) {
        MessageBoxes.NoSpace();
        SetCurrentSelection(null);
        return;
      }

      // Post-hooks
      SetCurrentSelection(zone);
      UpdateState();
    }
  }
}
