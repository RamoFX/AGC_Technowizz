using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Linq;

using Core.Storage;
using LayoutDesigner.UI.Dialogs;



namespace LayoutDesigner.UI.Forms {

  public partial class Main : Form {
    // Constants
    private const string TitleBase = "Návrhář rozvržení";
    private const string NewLayoutNameBase = "Novy";
    private const string ExistingLayoutSelectBelow = "Vyberte níže...";



    // Layout data
    private Layout CurrentLayout;

    private bool IsLayoutPresent {
      get => this.CurrentLayout != null;
    }

    private List<string> ExistingLayoutsNames {
      get => LayoutManager.GetExistingLayoutsNames().Prepend(ExistingLayoutSelectBelow).ToList();
    }



    // Constructor
    public Main() {
      InitializeComponent();
      this.CurrentLayout = null;

      this.ToolStripComboBox_ExistingLayouts.ComboBox.BindingContext = this.BindingContext;
      this.ToolStripComboBox_ExistingLayouts.ComboBox.DataSource = ExistingLayoutsNames;
      this.ToolStripComboBox_ExistingLayouts.ComboBox.SelectionChangeCommitted += this.ToolStripComboBox_ExistingLayouts_ComboBox_SelectionChangeCommitted;

      this.UpdateControls_Enabled();
      this.UpdateTitle();
    }



    // Layout IO features
    private void Unload(bool force) {
      if (this.IsLayoutPresent) {
        // If not saved ask user if he wants to save
        // If forced then do not ask
        if (!force && !this.CurrentLayout.IsSaveUpToDate()) {
          var dialogResult = MessageBox.Show("Rozvržení není uloženo. Přejete si ho uložit?", "Pozor!", MessageBoxButtons.YesNo);

          if (dialogResult == DialogResult.Yes) {
            this.Save();
          }
        }

        // Unload
        this.CurrentLayout = null;

        // Post-hooks
        this.ToolStripComboBox_ExistingLayouts.SelectedIndex = 0;
        this.UpdateControls_Enabled();
        this.UpdateTitle();
      }
    }

    private void Unload() {
      this.Unload(false);
    }

    private void New() {
      // Pre-hooks
      this.Unload();

      // Create new layout
      this.CurrentLayout = new(LayoutManager.GenerateNewLayoutUniqueName(NewLayoutNameBase), new(10, 10));

      // Post-hooks
      this.UpdateControls_Enabled();
      this.UpdateTitle();
    }

    private void Open(string name) {
      // May be invalid file
      try {
        this.CurrentLayout = Core.Storage.Layout.Import(name);

        // Post-hooks
        this.UpdateControls_Enabled();
        this.UpdateTitle();
      } catch (System.Xml.XmlException) {
        MessageBox.Show($"Při načítání rozvržení \"{ name }\" nastala chyba. Pravděpodobně je soubor neplatný nebo poškozený.", "Chyba!");
      }
    }

    private void SaveBase() {
      this.CurrentLayout.Export();

      this.UpdateControls_Enabled();
      this.UpdateTitle();
      this.UpdateExistingLayouts_DataSource();
    }

    private void Save() {
      if (this.IsLayoutPresent) {
        // Save if not saved
        if (!this.CurrentLayout.IsSaveUpToDate()) {
          if (this.CurrentLayout.IsSaved()) {
            // New file
            this.SaveAs();
          } else {
            this.SaveBase();
          }
        }
      }
    }

    private void SaveAs() {
      // Save if layout opened
      if (this.IsLayoutPresent) {
        Func<string, bool> valueValidator = newName => {
          newName = newName.Trim();
          Regex regex = new(@"^[a-zA-Z][a-zA-Z0-9 ]*[a-zA-Z0-9]$");

          if (newName.Length == 0) {
            MessageBox.Show("Textové pole nesmí být prázdné.");
            return false;
          } else if (!regex.IsMatch(newName)) {
            MessageBox.Show("Textové pole smí obsahovat pouze malá nebo velká písmena A-Z, čísla a mezery. První musí být písmeno. Nesmí začínat nebo končit mezerou.");
            return false;
          } else if (LayoutManager.IsNameAlreadyTaken(newName)) {
            MessageBox.Show("Tento název se již používá. Zadejte prosím jiný.");
            return false;
          } else {
            return true;
          }
        };

        UserTextInput userTextInput = new(valueValidator, "Nový název rozvržení");

        userTextInput.ShowDialog(this);

        if (userTextInput.DialogResult == DialogResult.OK) {
          this.CurrentLayout.Name = userTextInput.FinalValue;

          SaveBase();
        }
      }
    }

    private void Delete() {
      // Delete if layout opened
      if (this.IsLayoutPresent) {
        // Ask if user is sure
        var dialogResult = MessageBox.Show($"Rozvržení \"{ this.CurrentLayout.Name }\" bude odstraněno a tuto operaci nebude možné vrátit zpět. Pokračovat?", "Jste si jistí?", MessageBoxButtons.YesNo);

        if (dialogResult == DialogResult.Yes) {
          File.Delete(this.CurrentLayout.GetPath());

          this.Unload(true);
          this.UpdateExistingLayouts_DataSource();
        }
      }
    }



    // State
    private void UpdateTitle() {
      if (this.IsLayoutPresent) {
        this.Text = $"{ TitleBase } - { this.CurrentLayout.Name } ({( this.CurrentLayout.IsSaveUpToDate() ? "uloženo" : "neuloženo" )})";
      } else {
        this.Text = $"{ TitleBase }";
      }
    }

    private void UpdateOpenControl_Enabled() {
      ToolStripMenuItem_Open.Enabled = this.ExistingLayoutsNames.Count() > 0;
    }

    private void UpdateSaveControl_Enabled() {
      bool isEnabled;

      if (!this.IsLayoutPresent) {
        isEnabled = false;
      } else {
        isEnabled = !this.CurrentLayout.IsSaveUpToDate();
      }

      this.ToolStripMenuItem_Save.Enabled = isEnabled;
    }

    private void UpdateSaveAsControl_Enabled() {
      this.ToolStripMenuItem_SaveAs.Enabled = this.IsLayoutPresent;
    }

    private void UpdateDeleteControl_Enabled() {
      this.ToolStripMenuItem_Delete.Enabled = this.IsLayoutPresent;
    }

    private void UpdateControls_Enabled() {
      this.UpdateOpenControl_Enabled();
      this.UpdateSaveControl_Enabled();
      this.UpdateSaveAsControl_Enabled();
      this.UpdateDeleteControl_Enabled();
    }

    private void UpdateExistingLayouts_DataSource() {
      string selectedValue = (string) this.ToolStripComboBox_ExistingLayouts.ComboBox.SelectedValue;
      this.ToolStripComboBox_ExistingLayouts.ComboBox.DataSource = ExistingLayoutsNames;
      int foundIndex = ExistingLayoutsNames.FindIndex(value => value == selectedValue);
      this.ToolStripComboBox_ExistingLayouts.ComboBox.SelectedIndex = foundIndex == -1 ? 0 : foundIndex;
    }



    // Events
    private void ToolStripMenuItem_New_Click(object sender, EventArgs e) {
      this.New();
    }

    private void ToolStripComboBox_ExistingLayouts_ComboBox_SelectionChangeCommitted(object sender, EventArgs e) {
      string existingLayoutName = (string) this.ToolStripComboBox_ExistingLayouts.SelectedItem;

      if (existingLayoutName == ExistingLayoutSelectBelow) {
        this.Unload();
      } else {
        this.Open(existingLayoutName);
      }
    }

    private void ToolStripMenuItem_Save_Click(object sender, EventArgs e) {
      this.Save();
    }

    private void ToolStripMenuItem_SaveAs_Click(object sender, EventArgs e) {
      this.SaveAs();
    }

    private void ToolStripMenuItem_Delete_Click(object sender, EventArgs e) {
      this.Delete();
    }

    private void ToolStripMenuItem_OpenInFileExplorer_Click(object sender, EventArgs e) {
      if (Directory.Exists(Preferences.LayoutsPath)) {
        Process.Start("explorer.exe", Preferences.LayoutsPath);
      } else {
        MessageBox.Show("Nelze otevřít, rozvržení neexistují. Zkuste nejprve vytvořit nové rozvržení.", "Chyba!");
      }
    }

    private void Main_FormClosing(object sender, FormClosingEventArgs e) {
      this.Unload();
    }

    private void Main_ResizeEnd(object sender, EventArgs e) {

    }
  }
}
