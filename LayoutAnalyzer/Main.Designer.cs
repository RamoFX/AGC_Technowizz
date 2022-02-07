
namespace LayoutAnalyzer {
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
      this.ToolStripMenuItem_File = new System.Windows.Forms.ToolStripMenuItem();
      this.ToolStripMenuItem_Open = new System.Windows.Forms.ToolStripMenuItem();
      this.ToolStripComboBox_ImportableLayoutNames = new System.Windows.Forms.ToolStripComboBox();
      this.ToolStripMenuItem_Close = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
      this.ToolStripMenuItem_OpenInFileExplorer = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
      this.ToolStripMenuItem_Exit = new System.Windows.Forms.ToolStripMenuItem();
      this.TreeView_Layout = new System.Windows.Forms.TreeView();
      this.PictureBox_Layout = new System.Windows.Forms.PictureBox();
      this.statusStrip = new System.Windows.Forms.StatusStrip();
      this.MenuStrip.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.PictureBox_Layout)).BeginInit();
      this.SuspendLayout();
      // 
      // MenuStrip
      // 
      this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_File});
      this.MenuStrip.Location = new System.Drawing.Point(0, 0);
      this.MenuStrip.Name = "MenuStrip";
      this.MenuStrip.Padding = new System.Windows.Forms.Padding(0);
      this.MenuStrip.Size = new System.Drawing.Size(1067, 24);
      this.MenuStrip.TabIndex = 1;
      // 
      // ToolStripMenuItem_File
      // 
      this.ToolStripMenuItem_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_Open,
            this.ToolStripMenuItem_Close,
            this.toolStripSeparator2,
            this.ToolStripMenuItem_OpenInFileExplorer,
            this.toolStripSeparator3,
            this.ToolStripMenuItem_Exit});
      this.ToolStripMenuItem_File.Name = "ToolStripMenuItem_File";
      this.ToolStripMenuItem_File.Size = new System.Drawing.Size(57, 24);
      this.ToolStripMenuItem_File.Text = "Soubor";
      // 
      // ToolStripMenuItem_Open
      // 
      this.ToolStripMenuItem_Open.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.ToolStripMenuItem_Open.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripComboBox_ImportableLayoutNames});
      this.ToolStripMenuItem_Open.Name = "ToolStripMenuItem_Open";
      this.ToolStripMenuItem_Open.Size = new System.Drawing.Size(297, 22);
      this.ToolStripMenuItem_Open.Text = "Otevřít";
      // 
      // ToolStripComboBox_ImportableLayoutNames
      // 
      this.ToolStripComboBox_ImportableLayoutNames.DropDownWidth = 200;
      this.ToolStripComboBox_ImportableLayoutNames.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.ToolStripComboBox_ImportableLayoutNames.Name = "ToolStripComboBox_ImportableLayoutNames";
      this.ToolStripComboBox_ImportableLayoutNames.Size = new System.Drawing.Size(200, 23);
      // 
      // ToolStripMenuItem_Close
      // 
      this.ToolStripMenuItem_Close.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
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
      // ToolStripMenuItem_OpenInFileExplorer
      // 
      this.ToolStripMenuItem_OpenInFileExplorer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
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
      this.ToolStripMenuItem_Exit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.ToolStripMenuItem_Exit.Name = "ToolStripMenuItem_Exit";
      this.ToolStripMenuItem_Exit.Size = new System.Drawing.Size(297, 22);
      this.ToolStripMenuItem_Exit.Text = "Ukončit";
      this.ToolStripMenuItem_Exit.Click += new System.EventHandler(this.ToolStripMenuItem_Exit_Click);
      // 
      // TreeView_Layout
      // 
      this.TreeView_Layout.Location = new System.Drawing.Point(0, 24);
      this.TreeView_Layout.Margin = new System.Windows.Forms.Padding(0);
      this.TreeView_Layout.Name = "TreeView_Layout";
      this.TreeView_Layout.PathSeparator = ".";
      this.TreeView_Layout.ShowNodeToolTips = true;
      this.TreeView_Layout.Size = new System.Drawing.Size(200, 524);
      this.TreeView_Layout.TabIndex = 0;
      // 
      // PictureBox_Layout
      // 
      this.PictureBox_Layout.BackColor = System.Drawing.Color.White;
      this.PictureBox_Layout.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.PictureBox_Layout.ErrorImage = null;
      this.PictureBox_Layout.InitialImage = null;
      this.PictureBox_Layout.Location = new System.Drawing.Point(199, 24);
      this.PictureBox_Layout.Margin = new System.Windows.Forms.Padding(0);
      this.PictureBox_Layout.Name = "PictureBox_Layout";
      this.PictureBox_Layout.Size = new System.Drawing.Size(868, 524);
      this.PictureBox_Layout.TabIndex = 2;
      this.PictureBox_Layout.TabStop = false;
      // 
      // statusStrip
      // 
      this.statusStrip.Location = new System.Drawing.Point(0, 548);
      this.statusStrip.Name = "statusStrip";
      this.statusStrip.Size = new System.Drawing.Size(1067, 22);
      this.statusStrip.TabIndex = 3;
      this.statusStrip.Text = "statusStrip1";
      // 
      // Main
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1067, 570);
      this.Controls.Add(this.statusStrip);
      this.Controls.Add(this.PictureBox_Layout);
      this.Controls.Add(this.TreeView_Layout);
      this.Controls.Add(this.MenuStrip);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MainMenuStrip = this.MenuStrip;
      this.Name = "Main";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "(unset)";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
      this.Load += new System.EventHandler(this.Main_Load);
      this.Paint += new System.Windows.Forms.PaintEventHandler(this.Main_Paint);
      this.Resize += new System.EventHandler(this.Main_Resize);
      this.MenuStrip.ResumeLayout(false);
      this.MenuStrip.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.PictureBox_Layout)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.MenuStrip MenuStrip;
    private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_File;
    private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Open;
    private System.Windows.Forms.ToolStripComboBox ToolStripComboBox_ImportableLayoutNames;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_OpenInFileExplorer;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Exit;
    private System.Windows.Forms.TreeView TreeView_Layout;
    private System.Windows.Forms.PictureBox PictureBox_Layout;
    private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Close;
    private System.Windows.Forms.StatusStrip statusStrip;
  }
}

