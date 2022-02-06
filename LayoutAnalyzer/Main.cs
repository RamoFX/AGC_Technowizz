﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

using Core;
using Core.Storage;
using Core.UI;
using Core.UI.Dialogs;



namespace LayoutAnalyzer {

  public partial class Main : Form {
    // Constants
    private const string TitleBase = "Analýza rozvržení";
    private const string SelectBelow = "Vyberte níže...";



    // Layout data
    private Layout CurrentLayout;

    private bool IsLayoutPresent {
      get => this.CurrentLayout != null;
    }

    private List<string> ImportableLayoutsNames {
      get => LayoutManager.GetExistingLayoutNames().Prepend(SelectBelow).ToList();
    }



    // Form and its Controls data
    private int HeightOffset;



    // Constructor
    public Main() {
      InitializeComponent();
    }



    // Layout file system IO interactions
    private void Unload(bool force) {
      if (this.IsLayoutPresent) {
        // If not saved ask user if he wants to save
        // If forced then do not ask
        if (!force && !this.CurrentLayout.IsCorrespondingFileUpToDate()) {
          var dialogResult = MessageBoxes.SaveUnsavedLayout();

          if (dialogResult == DialogResult.Yes) {
            this.Save();
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

    private void Open(string name) {
      IEnumerable<string> validLayoutNames = LayoutManager.GetValidLayoutNames();

      if (validLayoutNames.Contains(name)) {
        Layout layout = Core.Storage.Layout.Import(name);
        this.SetCurrentLayout(layout);
      } else {
        MessageBoxes.LayoutInvalid(name);
      }
    }

    private void Save() {
      if (this.IsLayoutPresent) {
        // Save if not saved
        if (!this.CurrentLayout.IsCorrespondingFileUpToDate()) {
          this.CurrentLayout.Export();

          // Post-hooks
          this.UpdateState();
        }
      }
    }




    // State
    private void UpdateTitle() {
      if (this.IsLayoutPresent) {
        this.Text = $"{ TitleBase } - { this.CurrentLayout.Name }";
      } else {
        this.Text = $"{ TitleBase }";
      }
    }

    private void UpdateOpenControl_Enabled() {
      ToolStripMenuItem_Open.Enabled = this.ImportableLayoutsNames.Count() > 0;
    }

    private void UpdateCloseControl_Enabled() {
      ToolStripMenuItem_Close.Enabled = this.IsLayoutPresent;
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
      this.UpdateOpenControl_Enabled();
      this.UpdateCloseControl_Enabled();
      this.UpdateExistingLayouts_DataSource();

      // Post-hooks
      this.CurrentLayoutChangedHandler();
    }

    private void SetCurrentLayout(Layout layout) {
      this.CurrentLayout = layout;

      if (this.IsLayoutPresent) {
        this.CurrentLayout.Initialize(false); // TODO: Fix
      }

      // Post-hooks
      this.UpdateState();
    }



    // Visual
    private void DrawLayout() {
      if (this.IsLayoutPresent) {
        Drawer.DrawLayout(this.PictureBox_Layout, this.CurrentLayout, new(SystemInformation.VerticalScrollBarWidth, 0));
      }
    }



    // Handlers
    private void CurrentLayoutChangedHandler() {
      // TreeView
      this.TreeView_Layout.Nodes.Clear();

      if (this.IsLayoutPresent) {
        // Main
        int Main_MinimumWidth = this.CurrentLayout.Size.Width * StaticSettings.UnitSize + this.TreeView_Layout.Width + SystemInformation.VerticalScrollBarWidth;
        int Main_MinimumHeight = this.CurrentLayout.Size.Height * StaticSettings.UnitSize + this.HeightOffset;

        this.MinimumSize = new Size(Main_MinimumWidth, Main_MinimumHeight);

        // TreeView - jednotlivý statistiky
        //var rootNode = TreeView_Layout.Nodes.Add(this.CurrentLayout.Name);

        //foreach (Zone zone in this.CurrentLayout.Zones) {
        //  var zoneNode = rootNode.Nodes.Add(zone.Name);

        //  foreach (CarBrand carBrand in zone.CarBrands) {
        //    zoneNode.Nodes.Add(carBrand.Name);
        //  }
        //}

        this.TreeView_Layout.ExpandAll();

        // Draw
        this.DrawLayout();
      } else {
        // Set current form minimum size
        this.MinimumSize = new Size(TreeView_Layout.Width + SystemInformation.VerticalScrollBarWidth, 256);

        // Clear last drawing
        this.PictureBox_Layout.CreateGraphics().Clear(this.PictureBox_Layout.BackColor);
      }
    }



    // MenuStrip children events
    private void ToolStripComboBox_ImportableLayoutNames_ComboBox_SelectionChangeCommitted(object sender, EventArgs e) {
      string existingLayoutName = (string) this.ToolStripComboBox_ImportableLayoutNames.SelectedItem;

      if (!(existingLayoutName == SelectBelow)) {
        this.Open(existingLayoutName);
      }
    }

    private void ToolStripMenuItem_Close_Click(object sender, EventArgs e) {
      this.Unload();
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



    // Main events
    private void Main_Load(object sender, EventArgs e) {
      this.ToolStripComboBox_ImportableLayoutNames.ComboBox.BindingContext = this.BindingContext;
      this.ToolStripComboBox_ImportableLayoutNames.ComboBox.SelectionChangeCommitted += this.ToolStripComboBox_ImportableLayoutNames_ComboBox_SelectionChangeCommitted;
      this.HeightOffset = this.Height - this.TreeView_Layout.Height;

      // Post-hooks
      this.SetCurrentLayout(null);
      this.UpdateState();
    }

    private void Main_Resize(object sender, EventArgs e) {
      this.TreeView_Layout.Height = this.Height - HeightOffset;

      this.PictureBox_Layout.Width = this.Width - this.TreeView_Layout.Width;
      this.PictureBox_Layout.Height = this.Height - this.HeightOffset;

      this.DrawLayout();
    }

    private void Main_FormClosing(object sender, FormClosingEventArgs e) {
      this.Unload();
    }

    private void Main_Paint(object sender, PaintEventArgs e) {
      this.DrawLayout();
    }
  }
}