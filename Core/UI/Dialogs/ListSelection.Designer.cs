namespace Core.UI.Dialogs {
  partial class ListSelection {
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
      this.Button_Apply = new System.Windows.Forms.Button();
      this.Button_Cancel = new System.Windows.Forms.Button();
      this.ListBox = new System.Windows.Forms.ListBox();
      this.SuspendLayout();
      // 
      // Button_Apply
      // 
      this.Button_Apply.Location = new System.Drawing.Point(0, 199);
      this.Button_Apply.Margin = new System.Windows.Forms.Padding(0);
      this.Button_Apply.Name = "Button_Apply";
      this.Button_Apply.Size = new System.Drawing.Size(100, 32);
      this.Button_Apply.TabIndex = 9;
      this.Button_Apply.TabStop = false;
      this.Button_Apply.Text = "Použít";
      this.Button_Apply.UseVisualStyleBackColor = true;
      this.Button_Apply.Click += new System.EventHandler(this.Button_Apply_Click);
      // 
      // Button_Cancel
      // 
      this.Button_Cancel.Location = new System.Drawing.Point(100, 199);
      this.Button_Cancel.Margin = new System.Windows.Forms.Padding(0);
      this.Button_Cancel.Name = "Button_Cancel";
      this.Button_Cancel.Size = new System.Drawing.Size(100, 32);
      this.Button_Cancel.TabIndex = 7;
      this.Button_Cancel.TabStop = false;
      this.Button_Cancel.Text = "Storno";
      this.Button_Cancel.UseVisualStyleBackColor = true;
      this.Button_Cancel.Click += new System.EventHandler(this.Button_Cancel_Click);
      // 
      // ListBox
      // 
      this.ListBox.FormattingEnabled = true;
      this.ListBox.Location = new System.Drawing.Point(0, 0);
      this.ListBox.Margin = new System.Windows.Forms.Padding(0);
      this.ListBox.Name = "ListBox";
      this.ListBox.Size = new System.Drawing.Size(200, 199);
      this.ListBox.TabIndex = 10;
      this.ListBox.TabStop = false;
      this.ListBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListBox_MouseDoubleClick);
      // 
      // ListSelection
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(200, 231);
      this.Controls.Add(this.ListBox);
      this.Controls.Add(this.Button_Apply);
      this.Controls.Add(this.Button_Cancel);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.Name = "ListSelection";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "(unset)";
      this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyboardShortcuts);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button Button_Apply;
    private System.Windows.Forms.Button Button_Cancel;
    private System.Windows.Forms.ListBox ListBox;
  }
}