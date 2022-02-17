using System.Linq;
using System.Windows.Forms;
using System.Xml;
using Core;
using Core.UI;
using Core.UI.Dialogs;



namespace LayoutDesigner {
  public partial class Main {
    // Layout
    private void UnloadLayout(bool force) {
      if (this.CurrentLayout == null)
        return;

      // If not saved ask user if he wants to save
      // If forced then do not ask
      bool isUpToDate = Core.Layout.State.IsUpToDate(this.CurrentLayout);

      if (!force && !isUpToDate) {
        var dialogResult = MessageBoxes.SaveUnsavedLayout();

        if (dialogResult == DialogResult.Yes) {
          this.SaveLayout();
        }
      }

      // Unload
      this.CurrentLayout = null;
      this.CurrentSelection = null;

      // Post-hooks
      this.UpdateState();
    }

    private void UnloadLayout() {
      this.UnloadLayout(false);
    }

    private void NewLayout() {
      // Pre-hooks
      this.UnloadLayout();

      // Setup new object
      ObjectEditor newLayout = this.NewLayoutPrompt();

      if (newLayout.DialogResult != DialogResult.OK)
        return;

      // Post-hooks
      this.SetCurrentLayout((Core.Layout.Entity) newLayout.FinalValue);
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

    private void SaveLayout() {
      if (this.CurrentLayout == null)
        return;

      // Save if not saved
      if (Core.Layout.State.IsUpToDate(this.CurrentLayout))
        return;

      Core.Layout.FileSystem.Export(this.CurrentLayout);

      // Post-hooks
      this.UpdateState();
    }

    private void SaveLayoutAs() {
      // Save if layout present
      if (this.CurrentLayout == null)
        return;

      var userTextInput = this.TextPrompt();

      if (userTextInput.DialogResult != DialogResult.OK)
        return;

      Core.Layout.FileSystem.ExportAs(this.CurrentLayout, userTextInput.FinalValue);

      // Post-hooks
      this.UpdateState();
    }

    private void RenameLayout() {
      // Rename if layout present
      if (this.CurrentLayout == null)
        return;

      var userTextInput = this.TextPrompt();

      if (userTextInput.DialogResult != DialogResult.OK)
        return;

      Core.Layout.FileSystem.Rename(this.CurrentLayout, userTextInput.FinalValue);

      // Post-hooks
      this.UpdateState();
    }

    private void EditLayout() {
      var otherNames = Core.Layout.FileSystem.GetFilesNames().Where(someName => someName != this.CurrentLayout.Name);
      var layoutEditor = this.LayoutEditorPrompt("Upravit rozložení", this.CurrentLayout, otherNames);

      if (layoutEditor.DialogResult != DialogResult.OK)
        return;

      var editedLayout = (Layout.Entity) layoutEditor.FinalValue;

      // Handle name change
      if (this.CurrentLayout.Name != editedLayout.Name)
        Core.Layout.FileSystem.Move(this.CurrentLayout.Name, editedLayout.Name);

      this.CurrentLayout.Change(editedLayout);

      // Post-hooks
      this.UpdateState();
    }

    private void DeleteLayout() {
      // Delete if layout present
      if (this.CurrentLayout == null)
        return;

      // Ask if user is sure
      var dialogResult = MessageBoxes.DeleteConfirmation();

      if (dialogResult != DialogResult.Yes)
        return;

      Core.Layout.FileSystem.Delete(this.CurrentLayout.Name);

      // Post-hooks
      this.UnloadLayout(true);
      this.UpdateState();
    }



    // Zone
    private void NewZone() {
      if (this.CurrentLayout == null)
        return;

      bool layoutHasAvailableArea = this.CurrentLayout.Area > this.CurrentLayout.Area_Zones;

      if (!layoutHasAvailableArea) {
        MessageBoxes.AreaFull();
      } else {
        ObjectEditor newZone = NewZonePrompt();

        if (newZone.DialogResult != DialogResult.OK)
          return;

        this.CurrentLayout.Add((Core.Zone.Entity) newZone.FinalValue);

        // Post-hooks
        this.UpdateState();
      }
    }

    private void EditZone(Zone.Entity targetZone) {
      var otherZones = this.CurrentLayout.Zones.Where(someZone => someZone.Name != targetZone.Name);
      var zoneEditor = this.ZoneEditorPrompt("Upravit zónu", targetZone, otherZones);

      if (zoneEditor.DialogResult != DialogResult.OK)
        return;

      var editedZone = (Zone.Entity) zoneEditor.FinalValue;

      targetZone.Change(editedZone);
    }

    private void DeleteZone(Zone.Entity zone, bool doForce) {
      if (!doForce) {
        var dialogResult = MessageBoxes.DeleteConfirmation();

        if (dialogResult != DialogResult.Yes)
          return;
      }

      this.CurrentLayout.Zones.Remove(zone);

      // Post-hooks
      this.UpdateState();
    }

    private void DeleteZone() {
      if (this.CurrentLayout == null)
        return;

      if (this.CurrentLayout.Zones.Count() == 0)
        return;

      ListSelection zoneSelect = SelectionPrompt(this.CurrentLayout.Zones, "Name", "Vyberte zónu");

      if (zoneSelect.DialogResult != DialogResult.OK)
        return;

      var zone = (Core.Zone.Entity) zoneSelect.FinalValue;

      this.DeleteZone(zone, true);
    }
  }
}
