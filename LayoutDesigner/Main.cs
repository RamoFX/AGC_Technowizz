using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

using Core;
using Core.Storage;
using Core.UI;
using Core.UI.Dialogs;



namespace LayoutDesigner {

  public partial class Main : Form {
    // Constants
    private const string TitleBase = "Návrhář rozvržení";
    private const string SelectBelow = "Vyberte níže...";



    // Layout data
    private Layout CurrentLayout;

    private bool IsLayoutPresent {
      get => this.CurrentLayout != null;
    }

    private List<string> ImportableLayoutsNames {
      get => LayoutManager.GetExistingLayoutNames().Prepend(SelectBelow).ToList();
    }



    // Constructor
    public Main() {
      InitializeComponent();
      this.ToolStripComboBox_ImportableLayoutNames.ComboBox.BindingContext = this.BindingContext;
      this.ToolStripComboBox_ImportableLayoutNames.ComboBox.SelectionChangeCommitted += this.ToolStripComboBox_ImportableLayoutNames_ComboBox_SelectionChangeCommitted;
      this.CurrentLayout = null;
      this.UpdateState();
    }



    // Layout file system IO interactions
    private void Unload(bool force) {
      if (this.IsLayoutPresent) {
        // If not saved ask user if he wants to save
        // If forced then do not ask
        if (!force && !this.CurrentLayout.IsCorrespondingFileUpToDate()) {
          var dialogResult = MessageBoxes.SaveUnsavedLayoutConfirmation();

          if (dialogResult == DialogResult.Yes) {
            this.Export();
          }
        }

        // Unload
        this.CurrentLayout = null;

        // Post-hooks
        this.UpdateState();
      }
    }

    private void Unload() {
      this.Unload(false);
    }

    private void New() {
      // Ask for new name
      var userTextInput = this.GetNewName();

      if (userTextInput.DialogResult == DialogResult.OK) {
        // Pre-hooks
        this.Unload();

        // Create new layout
        this.CurrentLayout = new(userTextInput.FinalValue, new(10, 10));

        // Post-hooks
        this.UpdateState();
      }
    }

    private void Import(string name) {
      // May be invalid file
      try {
        this.CurrentLayout = Core.Storage.Layout.Import(name);

        // Post-hooks
        this.UpdateState();
      } catch (System.Xml.XmlException) {
        MessageBoxes.LayoutInvalid(name);
      }
    }

    private void Export() {
      if (this.IsLayoutPresent) {
        // Save if not saved
        if (!this.CurrentLayout.IsCorrespondingFileUpToDate()) {
          this.CurrentLayout.Export();

          // Post-hooks
          this.UpdateState();
        }
      }
    }

    private void ExportAs() {
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

    private void Rename() {
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

    private void Delete() {
      // Delete if layout opened
      if (this.IsLayoutPresent) {
        // Ask if user is sure
        var dialogResult = MessageBoxes.UndoableDeletionConfirmation(this.CurrentLayout.Name);

        if (dialogResult == DialogResult.Yes) {
          this.CurrentLayout.Delete();

          // Post-hooks
          this.Unload(true);
          this.UpdateState();
        }
      }
    }



    // User interaction
    private UserTextInput GetNewName() {
      Func<string, bool> valueValidator = newName => {
        newName = newName.Trim();
        char[] invalidFileNameChars = Path.GetInvalidFileNameChars();

        bool isEmpty = newName.Length == 0;
        bool newNameContainsInvalidChars = newName.ToCharArray().Any(newNameChar => invalidFileNameChars.Contains(newNameChar));
        bool nameAlreadyTaken = LayoutManager.IsNameAlreadyTaken(newName);

        if (isEmpty) {
          MessageBoxes.TextFieldCannotBeEmpty();
          return false;
        } else if (newNameContainsInvalidChars) {
          MessageBoxes.TextFieldCannotContainInvalidChars();
          return false;
        } else if (nameAlreadyTaken) {
          MessageBoxes.LayoutNameAlreadyExist();
          return false;
        } else {
          return true;
        }
      };

      UserTextInput userTextInput = new(valueValidator, "Nový název rozvržení");

      userTextInput.ShowDialog(this);

      return userTextInput;
    }



    // State
    private void UpdateTitle() {
      if (this.IsLayoutPresent) {
        this.Text = $"{ TitleBase } - { this.CurrentLayout.Name } ({( this.CurrentLayout.IsCorrespondingFileUpToDate() ? "uloženo" : "neuloženo" )})";
      } else {
        this.Text = $"{ TitleBase }";
      }
    }

    private void UpdateImportControl_Enabled() {
      ToolStripMenuItem_Import.Enabled = this.ImportableLayoutsNames.Count() > 0;
    }

    private void UpdateCloseControl_Enabled() {
      ToolStripMenuItem_Close.Enabled = this.IsLayoutPresent;
    }

    private void UpdateExportControl_Enabled() {
      if (this.IsLayoutPresent) {
        this.ToolStripMenuItem_Export.Enabled = !this.CurrentLayout.IsCorrespondingFileUpToDate();
      } else {
        this.ToolStripMenuItem_Export.Enabled = false;
      }
    }

    private void UpdateExportAsControl_Enabled() {
      this.ToolStripMenuItem_ExportAs.Enabled = this.IsLayoutPresent;
    }

    private void UpdateRenameControl_Enabled() {
      this.ToolStripMenuItem_Rename.Enabled = this.IsLayoutPresent;
    }

    private void UpdateDeleteControl_Enabled() {
      this.ToolStripMenuItem_Delete.Enabled = this.IsLayoutPresent && this.CurrentLayout.HasValidCorrespondingFile();
    }

    private void UpdateExistingLayouts_DataSource() {
      this.ToolStripComboBox_ImportableLayoutNames.ComboBox.DataSource = ImportableLayoutsNames;

      if (this.IsLayoutPresent) {
        int index = ImportableLayoutsNames.FindIndex(value => value == this.CurrentLayout.Name);
        this.ToolStripComboBox_ImportableLayoutNames.ComboBox.SelectedIndex = index == -1 ? 0 : index;
      } else {
        this.ToolStripComboBox_ImportableLayoutNames.ComboBox.SelectedIndex = 0;
      }
    }

    private void UpdateState() {
      this.UpdateTitle();
      this.UpdateImportControl_Enabled();
      this.UpdateCloseControl_Enabled();
      this.UpdateExportControl_Enabled();
      this.UpdateExportAsControl_Enabled();
      this.UpdateRenameControl_Enabled();
      this.UpdateDeleteControl_Enabled();
      this.UpdateExistingLayouts_DataSource();
    }



    // Events
    private void ToolStripMenuItem_New_Click(object sender, EventArgs e) {
      this.New();
    }

    private void ToolStripComboBox_ImportableLayoutNames_ComboBox_SelectionChangeCommitted(object sender, EventArgs e) {
      string existingLayoutName = (string) this.ToolStripComboBox_ImportableLayoutNames.SelectedItem;

      if (!(existingLayoutName == SelectBelow)) {
        this.Import(existingLayoutName);
      }
    }

    private void ToolStripMenuItem_Close_Click(object sender, EventArgs e) {
      this.Unload();
    }

    private void ToolStripMenuItem_Export_Click(object sender, EventArgs e) {
      this.Export();
    }

    private void ToolStripMenuItem_ExportAs_Click(object sender, EventArgs e) {
      this.ExportAs();
    }

    private void ToolStripMenuItem_Rename_Click(object sender, EventArgs e) {
      this.Rename();
    }

    private void ToolStripMenuItem_Delete_Click(object sender, EventArgs e) {
      this.Delete();
    }

    private void ToolStripMenuItem_OpenInFileExplorer_Click(object sender, EventArgs e) {
      if (Directory.Exists(StaticSettings.LayoutsPath)) {
        Process.Start("explorer.exe", StaticSettings.LayoutsPath);
      } else {
        MessageBoxes.NoLayoutsExist();
      }
    }

    private void ToolStripMenuItem_Exit_Click(object sender, EventArgs e) {
      this.Close();
    }

    private void Main_FormClosing(object sender, FormClosingEventArgs e) {
      this.Unload();
    }

    private void Main_ResizeEnd(object sender, EventArgs e) {

    }
  }
}
