using System.Linq;
using System.Windows.Forms;

using Core;
using Core.UI;
using Core.UI.Dialogs;



namespace LayoutDesigner {
  public partial class Main {
    // Layout
    private void UnloadLayout(bool force) {
      if (CurrentLayout == null)
        return;

      // If not saved ask user if he wants to save
      // If forced then do not ask
      bool isUpToDate = Core.Layout.State.IsUpToDate(CurrentLayout);

      if (!force && !isUpToDate) {
        var dialogResult = MessageBoxes.SaveUnsavedLayout();

        if (dialogResult == DialogResult.Yes) {
          SaveLayout();
        }
      }

      // Unload
      CurrentLayout = null;
      CurrentSelection = null;

      // Post-hooks
      UpdateState();
    }

    private void UnloadLayout() {
      UnloadLayout(false);
    }

    private void NewLayout() {
      // Pre-hooks
      UnloadLayout();

      // Setup new object
      ObjectEditor newLayout = NewLayoutPrompt();

      if (newLayout.DialogResult != DialogResult.OK)
        return;

      // Post-hooks
      SetCurrentLayout((Layout.Entity) newLayout.FinalValue);
      SetCurrentSelection(CurrentLayout);
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

    private void SaveLayout() {
      if (CurrentLayout == null)
        return;

      // Save if not saved
      if (Core.Layout.State.IsUpToDate(CurrentLayout))
        return;

      Core.Layout.FileSystem.Export(CurrentLayout);

      // Post-hooks
      UpdateState();
    }

    private void SaveLayoutAs() {
      // Save if layout present
      if (CurrentLayout == null)
        return;

      string currentName = CurrentLayout.Name;
      var userTextInput = TextPrompt(currentName);

      if (userTextInput.DialogResult != DialogResult.OK)
        return;

      Core.Layout.FileSystem.ExportAs(CurrentLayout, userTextInput.FinalValue);

      // Post-hooks
      UpdateState();
    }

    private void RenameLayout(string newName) {
      // Rename if layout present
      if (CurrentLayout == null)
        return;

      // Changes
      Core.Layout.FileSystem.Rename(CurrentLayout, newName);

      // Post-hooks
      SetCurrentSelection(CurrentLayout);
      UpdateState();
    }

    private void RenameLayout() {
      // Rename if layout present
      if (CurrentLayout == null)
        return;

      // Preparation
      string currentName = CurrentLayout.Name;

      // Dialog
      var userTextInput = TextPrompt(currentName);

      if (userTextInput.DialogResult != DialogResult.OK)
        return;

      RenameLayout(userTextInput.FinalValue);
    }

    private void EditLayout() {
      if (CurrentLayout == null)
        return;

      // Preparation
      var otherNames = Core.Layout.FileSystem.GetFilesNames().Where(someName => someName != CurrentLayout.Name);
      Layout.Entity layoutEditTarget = new(CurrentLayout);

      // Dialog
      var layoutEditor = LayoutEditorPrompt("Upravit rozložení", layoutEditTarget, otherNames);

      if (layoutEditor.DialogResult != DialogResult.OK)
        return;

      // Handle changes
      var editedLayout = (Layout.Entity) layoutEditor.FinalValue;

      // Handle name change
      if (CurrentLayout.Name != editedLayout.Name)
        RenameLayout(editedLayout.Name);

      CurrentLayout.Change(editedLayout);

      // Post-hooks
      SetCurrentSelection(CurrentLayout);
      UpdateState();
    }

    private void DeleteLayout() {
      // Delete if layout present
      if (CurrentLayout == null)
        return;

      // Ask if user is sure
      var dialogResult = MessageBoxes.DeleteConfirmation();

      if (dialogResult != DialogResult.Yes)
        return;

      Core.Layout.FileSystem.Delete(CurrentLayout.Name);

      // Post-hooks
      UnloadLayout(true);
      UpdateState();
    }



    // Zone
    private Zone.Entity NewZone(Zone.Entity initialZone) {
      if (CurrentLayout == null)
        return null;

      bool layoutHasAvailableArea = CurrentLayout.Area > CurrentLayout.Area_Zones;

      if (!layoutHasAvailableArea) {
        MessageBoxes.AreaFull();
        return null;
      }

      ObjectEditor newZone = NewZonePrompt(initialZone);

      if (newZone.DialogResult != DialogResult.OK)
        return null;

      CurrentLayout.Add((Zone.Entity) newZone.FinalValue);

      // Post-hooks
      SetCurrentSelection(newZone.FinalValue);
      UpdateState();

      return (Zone.Entity) newZone.FinalValue;
    }

    private void EditZone(Zone.Entity zone) {
      if (CurrentLayout == null)
        return;

      // Preparation
      var otherZones = CurrentLayout.Zones.Where(someZone => someZone != zone);
      Zone.Entity zoneEditTarget = new(zone);

      // Dialog
      var zoneEditor = ZoneEditorPrompt("Upravit zónu", zoneEditTarget, otherZones);

      if (zoneEditor.DialogResult != DialogResult.OK)
        return;

      // Handle changes
      var editedZone = (Zone.Entity) zoneEditor.FinalValue;

      zone.Change(editedZone);

      // Post-hooks
      UpdateState();
    }

    private void DeleteZone(Zone.Entity zone, bool doForce) {
      if (!doForce) {
        var dialogResult = MessageBoxes.DeleteConfirmation();

        if (dialogResult != DialogResult.Yes)
          return;
      }

      CurrentLayout.Zones.Remove(zone);

      // Post-hooks
      UpdateState();
      SetCurrentSelection(null);
    }
  }
}
