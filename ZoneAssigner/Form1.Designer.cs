
namespace ZoneAssigner {
  partial class Form1 {
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
      this.TestDataComboBox = new System.Windows.Forms.ComboBox();
      this.ErrorLabel = new System.Windows.Forms.Label();
      this.ContainerCodeTextField = new System.Windows.Forms.TextBox();
      this.SubmitButton = new System.Windows.Forms.Button();
      this.ContainerCodeLabel = new System.Windows.Forms.Label();
      this.ZoneLabel = new System.Windows.Forms.Label();
      this.VisualizerPictureBox = new System.Windows.Forms.PictureBox();
      ((System.ComponentModel.ISupportInitialize)(this.VisualizerPictureBox)).BeginInit();
      this.SuspendLayout();
      // 
      // TestDataComboBox
      // 
      this.TestDataComboBox.FormattingEnabled = true;
      this.TestDataComboBox.Items.AddRange(new object[] {
            "804322612",
            "0805001314",
            "0806822870",
            "0806857505",
            "0805232131",
            "0804610458",
            "0806884913",
            "0806775119",
            "0806574299",
            "0806722973",
            "0806375845",
            "0806803104",
            "0806899356",
            "0806823575",
            "0806861758",
            "0806820566",
            "0806226364",
            "0806796702",
            "0806818295",
            "0806499073",
            "0806309604",
            "0806627423",
            "0806815362",
            "0806802595",
            "0806809537",
            "0806580397",
            "0806884070",
            "0804570963",
            "0806868461",
            "0806780770",
            "0806890234",
            "0806834957",
            "0806724770",
            "0806658323",
            "0806888623",
            "0803410269",
            "0804267710",
            "0806836117",
            "0806082889",
            "0806723706",
            "0806821953",
            "0806896472",
            "0806778821",
            "0806724472",
            "0806226352",
            "0806349708",
            "0806821692",
            "0805350386",
            "0806421183",
            "0806862018"});
      this.TestDataComboBox.Location = new System.Drawing.Point(840, 12);
      this.TestDataComboBox.Name = "TestDataComboBox";
      this.TestDataComboBox.Size = new System.Drawing.Size(170, 21);
      this.TestDataComboBox.TabIndex = 1;
      this.TestDataComboBox.SelectedIndexChanged += new System.EventHandler(this.TestDataComboBox_SelectedIndexChanged);
      // 
      // ErrorLabel
      // 
      this.ErrorLabel.AutoSize = true;
      this.ErrorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.ErrorLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
      this.ErrorLabel.Location = new System.Drawing.Point(9, 62);
      this.ErrorLabel.Name = "ErrorLabel";
      this.ErrorLabel.Size = new System.Drawing.Size(232, 16);
      this.ErrorLabel.TabIndex = 5;
      this.ErrorLabel.Text = "Textové pole nesmí být prázdné.";
      this.ErrorLabel.Visible = false;
      // 
      // ContainerCodeTextField
      // 
      this.ContainerCodeTextField.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.ContainerCodeTextField.Location = new System.Drawing.Point(12, 28);
      this.ContainerCodeTextField.Multiline = true;
      this.ContainerCodeTextField.Name = "ContainerCodeTextField";
      this.ContainerCodeTextField.Size = new System.Drawing.Size(384, 21);
      this.ContainerCodeTextField.TabIndex = 6;
      this.ContainerCodeTextField.TextChanged += new System.EventHandler(this.SubmitOnEnter);
      // 
      // SubmitButton
      // 
      this.SubmitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.SubmitButton.Location = new System.Drawing.Point(146, 91);
      this.SubmitButton.Name = "SubmitButton";
      this.SubmitButton.Size = new System.Drawing.Size(117, 51);
      this.SubmitButton.TabIndex = 7;
      this.SubmitButton.Text = "Zadat";
      this.SubmitButton.UseVisualStyleBackColor = true;
      this.SubmitButton.Click += new System.EventHandler(this.SubmitHandler);
      // 
      // ContainerCodeLabel
      // 
      this.ContainerCodeLabel.AutoSize = true;
      this.ContainerCodeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.ContainerCodeLabel.Location = new System.Drawing.Point(169, 9);
      this.ContainerCodeLabel.Name = "ContainerCodeLabel";
      this.ContainerCodeLabel.Size = new System.Drawing.Size(71, 16);
      this.ContainerCodeLabel.TabIndex = 8;
      this.ContainerCodeLabel.Text = "Kód palety";
      // 
      // ZoneLabel
      // 
      this.ZoneLabel.AutoSize = true;
      this.ZoneLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 99.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.ZoneLabel.Location = new System.Drawing.Point(496, 12);
      this.ZoneLabel.Name = "ZoneLabel";
      this.ZoneLabel.Size = new System.Drawing.Size(244, 152);
      this.ZoneLabel.TabIndex = 9;
      this.ZoneLabel.Text = "XY";
      this.ZoneLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.ZoneLabel.Visible = false;
      // 
      // VisualizerPictureBox
      // 
      this.VisualizerPictureBox.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.VisualizerPictureBox.Image = global::ZoneAssigner.Properties.Resources.SKLAD;
      this.VisualizerPictureBox.Location = new System.Drawing.Point(0, 183);
      this.VisualizerPictureBox.Name = "VisualizerPictureBox";
      this.VisualizerPictureBox.Size = new System.Drawing.Size(1022, 512);
      this.VisualizerPictureBox.TabIndex = 10;
      this.VisualizerPictureBox.TabStop = false;
      this.VisualizerPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.VisualizerPictureBox_Paint);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1022, 695);
      this.Controls.Add(this.VisualizerPictureBox);
      this.Controls.Add(this.ZoneLabel);
      this.Controls.Add(this.ContainerCodeLabel);
      this.Controls.Add(this.SubmitButton);
      this.Controls.Add(this.ContainerCodeTextField);
      this.Controls.Add(this.ErrorLabel);
      this.Controls.Add(this.TestDataComboBox);
      this.DoubleBuffered = true;
      this.Name = "Form1";
      this.Text = "Form1";
      ((System.ComponentModel.ISupportInitialize)(this.VisualizerPictureBox)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.ComboBox TestDataComboBox;
    private System.Windows.Forms.Label ErrorLabel;
    private System.Windows.Forms.TextBox ContainerCodeTextField;
    private System.Windows.Forms.Button SubmitButton;
    private System.Windows.Forms.Label ContainerCodeLabel;
    private System.Windows.Forms.Label ZoneLabel;
    private System.Windows.Forms.PictureBox VisualizerPictureBox;
  }
}

