
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
      this.ToolStripMenuItem_File = new System.Windows.Forms.ToolStripMenuItem();
      this.ToolStripMenuItem_New = new System.Windows.Forms.ToolStripMenuItem();
      this.ToolStripMenuItem_Open = new System.Windows.Forms.ToolStripMenuItem();
      this.ToolStripMenuItem_Close = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
      this.ToolStripMenuItem_Save = new System.Windows.Forms.ToolStripMenuItem();
      this.ToolStripMenuItem_SaveAs = new System.Windows.Forms.ToolStripMenuItem();
      this.ToolStripMenuItem_Rename = new System.Windows.Forms.ToolStripMenuItem();
      this.ToolStripMenuItem_Delete = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.ToolStripMenuItem_OpenInFileExplorer = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
      this.ToolStripMenuItem_Exit = new System.Windows.Forms.ToolStripMenuItem();
      this.ToolStripMenuItem_Layout = new System.Windows.Forms.ToolStripMenuItem();
      this.ToolStripMenuItem_NewZone = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
      this.ToolStripMenuItem_RemoveZone = new System.Windows.Forms.ToolStripMenuItem();
      this.TreeView_Layout = new System.Windows.Forms.TreeView();
      this.PictureBox_Layout = new System.Windows.Forms.PictureBox();
      this.PropertyGrid_CurrentSelection = new System.Windows.Forms.PropertyGrid();
      this.SplitContainer_Horizontal = new System.Windows.Forms.SplitContainer();
      this.SplitContainer_Vertical = new System.Windows.Forms.SplitContainer();
      this.MenuStrip.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.PictureBox_Layout)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.SplitContainer_Horizontal)).BeginInit();
      this.SplitContainer_Horizontal.Panel1.SuspendLayout();
      this.SplitContainer_Horizontal.Panel2.SuspendLayout();
      this.SplitContainer_Horizontal.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.SplitContainer_Vertical)).BeginInit();
      this.SplitContainer_Vertical.Panel1.SuspendLayout();
      this.SplitContainer_Vertical.Panel2.SuspendLayout();
      this.SplitContainer_Vertical.SuspendLayout();
      this.SuspendLayout();
      // 
      // MenuStrip
      // 
      this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_File,
            this.ToolStripMenuItem_Layout});
      this.MenuStrip.Location = new System.Drawing.Point(0, 0);
      this.MenuStrip.Name = "MenuStrip";
      this.MenuStrip.Padding = new System.Windows.Forms.Padding(0);
      this.MenuStrip.Size = new System.Drawing.Size(1241, 24);
      this.MenuStrip.TabIndex = 1;
      // 
      // ToolStripMenuItem_File
      // 
      this.ToolStripMenuItem_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_New,
            this.ToolStripMenuItem_Open,
            this.ToolStripMenuItem_Close,
            this.toolStripSeparator2,
            this.ToolStripMenuItem_Save,
            this.ToolStripMenuItem_SaveAs,
            this.ToolStripMenuItem_Rename,
            this.ToolStripMenuItem_Delete,
            this.toolStripSeparator1,
            this.ToolStripMenuItem_OpenInFileExplorer,
            this.toolStripSeparator3,
            this.ToolStripMenuItem_Exit});
      this.ToolStripMenuItem_File.Name = "ToolStripMenuItem_File";
      this.ToolStripMenuItem_File.Size = new System.Drawing.Size(57, 24);
      this.ToolStripMenuItem_File.Text = "Soubor";
      // 
      // ToolStripMenuItem_New
      // 
      this.ToolStripMenuItem_New.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.ToolStripMenuItem_New.Name = "ToolStripMenuItem_New";
      this.ToolStripMenuItem_New.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
      this.ToolStripMenuItem_New.Size = new System.Drawing.Size(297, 22);
      this.ToolStripMenuItem_New.Text = "Nový...";
      this.ToolStripMenuItem_New.Click += new System.EventHandler(this.ToolStripMenuItem_New_Click);
      // 
      // ToolStripMenuItem_Open
      // 
      this.ToolStripMenuItem_Open.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.ToolStripMenuItem_Open.Name = "ToolStripMenuItem_Open";
      this.ToolStripMenuItem_Open.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
      this.ToolStripMenuItem_Open.Size = new System.Drawing.Size(297, 22);
      this.ToolStripMenuItem_Open.Text = "Otevřít...";
      this.ToolStripMenuItem_Open.Click += new System.EventHandler(this.ToolStripMenuItem_Open_Click);
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
      // ToolStripMenuItem_Save
      // 
      this.ToolStripMenuItem_Save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.ToolStripMenuItem_Save.Name = "ToolStripMenuItem_Save";
      this.ToolStripMenuItem_Save.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
      this.ToolStripMenuItem_Save.Size = new System.Drawing.Size(297, 22);
      this.ToolStripMenuItem_Save.Text = "Uložit";
      this.ToolStripMenuItem_Save.Click += new System.EventHandler(this.ToolStripMenuItem_Save_Click);
      // 
      // ToolStripMenuItem_SaveAs
      // 
      this.ToolStripMenuItem_SaveAs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.ToolStripMenuItem_SaveAs.Name = "ToolStripMenuItem_SaveAs";
      this.ToolStripMenuItem_SaveAs.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
      this.ToolStripMenuItem_SaveAs.Size = new System.Drawing.Size(297, 22);
      this.ToolStripMenuItem_SaveAs.Text = "Uložit jako...";
      this.ToolStripMenuItem_SaveAs.Click += new System.EventHandler(this.ToolStripMenuItem_SaveAs_Click);
      // 
      // ToolStripMenuItem_Rename
      // 
      this.ToolStripMenuItem_Rename.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.ToolStripMenuItem_Rename.Name = "ToolStripMenuItem_Rename";
      this.ToolStripMenuItem_Rename.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
      this.ToolStripMenuItem_Rename.Size = new System.Drawing.Size(297, 22);
      this.ToolStripMenuItem_Rename.Text = "Přejmenovat...";
      this.ToolStripMenuItem_Rename.Click += new System.EventHandler(this.ToolStripMenuItem_Rename_Click);
      // 
      // ToolStripMenuItem_Delete
      // 
      this.ToolStripMenuItem_Delete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
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
      // ToolStripMenuItem_Layout
      // 
      this.ToolStripMenuItem_Layout.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_NewZone,
            this.toolStripSeparator4,
            this.ToolStripMenuItem_RemoveZone});
      this.ToolStripMenuItem_Layout.Name = "ToolStripMenuItem_Layout";
      this.ToolStripMenuItem_Layout.Size = new System.Drawing.Size(69, 24);
      this.ToolStripMenuItem_Layout.Text = "Rozvržení";
      // 
      // ToolStripMenuItem_NewZone
      // 
      this.ToolStripMenuItem_NewZone.Name = "ToolStripMenuItem_NewZone";
      this.ToolStripMenuItem_NewZone.Size = new System.Drawing.Size(180, 22);
      this.ToolStripMenuItem_NewZone.Text = "Nová zóna...";
      this.ToolStripMenuItem_NewZone.Click += new System.EventHandler(this.ToolStripMenuItem_NewZone_Click);
      // 
      // toolStripSeparator4
      // 
      this.toolStripSeparator4.Name = "toolStripSeparator4";
      this.toolStripSeparator4.Size = new System.Drawing.Size(177, 6);
      // 
      // ToolStripMenuItem_RemoveZone
      // 
      this.ToolStripMenuItem_RemoveZone.Name = "ToolStripMenuItem_RemoveZone";
      this.ToolStripMenuItem_RemoveZone.Size = new System.Drawing.Size(180, 22);
      this.ToolStripMenuItem_RemoveZone.Text = "Odstranit zónu...";
      this.ToolStripMenuItem_RemoveZone.Click += new System.EventHandler(this.ToolStripMenuItem_RemoveZone_Click);
      // 
      // TreeView_Layout
      // 
      this.TreeView_Layout.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.TreeView_Layout.CausesValidation = false;
      this.TreeView_Layout.FullRowSelect = true;
      this.TreeView_Layout.Location = new System.Drawing.Point(0, 0);
      this.TreeView_Layout.Margin = new System.Windows.Forms.Padding(0);
      this.TreeView_Layout.Name = "TreeView_Layout";
      this.TreeView_Layout.PathSeparator = ".";
      this.TreeView_Layout.ShowNodeToolTips = true;
      this.TreeView_Layout.Size = new System.Drawing.Size(250, 328);
      this.TreeView_Layout.TabIndex = 0;
      this.TreeView_Layout.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TreeView_Layout_NodeMouseClick);
      // 
      // PictureBox_Layout
      // 
      this.PictureBox_Layout.ErrorImage = null;
      this.PictureBox_Layout.InitialImage = null;
      this.PictureBox_Layout.Location = new System.Drawing.Point(0, 0);
      this.PictureBox_Layout.Margin = new System.Windows.Forms.Padding(0);
      this.PictureBox_Layout.Name = "PictureBox_Layout";
      this.PictureBox_Layout.Size = new System.Drawing.Size(987, 570);
      this.PictureBox_Layout.TabIndex = 2;
      this.PictureBox_Layout.TabStop = false;
      this.PictureBox_Layout.Paint += new System.Windows.Forms.PaintEventHandler(this.PictureBox_Layout_Paint);
      // 
      // PropertyGrid_CurrentSelection
      // 
      this.PropertyGrid_CurrentSelection.Location = new System.Drawing.Point(0, 0);
      this.PropertyGrid_CurrentSelection.Margin = new System.Windows.Forms.Padding(0);
      this.PropertyGrid_CurrentSelection.Name = "PropertyGrid_CurrentSelection";
      this.PropertyGrid_CurrentSelection.PropertySort = System.Windows.Forms.PropertySort.NoSort;
      this.PropertyGrid_CurrentSelection.Size = new System.Drawing.Size(250, 238);
      this.PropertyGrid_CurrentSelection.TabIndex = 3;
      this.PropertyGrid_CurrentSelection.ToolbarVisible = false;
      this.PropertyGrid_CurrentSelection.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.PropertyGrid_CurrentSelection_PropertyValueChanged);
      // 
      // SplitContainer_Horizontal
      // 
      this.SplitContainer_Horizontal.CausesValidation = false;
      this.SplitContainer_Horizontal.Location = new System.Drawing.Point(0, 0);
      this.SplitContainer_Horizontal.Margin = new System.Windows.Forms.Padding(0);
      this.SplitContainer_Horizontal.Name = "SplitContainer_Horizontal";
      this.SplitContainer_Horizontal.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // SplitContainer_Horizontal.Panel1
      // 
      this.SplitContainer_Horizontal.Panel1.BackColor = System.Drawing.SystemColors.Control;
      this.SplitContainer_Horizontal.Panel1.Controls.Add(this.TreeView_Layout);
      this.SplitContainer_Horizontal.Panel1.Resize += new System.EventHandler(this.SplitContainer_Horizontal_Panel1_Resize);
      this.SplitContainer_Horizontal.Panel1MinSize = 200;
      // 
      // SplitContainer_Horizontal.Panel2
      // 
      this.SplitContainer_Horizontal.Panel2.Controls.Add(this.PropertyGrid_CurrentSelection);
      this.SplitContainer_Horizontal.Panel2.Resize += new System.EventHandler(this.SplitContainer_Horizontal_Panel2_Resize);
      this.SplitContainer_Horizontal.Panel2MinSize = 200;
      this.SplitContainer_Horizontal.Size = new System.Drawing.Size(250, 570);
      this.SplitContainer_Horizontal.SplitterDistance = 328;
      this.SplitContainer_Horizontal.TabIndex = 5;
      // 
      // SplitContainer_Vertical
      // 
      this.SplitContainer_Vertical.BackColor = System.Drawing.SystemColors.Control;
      this.SplitContainer_Vertical.CausesValidation = false;
      this.SplitContainer_Vertical.Location = new System.Drawing.Point(0, 24);
      this.SplitContainer_Vertical.Margin = new System.Windows.Forms.Padding(0);
      this.SplitContainer_Vertical.Name = "SplitContainer_Vertical";
      // 
      // SplitContainer_Vertical.Panel1
      // 
      this.SplitContainer_Vertical.Panel1.Controls.Add(this.SplitContainer_Horizontal);
      this.SplitContainer_Vertical.Panel1.Resize += new System.EventHandler(this.SplitContainer_Vertical_Panel1_Resize);
      this.SplitContainer_Vertical.Panel1MinSize = 250;
      // 
      // SplitContainer_Vertical.Panel2
      // 
      this.SplitContainer_Vertical.Panel2.AutoScroll = true;
      this.SplitContainer_Vertical.Panel2.Controls.Add(this.PictureBox_Layout);
      this.SplitContainer_Vertical.Panel2MinSize = 750;
      this.SplitContainer_Vertical.Size = new System.Drawing.Size(1241, 570);
      this.SplitContainer_Vertical.SplitterDistance = 250;
      this.SplitContainer_Vertical.TabIndex = 6;
      // 
      // Main
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
      this.CausesValidation = false;
      this.ClientSize = new System.Drawing.Size(1241, 594);
      this.Controls.Add(this.SplitContainer_Vertical);
      this.Controls.Add(this.MenuStrip);
      this.DoubleBuffered = true;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MainMenuStrip = this.MenuStrip;
      this.Name = "Main";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "(unset)";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
      this.Resize += new System.EventHandler(this.Main_Resize);
      this.MenuStrip.ResumeLayout(false);
      this.MenuStrip.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.PictureBox_Layout)).EndInit();
      this.SplitContainer_Horizontal.Panel1.ResumeLayout(false);
      this.SplitContainer_Horizontal.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.SplitContainer_Horizontal)).EndInit();
      this.SplitContainer_Horizontal.ResumeLayout(false);
      this.SplitContainer_Vertical.Panel1.ResumeLayout(false);
      this.SplitContainer_Vertical.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.SplitContainer_Vertical)).EndInit();
      this.SplitContainer_Vertical.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.MenuStrip MenuStrip;
    private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_File;
    private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_New;
    private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Open;
    private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Close;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Save;
    private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_SaveAs;
    private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Rename;
    private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Delete;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_OpenInFileExplorer;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Exit;
    private System.Windows.Forms.TreeView TreeView_Layout;
    private System.Windows.Forms.PictureBox PictureBox_Layout;
    private System.Windows.Forms.PropertyGrid PropertyGrid_CurrentSelection;
    private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Layout;
    private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_NewZone;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_RemoveZone;
    private System.Windows.Forms.SplitContainer SplitContainer_Horizontal;
    private System.Windows.Forms.SplitContainer SplitContainer_Vertical;
  }
}

