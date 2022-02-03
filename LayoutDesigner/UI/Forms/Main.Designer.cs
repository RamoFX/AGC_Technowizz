
namespace LayoutDesigner.UI.Forms {
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
      this.souborToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.ToolStripMenuItem_New = new System.Windows.Forms.ToolStripMenuItem();
      this.ToolStripMenuItem_Open = new System.Windows.Forms.ToolStripMenuItem();
      this.ToolStripComboBox_ExistingLayouts = new System.Windows.Forms.ToolStripComboBox();
      this.ToolStripMenuItem_Save = new System.Windows.Forms.ToolStripMenuItem();
      this.ToolStripMenuItem_SaveAs = new System.Windows.Forms.ToolStripMenuItem();
      this.ToolStripMenuItem_Delete = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.ToolStripMenuItem_OpenInFileExplorer = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
      this.MenuStrip.SuspendLayout();
      this.SuspendLayout();
      // 
      // MenuStrip
      // 
      this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.souborToolStripMenuItem});
      this.MenuStrip.Location = new System.Drawing.Point(0, 0);
      this.MenuStrip.Name = "MenuStrip";
      this.MenuStrip.Size = new System.Drawing.Size(1250, 24);
      this.MenuStrip.TabIndex = 1;
      // 
      // souborToolStripMenuItem
      // 
      this.souborToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_New,
            this.ToolStripMenuItem_Open,
            this.toolStripSeparator2,
            this.ToolStripMenuItem_Save,
            this.ToolStripMenuItem_SaveAs,
            this.ToolStripMenuItem_Delete,
            this.toolStripSeparator1,
            this.ToolStripMenuItem_OpenInFileExplorer});
      this.souborToolStripMenuItem.Name = "souborToolStripMenuItem";
      this.souborToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
      this.souborToolStripMenuItem.Text = "Soubor";
      // 
      // ToolStripMenuItem_New
      // 
      this.ToolStripMenuItem_New.Name = "ToolStripMenuItem_New";
      this.ToolStripMenuItem_New.Size = new System.Drawing.Size(297, 22);
      this.ToolStripMenuItem_New.Text = "Nový";
      this.ToolStripMenuItem_New.Click += new System.EventHandler(this.ToolStripMenuItem_New_Click);
      // 
      // ToolStripMenuItem_Open
      // 
      this.ToolStripMenuItem_Open.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripComboBox_ExistingLayouts});
      this.ToolStripMenuItem_Open.Name = "ToolStripMenuItem_Open";
      this.ToolStripMenuItem_Open.Size = new System.Drawing.Size(297, 22);
      this.ToolStripMenuItem_Open.Text = "Otevřít";
      // 
      // ToolStripComboBox_ExistingLayouts
      // 
      this.ToolStripComboBox_ExistingLayouts.Name = "ToolStripComboBox_ExistingLayouts";
      this.ToolStripComboBox_ExistingLayouts.Size = new System.Drawing.Size(121, 23);
      // 
      // ToolStripMenuItem_Save
      // 
      this.ToolStripMenuItem_Save.Name = "ToolStripMenuItem_Save";
      this.ToolStripMenuItem_Save.Size = new System.Drawing.Size(297, 22);
      this.ToolStripMenuItem_Save.Text = "Uložit";
      this.ToolStripMenuItem_Save.Click += new System.EventHandler(this.ToolStripMenuItem_Save_Click);
      // 
      // ToolStripMenuItem_SaveAs
      // 
      this.ToolStripMenuItem_SaveAs.Name = "ToolStripMenuItem_SaveAs";
      this.ToolStripMenuItem_SaveAs.Size = new System.Drawing.Size(297, 22);
      this.ToolStripMenuItem_SaveAs.Text = "Uložit jako...";
      this.ToolStripMenuItem_SaveAs.Click += new System.EventHandler(this.ToolStripMenuItem_SaveAs_Click);
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
      // toolStripSeparator2
      // 
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      this.toolStripSeparator2.Size = new System.Drawing.Size(294, 6);
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
    private System.Windows.Forms.ToolStripMenuItem souborToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_New;
    private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Open;
    private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Save;
    private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_SaveAs;
    private System.Windows.Forms.ToolStripComboBox ToolStripComboBox_ExistingLayouts;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_OpenInFileExplorer;
    private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Delete;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
  }
}

