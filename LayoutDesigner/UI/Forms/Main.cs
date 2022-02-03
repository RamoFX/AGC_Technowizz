using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

using Core.Storage;
using LayoutDesigner.UI.Dialogs;



namespace LayoutDesigner.UI.Forms {

  public partial class Main : Form {
    // Title
    private const string TitleBase = "Návrhář rozložení";

    private void UpdateTitle(string layoutName, bool isSaved) {
      if (layoutName.Length > 0) {
        this.Text = $"{ TitleBase } - { layoutName } ({( isSaved ? "uloženo" : "neuloženo" )})";
      } else {
        this.Text = $"{ TitleBase }";
      }
    }

    private void UpdateTitle() {
      if (this.CurrentLayout == null) {
        this.UpdateTitle("", false);
      } else {
        this.UpdateTitle(this.CurrentLayout.Name, this.IsLayoutSaved());
      }
    }




    // Layout properties
    private Layout _CurrentLayout = null;
    private int counter = 0;

    private Layout CurrentLayout {
      get => _CurrentLayout;
      set {
        _CurrentLayout = value;
        this.label1.Text = $"({ counter }) saved == { this.IsLayoutSaved() }";
        this.label2.Text = $"({ counter }) layout == { this.CurrentLayout != null }";
        this.counter++;
      }
    }

    private string CurrentLayout_LatestSaveHash = "";

    private const string NewLayoutDefaultName = "Nové rozvržení";



    // Layout IO
    private void UnloadCurrentLayout() {
      if (!this.IsLayoutSaved()) {
        var dialogResult = MessageBox.Show("Návrh rozložení není uložen. Přejete si ho uložit?", "Pozor!", MessageBoxButtons.YesNo);

        if (dialogResult == DialogResult.Yes) {
          this.Save();
        }
      }

      CurrentLayout = null;
      CurrentLayout_LatestSaveHash = "";
      this.UpdateTitle();
    }

    private void CreateNewLayout() {
      this.CurrentLayout = new(NewLayoutDefaultName, new(10, 10));
      this.UpdateTitle();
    }

    private void TryLoadExistingLayout() {
      string layoutName = "";

      try {
        this.CurrentLayout = Core.Storage.Layout.Import(layoutName);
        this.CurrentLayout_LatestSaveHash = this.ComputeLayoutHash();

        this.UpdateTitle(layoutName, true);
      } catch (System.Xml.XmlException) {
        MessageBox.Show($"Při načítání rozložehí \"{ layoutName }\" nastala chyba. Pravděpodobně je soubor neplatný nebo poškozený.", "Chyba!");
        this.UnloadCurrentLayout();
      }
    }



    // Layout modifying
    private void Save() {
      // Save if not saved
      if (!IsLayoutSaved()) {
        if (this.CurrentLayout_LatestSaveHash == "") {
          // New file
          this.SaveAs();
        } else {
          // Standard saving
          this.CurrentLayout.Export();
          CurrentLayout_LatestSaveHash = ComputeLayoutHash();
        }
      }
    }

    private void SaveAs() {
      NewName newName = new();
      var dialogResult = newName.ShowDialog(this);

      if (newName.DialogResult == DialogResult.OK) {
        Layout newLayout = new(this.CurrentLayout);
        newLayout.Name = newName.FinalName;
        newLayout.Export();

        this.UpdateTitle();
      }
    }



    // Layout modifying helpers
    private bool IsLayoutSaved() {
      return this.ComputeLayoutHash() == CurrentLayout_LatestSaveHash;
    }

    private string ComputeLayoutHash() {
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
      this.CreateNewLayout();
    }

    private void ToolStripMenuItem_New_Click(object sender, EventArgs e) {
      this.CreateNewLayout();
    }

    private void ToolStripMenuItem_Open_Click(object sender, EventArgs e) {
      this.TryLoadExistingLayout();
    }

    private void ToolStripMenuItem_Save_Click(object sender, EventArgs e) {
      this.Save();
    }

    private void ToolStripMenuItem_SaveAs_Click(object sender, EventArgs e) {
      this.SaveAs();
    }

    private void Main_FormClosing(object sender, FormClosingEventArgs e) {
      this.UnloadCurrentLayout();
    }

    private void Main_ResizeEnd(object sender, EventArgs e) {

    }
  }
}
