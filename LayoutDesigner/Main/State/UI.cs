using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Core;
using Core.Extensions;
using Core.Settings;
using Core.UI;
using Core.UI.Dialogs;



namespace LayoutDesigner {
  public partial class Main {
    private void UpdateTitle() {
      if (this.IsLayoutPresent) {
        this.Text = $"{ TITLE_BASE } - { this.CurrentLayout.Name } ({(this.CurrentLayout.IsCorrespondingFileUpToDate() ? "uloženo" : "neuloženo")})";
      } else {
        this.Text = $"{ TITLE_BASE }";
      }
    }

    private void UpdateOpenControl_Enabled() {
      MenuItem_Open.Enabled = this.ValidLayoutNames.Count() > 0;
    }

    private void UpdateCloseControl_Enabled() {
      MenuItem_Close.Enabled = this.IsLayoutPresent;
    }

    private void UpdateSaveControl_Enabled() {
      if (this.IsLayoutPresent) {
        this.MenuItem_Save.Enabled = !this.CurrentLayout.IsCorrespondingFileUpToDate();
      } else {
        this.MenuItem_Save.Enabled = false;
      }
    }

    private void UpdateSaveAsControl_Enabled() {
      this.MenuItem_SaveAs.Enabled = this.IsLayoutPresent;
    }

    private void UpdateRenameControl_Enabled() {
      this.MenuItem_Rename.Enabled = this.IsLayoutPresent;
    }

    private void UpdateDeleteControl_Enabled() {
      this.MenuItem_Delete.Enabled = this.IsLayoutPresent && this.CurrentLayout.HasValidCorrespondingFile();
    }

    private void UpdateNewZoneControl_Enabled() {
      this.MenuItem_NewZone.Enabled = this.IsLayoutPresent;
    }

    private void UpdateRemoveZoneControl_Enabled() {
      this.MenuItem_RemoveZone.Enabled = this.IsLayoutPresent && this.CurrentLayout.Zones.Count > 0;
    }

    private void UpdateState() {
      this.UpdateTitle();
      this.UpdateOpenControl_Enabled();
      this.UpdateCloseControl_Enabled();
      this.UpdateSaveControl_Enabled();
      this.UpdateSaveAsControl_Enabled();
      this.UpdateRenameControl_Enabled();
      this.UpdateDeleteControl_Enabled();
      this.UpdateNewZoneControl_Enabled();
      this.UpdateRemoveZoneControl_Enabled();

      // Post-hooks
      this.CurrentLayoutChangedHandler();
      this.CurrentSelectionChangedHandler();
    }
  }
}
