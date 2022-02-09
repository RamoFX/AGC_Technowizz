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
      this.propertyGrid = new System.Windows.Forms.PropertyGrid();
      this.buttonResetSettings = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // propertyGrid
      // 
      this.propertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
      this.propertyGrid.Location = new System.Drawing.Point(0, 0);
      this.propertyGrid.Name = "propertyGrid";
      this.propertyGrid.Size = new System.Drawing.Size(383, 450);
      this.propertyGrid.TabIndex = 3;
      this.propertyGrid.ToolbarVisible = false;
      // 
      // buttonResetSettings
      // 
      this.buttonResetSettings.Cursor = System.Windows.Forms.Cursors.Hand;
      this.buttonResetSettings.FlatAppearance.BorderColor = System.Drawing.Color.Black;
      this.buttonResetSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.buttonResetSettings.Location = new System.Drawing.Point(338, 427);
      this.buttonResetSettings.Name = "buttonResetSettings";
      this.buttonResetSettings.Size = new System.Drawing.Size(45, 23);
      this.buttonResetSettings.TabIndex = 4;
      this.buttonResetSettings.Text = "Reset";
      this.buttonResetSettings.UseVisualStyleBackColor = true;
      this.buttonResetSettings.Click += new System.EventHandler(this.buttonResetSettings_Click);
      // 
      // Main
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(383, 450);
      this.Controls.Add(this.buttonResetSettings);
      this.Controls.Add(this.propertyGrid);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "Main";
      this.Text = "Settings";
      this.Load += new System.EventHandler(this.Main_Load);
      this.ResumeLayout(false);

    }

    #endregion
        private System.Windows.Forms.PropertyGrid propertyGrid;
    private System.Windows.Forms.Button buttonResetSettings;
  }
}

