namespace Settings
{
  partial class Main
  {
    /// <summary>
    /// Vyžaduje se proměnná návrháře.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Uvolněte všechny používané prostředky.
    /// </summary>
    /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Kód generovaný Návrhářem Windows Form

    /// <summary>
    /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
    /// obsah této metody v editoru kódu.
    /// </summary>
    private void InitializeComponent()
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
      this.treeView_settings = new System.Windows.Forms.TreeView();
      this.settingsValue_TextBox = new System.Windows.Forms.TextBox();
      this.SubmitButtom = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // treeView_settings
      // 
      this.treeView_settings.BackColor = System.Drawing.SystemColors.Control;
      this.treeView_settings.Dock = System.Windows.Forms.DockStyle.Left;
      this.treeView_settings.Location = new System.Drawing.Point(0, 0);
      this.treeView_settings.Name = "treeView_settings";
      this.treeView_settings.Size = new System.Drawing.Size(208, 450);
      this.treeView_settings.TabIndex = 0;
      this.treeView_settings.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_settings_AfterSelect);
      // 
      // settingsValue_TextBox
      // 
      this.settingsValue_TextBox.Enabled = false;
      this.settingsValue_TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.settingsValue_TextBox.Location = new System.Drawing.Point(214, 12);
      this.settingsValue_TextBox.Name = "settingsValue_TextBox";
      this.settingsValue_TextBox.Size = new System.Drawing.Size(160, 20);
      this.settingsValue_TextBox.TabIndex = 1;
      this.settingsValue_TextBox.Visible = false;
      // 
      // SubmitButtom
      // 
      this.SubmitButtom.Enabled = false;
      this.SubmitButtom.Location = new System.Drawing.Point(214, 38);
      this.SubmitButtom.Name = "SubmitButtom";
      this.SubmitButtom.Size = new System.Drawing.Size(160, 23);
      this.SubmitButtom.TabIndex = 2;
      this.SubmitButtom.Text = "Zapsat hodnotu";
      this.SubmitButtom.UseVisualStyleBackColor = true;
      this.SubmitButtom.Visible = false;
      this.SubmitButtom.Click += new System.EventHandler(this.SubmitHandler);
      // 
      // Main
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(386, 450);
      this.Controls.Add(this.SubmitButtom);
      this.Controls.Add(this.settingsValue_TextBox);
      this.Controls.Add(this.treeView_settings);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "Main";
      this.Text = "Settings";
      this.Load += new System.EventHandler(this.Main_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TreeView treeView_settings;
    private System.Windows.Forms.TextBox settingsValue_TextBox;
    private System.Windows.Forms.Button SubmitButtom;
  }
}

