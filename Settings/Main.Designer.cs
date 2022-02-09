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
      this.SuspendLayout();
      // 
      // propertyGrid
      // 
      this.propertyGrid.Location = new System.Drawing.Point(0, 0);
      this.propertyGrid.Name = "propertyGrid";
      this.propertyGrid.PropertySort = System.Windows.Forms.PropertySort.Categorized;
      this.propertyGrid.Size = new System.Drawing.Size(286, 451);
      this.propertyGrid.TabIndex = 3;
      this.propertyGrid.ToolbarVisible = false;
      // 
      // Main
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(286, 450);
      this.Controls.Add(this.propertyGrid);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "Main";
      this.Text = "Settings";
      this.Load += new System.EventHandler(this.Main_Load);
      this.ResumeLayout(false);

    }

    #endregion
        private System.Windows.Forms.PropertyGrid propertyGrid;
    }
}

