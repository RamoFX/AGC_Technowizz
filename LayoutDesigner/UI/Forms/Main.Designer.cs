
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
      this.MenuStrip = new System.Windows.Forms.MenuStrip();
      this.souborToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.ToolStripMenuItem_New = new System.Windows.Forms.ToolStripMenuItem();
      this.ToolStripMenuItem_Open = new System.Windows.Forms.ToolStripMenuItem();
      this.ToolStripMenuItem_Save = new System.Windows.Forms.ToolStripMenuItem();
      this.ToolStripMenuItem_SaveAs = new System.Windows.Forms.ToolStripMenuItem();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
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
            this.ToolStripMenuItem_Save,
            this.ToolStripMenuItem_SaveAs});
      this.souborToolStripMenuItem.Name = "souborToolStripMenuItem";
      this.souborToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
      this.souborToolStripMenuItem.Text = "Soubor";
      // 
      // ToolStripMenuItem_New
      // 
      this.ToolStripMenuItem_New.Name = "ToolStripMenuItem_New";
      this.ToolStripMenuItem_New.Size = new System.Drawing.Size(138, 22);
      this.ToolStripMenuItem_New.Text = "Nový...";
      this.ToolStripMenuItem_New.Click += new System.EventHandler(this.ToolStripMenuItem_New_Click);
      // 
      // ToolStripMenuItem_Open
      // 
      this.ToolStripMenuItem_Open.Name = "ToolStripMenuItem_Open";
      this.ToolStripMenuItem_Open.Size = new System.Drawing.Size(138, 22);
      this.ToolStripMenuItem_Open.Text = "Otevřít...";
      this.ToolStripMenuItem_Open.Click += new System.EventHandler(this.ToolStripMenuItem_Open_Click);
      // 
      // ToolStripMenuItem_Save
      // 
      this.ToolStripMenuItem_Save.Name = "ToolStripMenuItem_Save";
      this.ToolStripMenuItem_Save.Size = new System.Drawing.Size(138, 22);
      this.ToolStripMenuItem_Save.Text = "Uložit";
      this.ToolStripMenuItem_Save.Click += new System.EventHandler(this.ToolStripMenuItem_Save_Click);
      // 
      // ToolStripMenuItem_SaveAs
      // 
      this.ToolStripMenuItem_SaveAs.Name = "ToolStripMenuItem_SaveAs";
      this.ToolStripMenuItem_SaveAs.Size = new System.Drawing.Size(138, 22);
      this.ToolStripMenuItem_SaveAs.Text = "Uložit jako...";
      this.ToolStripMenuItem_SaveAs.Click += new System.EventHandler(this.ToolStripMenuItem_SaveAs_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(132, 182);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(35, 13);
      this.label1.TabIndex = 2;
      this.label1.Text = "label1";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(135, 222);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(35, 13);
      this.label2.TabIndex = 3;
      this.label2.Text = "label2";
      // 
      // Main
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1250, 587);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.MenuStrip);
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
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
  }
}

