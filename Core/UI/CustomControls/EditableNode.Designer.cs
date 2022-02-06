namespace Core.UI.CustomControls
{
  partial class EditableNode
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

    #region Kód vygenerovaný pomocí Návrháře komponent

    /// <summary> 
    /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
    /// obsah této metody v editoru kódu.
    /// </summary>
    private void InitializeComponent()
    {
      this.labelTitle = new System.Windows.Forms.Label();
      this.label = new System.Windows.Forms.Label();
      this.valueTextBox = new System.Windows.Forms.TextBox();
      this.buttonSubmit = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // labelTitle
      // 
      this.labelTitle.AutoSize = true;
      this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.labelTitle.Location = new System.Drawing.Point(3, 0);
      this.labelTitle.Name = "labelTitle";
      this.labelTitle.Size = new System.Drawing.Size(68, 16);
      this.labelTitle.TabIndex = 0;
      this.labelTitle.Text = "(lable title)";
      // 
      // label
      // 
      this.label.AutoSize = true;
      this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.label.Location = new System.Drawing.Point(58, 20);
      this.label.Name = "label";
      this.label.Size = new System.Drawing.Size(35, 13);
      this.label.TabIndex = 0;
      this.label.Text = "(label)";
      this.label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // valueTextBox
      // 
      this.valueTextBox.Location = new System.Drawing.Point(99, 17);
      this.valueTextBox.Name = "valueTextBox";
      this.valueTextBox.Size = new System.Drawing.Size(100, 20);
      this.valueTextBox.TabIndex = 1;
      // 
      // buttonSubmit
      // 
      this.buttonSubmit.Location = new System.Drawing.Point(205, 17);
      this.buttonSubmit.Name = "buttonSubmit";
      this.buttonSubmit.Size = new System.Drawing.Size(75, 20);
      this.buttonSubmit.TabIndex = 2;
      this.buttonSubmit.Text = "Zadat";
      this.buttonSubmit.UseVisualStyleBackColor = true;
      // 
      // EditableNode
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.buttonSubmit);
      this.Controls.Add(this.valueTextBox);
      this.Controls.Add(this.label);
      this.Controls.Add(this.labelTitle);
      this.Name = "EditableNode";
      this.Size = new System.Drawing.Size(280, 37);
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    #endregion

    private System.Windows.Forms.Label labelTitle;
    private System.Windows.Forms.Label label;
    private System.Windows.Forms.TextBox valueTextBox;
    private System.Windows.Forms.Button buttonSubmit;
  }
}
