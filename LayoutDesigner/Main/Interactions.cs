using System;
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
      this.SetCurrentLayout((Layout.Entity) newLayout.FinalValue);
      this.SetCurrentSelection(this.CurrentLayout);
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

      string currentName = this.CurrentLayout.Name;
      var userTextInput = this.TextPrompt(currentName);

      if (userTextInput.DialogResult != DialogResult.OK)
        return;

      Core.Layout.FileSystem.ExportAs(this.CurrentLayout, userTextInput.FinalValue);

      // Post-hooks
      this.UpdateState();
    }

    private void RenameLayout(string newName) {
      // Rename if layout present
      if (this.CurrentLayout == null)
        return;

      // Changes
      Core.Layout.FileSystem.Rename(this.CurrentLayout, newName);

      // Post-hooks
      this.SetCurrentSelection(this.CurrentLayout);
      this.UpdateState();
    }

    private void RenameLayout() {
      // Rename if layout present
      if (this.CurrentLayout == null)
        return;

      // Preparation
      string currentName = this.CurrentLayout.Name;

      // Dialog
      var userTextInput = this.TextPrompt(currentName);

      if (userTextInput.DialogResult != DialogResult.OK)
        return;

      this.RenameLayout(userTextInput.FinalValue);
    }

    private void EditLayout() {
      if (this.CurrentLayout == null)
        return;

      // Preparation
      var otherNames = Core.Layout.FileSystem.GetFilesNames().Where(someName => someName != this.CurrentLayout.Name);
      Layout.Entity layoutEditTarget = new(this.CurrentLayout);

      // Dialog
      var layoutEditor = this.LayoutEditorPrompt("Upravit rozložení", layoutEditTarget, otherNames);

      if (layoutEditor.DialogResult != DialogResult.OK)
        return;

      // Handle changes
      var editedLayout = (Layout.Entity) layoutEditor.FinalValue;

      // Handle name change
      if (this.CurrentLayout.Name != editedLayout.Name)
        this.RenameLayout(editedLayout.Name);

      this.CurrentLayout.Change(editedLayout);

      // Post-hooks
      this.SetCurrentSelection(this.CurrentLayout);
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
    private void NewZone(Zone.Entity initialZone) {
      if (this.CurrentLayout == null)
        return;

      bool layoutHasAvailableArea = this.CurrentLayout.Area > this.CurrentLayout.Area_Zones;

      if (!layoutHasAvailableArea) {
        MessageBoxes.AreaFull();
        return;
      }

      ObjectEditor newZone = NewZonePrompt(initialZone);

      if (newZone.DialogResult != DialogResult.OK)
        return;

      this.CurrentLayout.Add((Zone.Entity) newZone.FinalValue);

      // Post-hooks
      this.SetCurrentSelection(newZone.FinalValue);
      this.UpdateState();
    }

    private void EditZone(Zone.Entity zone) {
      if (this.CurrentLayout == null)
        return;

      // Preparation
      var otherZones = this.CurrentLayout.Zones.Where(someZone => someZone != zone);
      Zone.Entity zoneEditTarget = new(zone);

      // Dialog
      var zoneEditor = this.ZoneEditorPrompt("Upravit zónu", zoneEditTarget, otherZones);

      if (zoneEditor.DialogResult != DialogResult.OK)
        return;

      // Handle changes
      var editedZone = (Zone.Entity) zoneEditor.FinalValue;

      zone.Change(editedZone);

      // Post-hooks
      this.UpdateState();
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
  }
}
