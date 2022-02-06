
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
      this.ComboBox_ContainerCodes = new System.Windows.Forms.ComboBox();
      this.ErrorLabel = new System.Windows.Forms.Label();
      this.TextField_ContainerCode = new System.Windows.Forms.TextBox();
      this.SubmitButton = new System.Windows.Forms.Button();
      this.ContainerCodeLabel = new System.Windows.Forms.Label();
      this.ZoneLabel = new System.Windows.Forms.Label();
      this.VisualizerPictureBox = new System.Windows.Forms.PictureBox();
      this.MenuStrip = new System.Windows.Forms.MenuStrip();
      this.Menu_Settings = new System.Windows.Forms.ToolStripMenuItem();
      this.Menu_StartupLayout = new System.Windows.Forms.ToolStripMenuItem();
      this.Menu_ValidLayoutNames = new System.Windows.Forms.ToolStripComboBox();
      this.ToolStripMenuItem_Help = new System.Windows.Forms.ToolStripMenuItem();
      ((System.ComponentModel.ISupportInitialize)(this.VisualizerPictureBox)).BeginInit();
      this.MenuStrip.SuspendLayout();
      this.SuspendLayout();
      // 
      // ComboBox_ContainerCodes
      // 
      this.ComboBox_ContainerCodes.FormattingEnabled = true;
      this.ComboBox_ContainerCodes.Location = new System.Drawing.Point(840, 27);
      this.ComboBox_ContainerCodes.Name = "ComboBox_ContainerCodes";
      this.ComboBox_ContainerCodes.Size = new System.Drawing.Size(170, 21);
      this.ComboBox_ContainerCodes.TabIndex = 1;
      this.ComboBox_ContainerCodes.SelectedIndexChanged += new System.EventHandler(this.ComboBox_ContainerCodes_SelectedIndexChanged);
      // 
      // ErrorLabel
      // 
      this.ErrorLabel.AutoSize = true;
      this.ErrorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.ErrorLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
      this.ErrorLabel.Location = new System.Drawing.Point(9, 77);
      this.ErrorLabel.Name = "ErrorLabel";
      this.ErrorLabel.Size = new System.Drawing.Size(232, 16);
      this.ErrorLabel.TabIndex = 5;
      this.ErrorLabel.Text = "Textové pole nesmí být prázdné.";
      this.ErrorLabel.Visible = false;
      // 
      // TextField_ContainerCode
      // 
      this.TextField_ContainerCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.TextField_ContainerCode.Location = new System.Drawing.Point(12, 43);
      this.TextField_ContainerCode.Multiline = true;
      this.TextField_ContainerCode.Name = "TextField_ContainerCode";
      this.TextField_ContainerCode.Size = new System.Drawing.Size(384, 21);
      this.TextField_ContainerCode.TabIndex = 6;
      // 
      // SubmitButton
      // 
      this.SubmitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.SubmitButton.Location = new System.Drawing.Point(146, 106);
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
      this.ContainerCodeLabel.Location = new System.Drawing.Point(169, 24);
      this.ContainerCodeLabel.Name = "ContainerCodeLabel";
      this.ContainerCodeLabel.Size = new System.Drawing.Size(71, 16);
      this.ContainerCodeLabel.TabIndex = 8;
      this.ContainerCodeLabel.Text = "Kód palety";
      // 
      // ZoneLabel
      // 
      this.ZoneLabel.AutoSize = true;
      this.ZoneLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 99.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.ZoneLabel.Location = new System.Drawing.Point(496, 27);
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
      this.VisualizerPictureBox.Location = new System.Drawing.Point(0, 207);
      this.VisualizerPictureBox.Name = "VisualizerPictureBox";
      this.VisualizerPictureBox.Size = new System.Drawing.Size(1022, 512);
      this.VisualizerPictureBox.TabIndex = 10;
      this.VisualizerPictureBox.TabStop = false;
      this.VisualizerPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.VisualizerPictureBox_Paint);
      // 
      // MenuStrip
      // 
      this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_Settings});
      this.MenuStrip.Location = new System.Drawing.Point(0, 0);
      this.MenuStrip.Name = "MenuStrip";
      this.MenuStrip.Size = new System.Drawing.Size(1022, 24);
      this.MenuStrip.TabIndex = 11;
      // 
      // Menu_Settings
      // 
      this.Menu_Settings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_StartupLayout,
            this.ToolStripMenuItem_Help});
      this.Menu_Settings.Name = "Menu_Settings";
      this.Menu_Settings.Size = new System.Drawing.Size(71, 20);
      this.Menu_Settings.Text = "Nastavení";
      // 
      // Menu_StartupLayout
      // 
      this.Menu_StartupLayout.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_ValidLayoutNames});
      this.Menu_StartupLayout.Name = "Menu_StartupLayout";
      this.Menu_StartupLayout.Size = new System.Drawing.Size(175, 22);
      this.Menu_StartupLayout.Text = "Spouštěcí rozvržení";
      // 
      // Menu_ValidLayoutNames
      // 
      this.Menu_ValidLayoutNames.DropDownWidth = 200;
      this.Menu_ValidLayoutNames.Name = "Menu_ValidLayoutNames";
      this.Menu_ValidLayoutNames.Size = new System.Drawing.Size(200, 23);
      // 
      // ToolStripMenuItem_Help
      // 
      this.ToolStripMenuItem_Help.Name = "ToolStripMenuItem_Help";
      this.ToolStripMenuItem_Help.Size = new System.Drawing.Size(175, 22);
      this.ToolStripMenuItem_Help.Text = "Nápověda";
      this.ToolStripMenuItem_Help.Click += new System.EventHandler(this.ToolStripMenuItem_Help_Click);
      // 
      // Main
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1022, 719);
      this.Controls.Add(this.MenuStrip);
      this.Controls.Add(this.VisualizerPictureBox);
      this.Controls.Add(this.ZoneLabel);
      this.Controls.Add(this.ContainerCodeLabel);
      this.Controls.Add(this.SubmitButton);
      this.Controls.Add(this.TextField_ContainerCode);
      this.Controls.Add(this.ErrorLabel);
      this.Controls.Add(this.ComboBox_ContainerCodes);
      this.DoubleBuffered = true;
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MaximizeBox = false;
      this.Name = "Main";
      this.Text = "(unset)";
      this.Load += new System.EventHandler(this.Main_Load);
      ((System.ComponentModel.ISupportInitialize)(this.VisualizerPictureBox)).EndInit();
      this.MenuStrip.ResumeLayout(false);
      this.MenuStrip.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.ComboBox ComboBox_ContainerCodes;
    private System.Windows.Forms.Label ErrorLabel;
    private System.Windows.Forms.TextBox TextField_ContainerCode;
    private System.Windows.Forms.Button SubmitButton;
    private System.Windows.Forms.Label ContainerCodeLabel;
    private System.Windows.Forms.Label ZoneLabel;
    private System.Windows.Forms.PictureBox VisualizerPictureBox;
    private System.Windows.Forms.MenuStrip MenuStrip;
    private System.Windows.Forms.ToolStripMenuItem Menu_Settings;
    private System.Windows.Forms.ToolStripMenuItem Menu_StartupLayout;
    private System.Windows.Forms.ToolStripComboBox Menu_ValidLayoutNames;
    private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Help;
  }
}

