using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace LayoutDesigner {
  public partial class Main {
    // Layout
    private void UnloadLayout(bool force) {
      if (!this.IsLayoutPresent) {
        return;
      }

      // If not saved ask user if he wants to save
      // If forced then do not ask
      if (!force && !Core.Layout.) {
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
      UserNewObject newLayout = this.CreateNewLayout();

      if (newLayout.DialogResult == DialogResult.OK) {
        // Post-hooks
        this.SetCurrentLayout((Layout) newLayout.FinalValue);
      }
    }

    private void OpenLayout(string layoutName) {
      Layout layout = Core.Entities.Entity.Import(layoutName);
      this.SetCurrentLayout(layout);
    }

    private void OpenLayout() {
      UserSelect selectLayoutName = GetSelect(LayoutManager.GetValidLayoutNames(), "Vyberte rozvržení");

      if (selectLayoutName.DialogResult == DialogResult.OK) {
        string layoutName = (string) selectLayoutName.FinalValue;

        this.OpenLayout(layoutName);
      }
    }

    private void SaveLayout() {
      if (this.IsLayoutPresent) {
        // Save if not saved
        if (!this.CurrentLayout.IsCorrespondingFileUpToDate()) {
          this.CurrentLayout.Export();

          // Post-hooks
          this.UpdateState();
        }
      }
    }

    private void SaveLayoutAs() {
      // Save if layout present
      if (this.IsLayoutPresent) {
        var userTextInput = this.GetNewName();

        if (userTextInput.DialogResult == DialogResult.OK) {
          this.CurrentLayout.ExportAs(userTextInput.FinalValue);

          // Post-hooks
          this.UpdateState();
        }
      }
    }

    private void RenameLayout() {
      // Rename if layout present
      if (this.IsLayoutPresent) {
        var userTextInput = this.GetNewName();

        if (userTextInput.DialogResult == DialogResult.OK) {
          this.CurrentLayout.Rename(userTextInput.FinalValue);

          // Post-hooks
          this.UpdateState();
        }
      }
    }

    private void DeleteLayout() {
      // Delete if layout opened
      if (this.IsLayoutPresent) {
        // Ask if user is sure
        var dialogResult = MessageBoxes.UndoableDeletion(this.CurrentLayout.Name);

        if (dialogResult == DialogResult.Yes) {
          this.CurrentLayout.Delete();

          // Post-hooks
          this.UnloadLayout(true);
          this.UpdateState();
        }
      }
    }



    // Zone
    private void NewZone() {
      if (this.IsLayoutPresent) {
        bool layoutHasAvailableArea = this.CurrentLayout.Area > this.CurrentLayout.Area_Zones;

        if (!layoutHasAvailableArea) {
          MessageBoxes.AreaFull();
        } else {
          UserNewObject newZone = CreateNewZone();

          if (newZone.DialogResult == DialogResult.OK) {
            this.CurrentLayout.Add((Core.Entities.Entity) newZone.FinalValue);

            // Post-hooks
            this.UpdateState();
          }
        }
      }
    }

    private void DeleteZone() {
      if (this.IsLayoutPresent && this.CurrentLayout.Zones.Count > 0) {
        UserSelect zoneSelect = GetSelect(this.CurrentLayout.Zones, "Name", "Vyberte zónu");

        if (zoneSelect.DialogResult == DialogResult.OK) {
          Core.Entities.Entity zone = (Core.Entities.Entity) zoneSelect.FinalValue;

          this.CurrentLayout.Zones.Remove(zone);

          // Post-hooks
          this.UpdateState();
        }
      }
    }
  }
}
