
namespace LayoutDesigner {
  partial class Main {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && ( components != null )) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
      this.MenuStrip = new System.Windows.Forms.MenuStrip();
      this.ToolStripMenuItemFile = new System.Windows.Forms.ToolStripMenuItem();
      this.ToolStripMenuItem_New = new System.Windows.Forms.ToolStripMenuItem();
      this.ToolStripMenuItem_Import = new System.Windows.Forms.ToolStripMenuItem();
      this.ToolStripComboBox_ImportableLayoutNames = new System.Windows.Forms.ToolStripComboBox();
      this.ToolStripMenuItem_Close = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
      this.ToolStripMenuItem_Export = new System.Windows.Forms.ToolStripMenuItem();
      this.ToolStripMenuItem_ExportAs = new System.Windows.Forms.ToolStripMenuItem();
      this.ToolStripMenuItem_Rename = new System.Windows.Forms.ToolStripMenuItem();
      this.ToolStripMenuItem_Delete = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.ToolStripMenuItem_OpenInFileExplorer = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
      this.ToolStripMenuItem_Exit = new System.Windows.Forms.ToolStripMenuItem();
      this.MenuStrip.SuspendLayout();
      this.SuspendLayout();
      // 
      // MenuStrip
      // 
      this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemFile});
      this.MenuStrip.Location = new System.Drawing.Point(0, 0);
      this.MenuStrip.Name = "MenuStrip";
      this.MenuStrip.Size = new System.Drawing.Size(1250, 24);
      this.MenuStrip.TabIndex = 1;
      // 
      // ToolStripMenuItemFile
      // 
      this.ToolStripMenuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_New,
            this.ToolStripMenuItem_Import,
            this.ToolStripMenuItem_Close,
            this.toolStripSeparator2,
            this.ToolStripMenuItem_Export,
            this.ToolStripMenuItem_ExportAs,
            this.ToolStripMenuItem_Rename,
            this.ToolStripMenuItem_Delete,
            this.toolStripSeparator1,
            this.ToolStripMenuItem_OpenInFileExplorer,
            this.toolStripSeparator3,
            this.ToolStripMenuItem_Exit});
      this.ToolStripMenuItemFile.Name = "ToolStripMenuItemFile";
      this.ToolStripMenuItemFile.Size = new System.Drawing.Size(57, 20);
      this.ToolStripMenuItemFile.Text = "Soubor";
      // 
      // ToolStripMenuItem_New
      // 
      this.ToolStripMenuItem_New.Name = "ToolStripMenuItem_New";
      this.ToolStripMenuItem_New.Size = new System.Drawing.Size(297, 22);
      this.ToolStripMenuItem_New.Text = "Nový";
      this.ToolStripMenuItem_New.Click += new System.EventHandler(this.ToolStripMenuItem_New_Click);
      // 
      // ToolStripMenuItem_Import
      // 
      this.ToolStripMenuItem_Import.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripComboBox_ImportableLayoutNames});
      this.ToolStripMenuItem_Import.Name = "ToolStripMenuItem_Import";
      this.ToolStripMenuItem_Import.Size = new System.Drawing.Size(297, 22);
      this.ToolStripMenuItem_Import.Text = "Importovat";
      // 
      // ToolStripComboBox_ExistingLayouts
      // 
      this.ToolStripComboBox_ImportableLayoutNames.DropDownWidth = 200;
      this.ToolStripComboBox_ImportableLayoutNames.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.ToolStripComboBox_ImportableLayoutNames.Name = "ToolStripComboBox_ExistingLayouts";
      this.ToolStripComboBox_ImportableLayoutNames.Size = new System.Drawing.Size(200, 23);
      // 
      // ToolStripMenuItem_Close
      // 
      this.ToolStripMenuItem_Close.Name = "ToolStripMenuItem_Close";
      this.ToolStripMenuItem_Close.Size = new System.Drawing.Size(297, 22);
      this.ToolStripMenuItem_Close.Text = "Zavřít";
      this.ToolStripMenuItem_Close.Click += new System.EventHandler(this.ToolStripMenuItem_Close_Click);
      // 
      // toolStripSeparator2
      // 
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      this.toolStripSeparator2.Size = new System.Drawing.Size(294, 6);
      // 
      // ToolStripMenuItem_Export
      // 
      this.ToolStripMenuItem_Export.Name = "ToolStripMenuItem_Export";
      this.ToolStripMenuItem_Export.Size = new System.Drawing.Size(297, 22);
      this.ToolStripMenuItem_Export.Text = "Exportovat";
      this.ToolStripMenuItem_Export.Click += new System.EventHandler(this.ToolStripMenuItem_Export_Click);
      // 
      // ToolStripMenuItem_ExportAs
      // 
      this.ToolStripMenuItem_ExportAs.Name = "ToolStripMenuItem_ExportAs";
      this.ToolStripMenuItem_ExportAs.Size = new System.Drawing.Size(297, 22);
      this.ToolStripMenuItem_ExportAs.Text = "Exportovat jako...";
      this.ToolStripMenuItem_ExportAs.Click += new System.EventHandler(this.ToolStripMenuItem_ExportAs_Click);
      // 
      // ToolStripMenuItem_Rename
      // 
      this.ToolStripMenuItem_Rename.Name = "ToolStripMenuItem_Rename";
      this.ToolStripMenuItem_Rename.Size = new System.Drawing.Size(297, 22);
      this.ToolStripMenuItem_Rename.Text = "Přejmenovat...";
      this.ToolStripMenuItem_Rename.Click += new System.EventHandler(this.ToolStripMenuItem_Rename_Click);
      // 
      // ToolStripMenuItem_Delete
      // 
      this.ToolStripMenuItem_Delete.Name = "ToolStripMenuItem_Delete";
      this.ToolStripMenuItem_Delete.Size = new System.Drawing.Size(297, 22);
      this.ToolStripMenuItem_Delete.Text = "Odstranit";
      this.ToolStripMenuItem_Delete.Click += new System.EventHandler(this.ToolStripMenuItem_Delete_Click);
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new System.Drawing.Size(294, 6);
      // 
      // ToolStripMenuItem_OpenInFileExplorer
      // 
      this.ToolStripMenuItem_OpenInFileExplorer.Name = "ToolStripMenuItem_OpenInFileExplorer";
      this.ToolStripMenuItem_OpenInFileExplorer.Size = new System.Drawing.Size(297, 22);
      this.ToolStripMenuItem_OpenInFileExplorer.Text = "Všechna rozvržení v průzkumníku souborů";
      this.ToolStripMenuItem_OpenInFileExplorer.Click += new System.EventHandler(this.ToolStripMenuItem_OpenInFileExplorer_Click);
      // 
      // toolStripSeparator3
      // 
      this.toolStripSeparator3.Name = "toolStripSeparator3";
      this.toolStripSeparator3.Size = new System.Drawing.Size(294, 6);
      // 
      // ToolStripMenuItem_Exit
      // 
      this.ToolStripMenuItem_Exit.Name = "ToolStripMenuItem_Exit";
      this.ToolStripMenuItem_Exit.Size = new System.Drawing.Size(297, 22);
      this.ToolStripMenuItem_Exit.Text = "Ukončit";
      this.ToolStripMenuItem_Exit.Click += new System.EventHandler(this.ToolStripMenuItem_Exit_Click);
      // 
      // Main
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1250, 587);
      this.Controls.Add(this.MenuStrip);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MainMenuStrip = this.MenuStrip;
      this.Name = "Main";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "(unset)";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
      this.ResizeEnd += new System.EventHandler(this.Main_ResizeEnd);
      this.MenuStrip.ResumeLayout(false);
      this.MenuStrip.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.MenuStrip MenuStrip;
    private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemFile;
    private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_New;
    private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Import;
    private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Export;
    private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_ExportAs;
    private System.Windows.Forms.ToolStripComboBox ToolStripComboBox_ImportableLayoutNames;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_OpenInFileExplorer;
    private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Delete;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Rename;
    private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Close;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Exit;
  }
}

