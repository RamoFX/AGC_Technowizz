
namespace LayoutOverview {
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
      if (disposing && (components != null)) {
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
      this.Menu = new System.Windows.Forms.MenuStrip();
      this.MenuFile = new System.Windows.Forms.ToolStripMenuItem();
      this.MenuItem_Open = new System.Windows.Forms.ToolStripMenuItem();
      this.MenuItem_Close = new System.Windows.Forms.ToolStripMenuItem();
      this.Separator2 = new System.Windows.Forms.ToolStripSeparator();
      this.MenuItem_OpenInFileExplorer = new System.Windows.Forms.ToolStripMenuItem();
      this.Separator1 = new System.Windows.Forms.ToolStripSeparator();
      this.MenuItem_Exit = new System.Windows.Forms.ToolStripMenuItem();
      this.Tree_Layout = new System.Windows.Forms.TreeView();
      this.StatusStrip = new System.Windows.Forms.StatusStrip();
      this.Canvas_Layout = new System.Windows.Forms.PictureBox();
      this.Properties_CurrentSelection = new System.Windows.Forms.PropertyGrid();
      this.SplitContainer_Horizontal = new System.Windows.Forms.SplitContainer();
      this.SplitContainer_Vertical = new System.Windows.Forms.SplitContainer();
      this.Menu.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.Canvas_Layout)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.SplitContainer_Horizontal)).BeginInit();
      this.SplitContainer_Horizontal.Panel1.SuspendLayout();
      this.SplitContainer_Horizontal.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.SplitContainer_Vertical)).BeginInit();
      this.SplitContainer_Vertical.Panel1.SuspendLayout();
      this.SplitContainer_Vertical.Panel2.SuspendLayout();
      this.SplitContainer_Vertical.SuspendLayout();
      this.SuspendLayout();
      // 
      // Menu
      // 
      this.Menu.GripMargin = new System.Windows.Forms.Padding(0);
      this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuFile});
      this.Menu.Location = new System.Drawing.Point(0, 0);
      this.Menu.Name = "Menu";
      this.Menu.Padding = new System.Windows.Forms.Padding(0);
      this.Menu.Size = new System.Drawing.Size(1241, 24);
      this.Menu.TabIndex = 1;
      // 
      // MenuFile
      // 
      this.MenuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_Open,
            this.MenuItem_Close,
            this.Separator2,
            this.MenuItem_OpenInFileExplorer,
            this.Separator1,
            this.MenuItem_Exit});
      this.MenuFile.Name = "MenuFile";
      this.MenuFile.Size = new System.Drawing.Size(57, 24);
      this.MenuFile.Text = "Soubor";
      // 
      // MenuItem_Open
      // 
      this.MenuItem_Open.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.MenuItem_Open.Name = "MenuItem_Open";
      this.MenuItem_Open.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
      this.MenuItem_Open.Size = new System.Drawing.Size(297, 22);
      this.MenuItem_Open.Text = "Otevřít...";
      this.MenuItem_Open.Click += new System.EventHandler(this.MenuItem_Open_Click);
      // 
      // MenuItem_Close
      // 
      this.MenuItem_Close.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.MenuItem_Close.Name = "MenuItem_Close";
      this.MenuItem_Close.Size = new System.Drawing.Size(297, 22);
      this.MenuItem_Close.Text = "Zavřít";
      this.MenuItem_Close.Click += new System.EventHandler(this.MenuItem_Close_Click);
      // 
      // Separator2
      // 
      this.Separator2.Name = "Separator2";
      this.Separator2.Size = new System.Drawing.Size(294, 6);
      // 
      // MenuItem_OpenInFileExplorer
      // 
      this.MenuItem_OpenInFileExplorer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.MenuItem_OpenInFileExplorer.Name = "MenuItem_OpenInFileExplorer";
      this.MenuItem_OpenInFileExplorer.Size = new System.Drawing.Size(297, 22);
      this.MenuItem_OpenInFileExplorer.Text = "Všechna rozložení v průzkumníku souborů";
      this.MenuItem_OpenInFileExplorer.Click += new System.EventHandler(this.MenuItem_OpenInFileExplorer_Click);
      // 
      // Separator1
      // 
      this.Separator1.Name = "Separator1";
      this.Separator1.Size = new System.Drawing.Size(294, 6);
      // 
      // MenuItem_Exit
      // 
      this.MenuItem_Exit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.MenuItem_Exit.Name = "MenuItem_Exit";
      this.MenuItem_Exit.Size = new System.Drawing.Size(297, 22);
      this.MenuItem_Exit.Text = "Ukončit";
      this.MenuItem_Exit.Click += new System.EventHandler(this.MenuItem_Exit_Click);
      // 
      // Tree_Layout
      // 
      this.Tree_Layout.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.Tree_Layout.CausesValidation = false;
      this.Tree_Layout.Location = new System.Drawing.Point(0, 0);
      this.Tree_Layout.Margin = new System.Windows.Forms.Padding(0);
      this.Tree_Layout.Name = "Tree_Layout";
      this.Tree_Layout.PathSeparator = ".";
      this.Tree_Layout.ShowNodeToolTips = true;
      this.Tree_Layout.Size = new System.Drawing.Size(250, 328);
      this.Tree_Layout.TabIndex = 0;
      this.Tree_Layout.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Tree_Layout_MouseDown);
      // 
      // StatusStrip
      // 
      this.StatusStrip.GripMargin = new System.Windows.Forms.Padding(0);
      this.StatusStrip.Location = new System.Drawing.Point(0, 594);
      this.StatusStrip.Name = "StatusStrip";
      this.StatusStrip.Size = new System.Drawing.Size(1241, 22);
      this.StatusStrip.TabIndex = 7;
      this.StatusStrip.Text = "Status strip";
      // 
      // Canvas_Layout
      // 
      this.Canvas_Layout.BackColor = System.Drawing.SystemColors.Control;
      this.Canvas_Layout.ErrorImage = null;
      this.Canvas_Layout.InitialImage = null;
      this.Canvas_Layout.Location = new System.Drawing.Point(0, 0);
      this.Canvas_Layout.Margin = new System.Windows.Forms.Padding(0);
      this.Canvas_Layout.Name = "Canvas_Layout";
      this.Canvas_Layout.Size = new System.Drawing.Size(987, 570);
      this.Canvas_Layout.TabIndex = 2;
      this.Canvas_Layout.TabStop = false;
      this.Canvas_Layout.Paint += new System.Windows.Forms.PaintEventHandler(this.Canvas_Layout_Paint);
      this.Canvas_Layout.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Canvas_Layout_MouseClick);
      // 
      // Properties_CurrentSelection
      // 
      this.Properties_CurrentSelection.Location = new System.Drawing.Point(0, 0);
      this.Properties_CurrentSelection.Margin = new System.Windows.Forms.Padding(0);
      this.Properties_CurrentSelection.Name = "Properties_CurrentSelection";
      this.Properties_CurrentSelection.PropertySort = System.Windows.Forms.PropertySort.NoSort;
      this.Properties_CurrentSelection.Size = new System.Drawing.Size(250, 238);
      this.Properties_CurrentSelection.TabIndex = 3;
      this.Properties_CurrentSelection.TabStop = false;
      this.Properties_CurrentSelection.ToolbarVisible = false;
      this.Properties_CurrentSelection.Enter += new System.EventHandler(this.Properties_CurrentSelection_Enter);
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
      this.SplitContainer_Horizontal.Panel1.Controls.Add(this.Tree_Layout);
      this.SplitContainer_Horizontal.Panel1.Resize += new System.EventHandler(this.SplitContainer_Horizontal_Panel1_Resize);
      this.SplitContainer_Horizontal.Panel1MinSize = 200;
      // 
      // SplitContainer_Horizontal.Panel2
      // 
      this.SplitContainer_Horizontal.Panel2.Controls.Add(this.Properties_CurrentSelection);
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
      this.SplitContainer_Vertical.Panel2.Controls.Add(this.Canvas_Layout);
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
      this.ClientSize = new System.Drawing.Size(1241, 616);
      this.Controls.Add(this.StatusStrip);
      this.Controls.Add(this.SplitContainer_Vertical);
      this.Controls.Add(this.Menu);
      this.DoubleBuffered = true;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MainMenuStrip = this.Menu;
      this.Name = "Main";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "(unset)";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
      this.Resize += new System.EventHandler(this.Main_Resize);
      this.Menu.ResumeLayout(false);
      this.Menu.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.Canvas_Layout)).EndInit();
      this.SplitContainer_Horizontal.Panel1.ResumeLayout(false);
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
    private System.Windows.Forms.MenuStrip Menu;
    private System.Windows.Forms.ToolStripMenuItem MenuFile;
    private System.Windows.Forms.ToolStripMenuItem MenuItem_Open;
    private System.Windows.Forms.ToolStripMenuItem MenuItem_Close;
    private System.Windows.Forms.ToolStripSeparator Separator2;
    private System.Windows.Forms.ToolStripSeparator Separator1;
    private System.Windows.Forms.ToolStripMenuItem MenuItem_OpenInFileExplorer;
    private System.Windows.Forms.ToolStripMenuItem MenuItem_Exit;
    private System.Windows.Forms.TreeView Tree_Layout;
    private System.Windows.Forms.StatusStrip StatusStrip;
    private System.Windows.Forms.PictureBox Canvas_Layout;
    private System.Windows.Forms.PropertyGrid Properties_CurrentSelection;
    private System.Windows.Forms.SplitContainer SplitContainer_Horizontal;
    private System.Windows.Forms.SplitContainer SplitContainer_Vertical;
  }
}

