namespace Core.UI.Dialogs {
  partial class TextInput {
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
      this.TextBox = new System.Windows.Forms.TextBox();
      this.Button_Cancel = new System.Windows.Forms.Button();
      this.Button_Apply = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // TextBox
      // 
      this.TextBox.Location = new System.Drawing.Point(0, 0);
      this.TextBox.Margin = new System.Windows.Forms.Padding(0);
      this.TextBox.Name = "TextBox";
      this.TextBox.Size = new System.Drawing.Size(250, 20);
      this.TextBox.TabIndex = 0;
      this.TextBox.TabStop = false;
      this.TextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyboardShortcuts);
      // 
      // Button_Cancel
      // 
      this.Button_Cancel.Location = new System.Drawing.Point(125, 20);
      this.Button_Cancel.Margin = new System.Windows.Forms.Padding(0);
      this.Button_Cancel.Name = "Button_Cancel";
      this.Button_Cancel.Size = new System.Drawing.Size(125, 32);
      this.Button_Cancel.TabIndex = 1;
      this.Button_Cancel.TabStop = false;
      this.Button_Cancel.Text = "Storno";
      this.Button_Cancel.UseVisualStyleBackColor = true;
      this.Button_Cancel.Click += new System.EventHandler(this.Button_Cancel_Click);
      // 
      // Button_Apply
      // 
      this.Button_Apply.Location = new System.Drawing.Point(0, 20);
      this.Button_Apply.Margin = new System.Windows.Forms.Padding(0);
      this.Button_Apply.Name = "Button_Apply";
      this.Button_Apply.Size = new System.Drawing.Size(125, 32);
      this.Button_Apply.TabIndex = 3;
      this.Button_Apply.TabStop = false;
      this.Button_Apply.Text = "Použít";
      this.Button_Apply.UseVisualStyleBackColor = true;
      this.Button_Apply.Click += new System.EventHandler(this.Button_Apply_Click);
      // 
      // TextInput
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(250, 52);
      this.Controls.Add(this.Button_Apply);
      this.Controls.Add(this.Button_Cancel);
      this.Controls.Add(this.TextBox);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.MinimizeBox = false;
      this.Name = "TextInput";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "(unset)";
      this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyboardShortcuts);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox TextBox;
    private System.Windows.Forms.Button Button_Cancel;
    private System.Windows.Forms.Button Button_Apply;
  }
}