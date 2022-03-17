using System.Windows.Forms;
using Core.UI;
using Core.UI.Dialogs;



namespace ZoneAssigner {
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



    private void EvalueatePalletCode() {
      if (this.CurrentLayout == null)
        return;

      // Evaluation
      string palletCode = this.TextField_PalletCode.Text.Trim();

      // Validation
      bool isEmpty = palletCode.Length == 0;

      if (isEmpty) {
        MessageBoxes.TextValueCannotBeEmpty();
        this.SetCurrentSelection(null);
        return;
      }

      // Matching zone
      string carBrand = Communicator.DatabaseAccess.GetCarBrandName(this.CurrentLayout.WarehouseName, palletCode);
      bool isCarBrandEmpty = carBrand.Length == 0;

      if (isCarBrandEmpty) {
        MessageBoxes.CarBrandNotLoadable();
        this.SetCurrentSelection(null);
        return;
      }

      var zone = this.CurrentLayout.GetFirstSuitableZoneOrDefault(carBrand);

      if (zone == default) {
        MessageBoxes.NoSpace();
        this.SetCurrentSelection(null);
        return;
      }

      // Post-hooks
      this.SetCurrentSelection(zone);
      this.UpdateState();
    }
  }
}
