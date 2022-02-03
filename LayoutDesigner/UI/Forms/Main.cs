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
    private const string NewLayoutDefaultName = "Nové rozvržení";
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



    // State
    private void Update_ToolStripMenuItem_Save_Enabled() {
      this.ToolStripMenuItem_Save.Enabled = this.CurrentLayout != null && !this.IsLayoutSaved();
    }

    private void Update_ToolStripMenuItem_SaveAs_Enabled() {
      this.ToolStripMenuItem_SaveAs.Enabled = this.CurrentLayout != null;
    }

    private void Update_ToolStripMenuItem_Open_Enabled() {
      ToolStripMenuItem_Open.Enabled = this.ExistingLayoutsNames.Count() > 0;
    }

    private void Update_ToolStripMenuItem_Delete_Enabled() {
      this.ToolStripMenuItem_Delete.Enabled = this.CurrentLayout != null;
    }

    private void Update_ToolStrip_Items_Enabled() {
      this.Update_ToolStripMenuItem_Save_Enabled();
      this.Update_ToolStripMenuItem_SaveAs_Enabled();
      this.Update_ToolStripMenuItem_Open_Enabled();
      this.Update_ToolStripMenuItem_Delete_Enabled();
    }

    private void Update_ToolStripComboBox_ExistingLayouts_ComboBox_DataSource() {
      string selectedValue = (string) this.ToolStripComboBox_ExistingLayouts.ComboBox.SelectedValue;
      this.ToolStripComboBox_ExistingLayouts.ComboBox.DataSource = ExistingLayoutsNames;
      int foundIndex = ExistingLayoutsNames.FindIndex(value => value == selectedValue);
      this.ToolStripComboBox_ExistingLayouts.ComboBox.SelectedIndex = foundIndex == -1 ? 0 : foundIndex;
    }



    // Layout data
    private Layout CurrentLayout = null;
    private string CurrentLayout_LatestSaveHash = "";

    private List<string> ExistingLayoutsNames {
      get => LayoutManager.GetExistingLayoutsNames().Prepend(ExistingLayoutSelectBelow).ToList();
    }



    // Layout IO
    private void UnloadCurrentLayout() {
      // Unload only if layout loaded
      if (this.CurrentLayout != null) {
        // If not saved ask user if he wants to save
        if (!this.IsLayoutSaved()) {
          var dialogResult = MessageBox.Show("Rozvržení není uloženo. Přejete si ho uložit?", "Pozor!", MessageBoxButtons.YesNo);

          if (dialogResult == DialogResult.Yes) {
            this.Save();
          }
        }

        this.ToolStripComboBox_ExistingLayouts.SelectedIndex = 0;
        this.ChangeCurrentLayout(null);

        this.Update_ToolStrip_Items_Enabled();
        this.UpdateTitle(false);
      }
    }

    private void CreateNewLayout() {
      this.UnloadCurrentLayout();

      this.ChangeCurrentLayout(new(NewLayoutDefaultName, new(10, 10)), true);

      this.Update_ToolStrip_Items_Enabled();
      this.UpdateTitle(false);
    }

    private void TryLoadExistingLayout(string existingLayoutName) {
      try {
        this.ChangeCurrentLayout(Core.Storage.Layout.Import(existingLayoutName));

        this.Update_ToolStrip_Items_Enabled();
        this.UpdateTitle(true);
      } catch (System.Xml.XmlException) {
        MessageBox.Show($"Při načítání rozvržení \"{ existingLayoutName }\" nastala chyba. Pravděpodobně je soubor neplatný nebo poškozený.", "Chyba!");
        this.UnloadCurrentLayout();
      }
    }

    private void SaveBase() {
      this.CurrentLayout.Export();
      CurrentLayout_LatestSaveHash = this.ComputeCurrentLayoutHash();

      this.Update_ToolStrip_Items_Enabled();
      this.UpdateTitle(true);
      this.Update_ToolStripComboBox_ExistingLayouts_ComboBox_DataSource();
    }

    private void Save() {
      // Save if layout opened
      if (this.CurrentLayout != null) {
        // Save if not saved
        if (!IsLayoutSaved()) {
          if (this.CurrentLayout_LatestSaveHash == "") {
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
          Regex regex = new("^[a-zA-Z]$");
          bool alreadyExists = this.ExistingLayoutsNames.Contains(newName);

          if (newName.Trim().Length == 0) {
            MessageBox.Show("Textové pole nesmí být prázdné.");
            return false;
          } else if (regex.IsMatch(newName)) {
            MessageBox.Show("Textové pole smí obsahovat pouze malá nebo velká písmena A-Z.");
            return false;
          } else if (alreadyExists) {
            MessageBox.Show("Tento název se již používá. Zadejte prosím jiný.");
            return false;
          } else {
            return true;
          }
        };

        UserTextInput userTextInput = new(valueValidator, "Zadejte nový název rozvržení");

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
          this.UnloadCurrentLayout();
        }
      }
    }



    // Helpers
    private void ChangeCurrentLayout(Layout layout, bool forceEmptyLayoutHash) {
      // sets current layout and manages layout hash value
      this.CurrentLayout = layout;
      this.CurrentLayout_LatestSaveHash = layout == null || forceEmptyLayoutHash  ? "" : this.ComputeCurrentLayoutHash();
    }

    private void ChangeCurrentLayout(Layout layout) {
      ChangeCurrentLayout(layout, false);
    }

    private bool IsLayoutSaved() {
      return this.ComputeCurrentLayoutHash() == CurrentLayout_LatestSaveHash;
    }

    private string ComputeCurrentLayoutHash() {
      string layoutXmlString = this.CurrentLayout.ToXDocument().ToString(SaveOptions.DisableFormatting);

      using (MD5 md5 = MD5.Create()) {
        return BitConverter.ToString(
          md5.ComputeHash(Encoding.UTF8.GetBytes(layoutXmlString))
        ).Replace("-", String.Empty);
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
      this.CreateNewLayout();
    }

    private void ToolStripComboBox_ExistingLayouts_ComboBox_SelectionChangeCommitted(object sender, EventArgs e) {
      string existingLayoutName = (string) this.ToolStripComboBox_ExistingLayouts.SelectedItem;

      if (existingLayoutName == ExistingLayoutSelectBelow) {
        this.UnloadCurrentLayout();
      } else {
        this.TryLoadExistingLayout(existingLayoutName);
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
      this.UnloadCurrentLayout();
    }

    private void Main_ResizeEnd(object sender, EventArgs e) {

    }
  }
}
