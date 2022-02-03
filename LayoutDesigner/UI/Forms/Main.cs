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
    private const string NewLayoutNameBase = "Nové rozvržení";
    private const string ExistingLayoutSelectBelow = "Vyberte níže...";



    // Title
    private void UpdateTitle(bool isSaved) {
      string layoutName = this.CurrentLayout?.Name ?? "";

      if (layoutName.Length > 0) {
        this.Text = $"{ TitleBase } - { layoutName } ({( isSaved ? "uloženo" : "neuloženo" )})";
      } else {
        this.Text = $"{ TitleBase }";
      }
    }



    // Layout data
    private Layout CurrentLayout = null;

    private bool IsLayoutPresent {
      get => this.CurrentLayout != null;
    }

    private List<string> ExistingLayoutsNames {
      get => LayoutManager.GetExistingLayoutsNames().Prepend(ExistingLayoutSelectBelow).ToList();
    }



    // State
    private void Update_ToolStripMenuItem_Open_Enabled() {
      ToolStripMenuItem_Open.Enabled = this.ExistingLayoutsNames.Count() > 0;
    }

    private void Update_ToolStripMenuItem_Save_Enabled() {
      bool isEnabled;

      if (!this.IsLayoutPresent) {
        isEnabled = false;
      } else {
        isEnabled = !this.CurrentLayout.IsSaveUpToDate();
      }

      this.ToolStripMenuItem_Save.Enabled = isEnabled;
    }

    private void Update_ToolStripMenuItem_SaveAs_Enabled() {
      this.ToolStripMenuItem_SaveAs.Enabled = this.IsLayoutPresent;
    }

    private void Update_ToolStripMenuItem_Delete_Enabled() {
      this.ToolStripMenuItem_Delete.Enabled = this.IsLayoutPresent;
    }

    private void Update_ToolStrip_Items_Enabled() {
      this.Update_ToolStripMenuItem_Open_Enabled();
      this.Update_ToolStripMenuItem_Save_Enabled();
      this.Update_ToolStripMenuItem_SaveAs_Enabled();
      this.Update_ToolStripMenuItem_Delete_Enabled();
    }

    private void Update_ToolStripComboBox_ExistingLayouts_ComboBox_DataSource() {
      string selectedValue = (string) this.ToolStripComboBox_ExistingLayouts.ComboBox.SelectedValue;
      this.ToolStripComboBox_ExistingLayouts.ComboBox.DataSource = ExistingLayoutsNames;
      int foundIndex = ExistingLayoutsNames.FindIndex(value => value == selectedValue);
      this.ToolStripComboBox_ExistingLayouts.ComboBox.SelectedIndex = foundIndex == -1 ? 0 : foundIndex;
    }



    // Layout IO features
    private void Unload() {
      if (this.IsLayoutPresent) {
        // If not saved ask user if he wants to save
        if (!this.CurrentLayout.IsSaveUpToDate()) {
          var dialogResult = MessageBox.Show("Rozvržení není uloženo. Přejete si ho uložit?", "Pozor!", MessageBoxButtons.YesNo);

          if (dialogResult == DialogResult.Yes) {
            this.Save();
          }
        }

        // Unload
        this.ToolStripComboBox_ExistingLayouts.SelectedIndex = 0;
        this.CurrentLayout = null;

        // Post-hooks
        this.Update_ToolStrip_Items_Enabled();
        this.UpdateTitle(false);
      }
    }

    private void New() {
      // Pre-hooks
      this.Unload();

      // Create new layout
      this.CurrentLayout = new(LayoutManager.GenerateNewLayoutUniqueName(), new(10, 10));

      // Post-hooks
      this.Update_ToolStrip_Items_Enabled();
      this.UpdateTitle(false);
    }

    private void TryOpen(string existingLayoutName) {
      try {
        // Try load existing layout
        this.CurrentLayout = Core.Storage.Layout.Import(existingLayoutName);

        // Post-hooks
        this.Update_ToolStrip_Items_Enabled();
        this.UpdateTitle(true);
      } catch (System.Xml.XmlException) {
        MessageBox.Show($"Při načítání rozvržení \"{ existingLayoutName }\" nastala chyba. Pravděpodobně je soubor neplatný nebo poškozený.", "Chyba!");
        this.Unload();
      }
    }

    private void SaveBase() {
      this.CurrentLayout.Export();

      this.Update_ToolStrip_Items_Enabled();
      this.UpdateTitle(true);
      this.Update_ToolStripComboBox_ExistingLayouts_ComboBox_DataSource();
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
      if (this.CurrentLayout != null) {
        Func<string, bool> valueValidator = newName => {
          Regex regex = new("^[a-zA-Z]+$");

          if (newName.Trim().Length == 0) {
            MessageBox.Show("Textové pole nesmí být prázdné.");
            return false;
          } else if (!regex.IsMatch(newName)) {
            MessageBox.Show("Textové pole smí obsahovat pouze malá nebo velká písmena A-Z.");
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
      if (this.CurrentLayout != null) {
        string layoutName = this.CurrentLayout.Name;
        string layoutPath = Core.Storage.Layout.GetPath(layoutName);

        // Ask if user is sure
        var dialogResult = MessageBox.Show($"Rozvržení \"{ layoutName }\" bude odstraněno. Pokračovat?", "Jste si jistí?", MessageBoxButtons.YesNo);

        if (dialogResult == DialogResult.Yes) {
          File.Delete(layoutPath);

          this.Update_ToolStripComboBox_ExistingLayouts_ComboBox_DataSource();
          this.Unload();
        }
      }
    }



    // Main UI window
    public Main() {
      InitializeComponent();
      this.Update_ToolStrip_Items_Enabled();

      this.ToolStripComboBox_ExistingLayouts.ComboBox.BindingContext = this.BindingContext;
      this.ToolStripComboBox_ExistingLayouts.ComboBox.DataSource = ExistingLayoutsNames;
      this.ToolStripComboBox_ExistingLayouts.ComboBox.SelectionChangeCommitted += this.ToolStripComboBox_ExistingLayouts_ComboBox_SelectionChangeCommitted;
      this.UpdateTitle(false);
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
        this.TryOpen(existingLayoutName);
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
        MessageBox.Show("Nelze otevřít - rozložení neexistují. Zkuste nejprve vytvořit nové rozložení.", "Chyba!");
      }
    }

    private void Main_FormClosing(object sender, FormClosingEventArgs e) {
      this.Unload();
    }

    private void Main_ResizeEnd(object sender, EventArgs e) {

    }
  }
}
