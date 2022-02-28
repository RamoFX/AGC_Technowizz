
namespace ZoneAssigner {
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
      this.Canvas_Layout = new System.Windows.Forms.PictureBox();
      this.ZoneName = new System.Windows.Forms.Label();
      this.Panel_Upper = new System.Windows.Forms.Panel();
      this.Button_Submit = new System.Windows.Forms.Button();
      this.TextField_PalletCode = new System.Windows.Forms.TextBox();
      this.Panel_CanvasWrapper = new System.Windows.Forms.Panel();
      this.Menu.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.Canvas_Layout)).BeginInit();
      this.Panel_Upper.SuspendLayout();
      this.Panel_CanvasWrapper.SuspendLayout();
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
      this.Menu.Size = new System.Drawing.Size(1199, 24);
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
      // Canvas_Layout
      // 
      this.Canvas_Layout.BackColor = System.Drawing.SystemColors.Control;
      this.Canvas_Layout.ErrorImage = null;
      this.Canvas_Layout.InitialImage = null;
      this.Canvas_Layout.Location = new System.Drawing.Point(0, 0);
      this.Canvas_Layout.Margin = new System.Windows.Forms.Padding(0);
      this.Canvas_Layout.Name = "Canvas_Layout";
      this.Canvas_Layout.Size = new System.Drawing.Size(1199, 558);
      this.Canvas_Layout.TabIndex = 2;
      this.Canvas_Layout.TabStop = false;
      this.Canvas_Layout.Paint += new System.Windows.Forms.PaintEventHandler(this.Canvas_Layout_Paint);
      // 
      // ZoneName
      // 
      this.ZoneName.AutoSize = true;
      this.ZoneName.Font = new System.Drawing.Font("Courier New", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.ZoneName.Location = new System.Drawing.Point(24, 24);
      this.ZoneName.Margin = new System.Windows.Forms.Padding(24);
      this.ZoneName.Name = "ZoneName";
      this.ZoneName.Size = new System.Drawing.Size(164, 40);
      this.ZoneName.TabIndex = 3;
      this.ZoneName.Text = "(unset)";
      // 
      // Panel_Upper
      // 
      this.Panel_Upper.AutoScroll = true;
      this.Panel_Upper.Controls.Add(this.Button_Submit);
      this.Panel_Upper.Controls.Add(this.TextField_PalletCode);
      this.Panel_Upper.Controls.Add(this.ZoneName);
      this.Panel_Upper.Location = new System.Drawing.Point(0, 24);
      this.Panel_Upper.Margin = new System.Windows.Forms.Padding(0);
      this.Panel_Upper.Name = "Panel_Upper";
      this.Panel_Upper.Size = new System.Drawing.Size(1199, 90);
      this.Panel_Upper.TabIndex = 4;
      // 
      // Button_Submit
      // 
      this.Button_Submit.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Button_Submit.Location = new System.Drawing.Point(1006, 24);
      this.Button_Submit.Margin = new System.Windows.Forms.Padding(24);
      this.Button_Submit.Name = "Button_Submit";
      this.Button_Submit.Size = new System.Drawing.Size(160, 40);
      this.Button_Submit.TabIndex = 5;
      this.Button_Submit.Text = "Zadat";
      this.Button_Submit.UseVisualStyleBackColor = true;
      this.Button_Submit.Click += new System.EventHandler(this.Button_Submit_Click);
      // 
      // TextField_PalletCode
      // 
      this.TextField_PalletCode.Font = new System.Drawing.Font("Courier New", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.TextField_PalletCode.Location = new System.Drawing.Point(298, 24);
      this.TextField_PalletCode.Margin = new System.Windows.Forms.Padding(24);
      this.TextField_PalletCode.Name = "TextField_PalletCode";
      this.TextField_PalletCode.Size = new System.Drawing.Size(708, 40);
      this.TextField_PalletCode.TabIndex = 4;
      // 
      // Panel_CanvasWrapper
      // 
      this.Panel_CanvasWrapper.AutoScroll = true;
      this.Panel_CanvasWrapper.Controls.Add(this.Canvas_Layout);
      this.Panel_CanvasWrapper.Location = new System.Drawing.Point(0, 114);
      this.Panel_CanvasWrapper.Margin = new System.Windows.Forms.Padding(0);
      this.Panel_CanvasWrapper.Name = "Panel_CanvasWrapper";
      this.Panel_CanvasWrapper.Size = new System.Drawing.Size(1199, 558);
      this.Panel_CanvasWrapper.TabIndex = 5;
      // 
      // Main
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
      this.CausesValidation = false;
      this.ClientSize = new System.Drawing.Size(1199, 672);
      this.Controls.Add(this.Panel_CanvasWrapper);
      this.Controls.Add(this.Panel_Upper);
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
      this.Panel_Upper.ResumeLayout(false);
      this.Panel_Upper.PerformLayout();
      this.Panel_CanvasWrapper.ResumeLayout(false);
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
    private System.Windows.Forms.PictureBox Canvas_Layout;
    private System.Windows.Forms.Label ZoneName;
    private System.Windows.Forms.Panel Panel_Upper;
    private System.Windows.Forms.TextBox TextField_PalletCode;
    private System.Windows.Forms.Button Button_Submit;
    private System.Windows.Forms.Panel Panel_CanvasWrapper;
  }
}

