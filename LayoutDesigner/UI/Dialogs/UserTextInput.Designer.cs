
namespace LayoutDesigner.UI.Dialogs {
  partial class UserTextInput {
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
      this.Label = new System.Windows.Forms.Label();
      this.Button_Apply = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // TextBox
      // 
      this.TextBox.Location = new System.Drawing.Point(62, 60);
      this.TextBox.Name = "TextBox";
      this.TextBox.Size = new System.Drawing.Size(254, 20);
      this.TextBox.TabIndex = 0;
      // 
      // Button_Cancel
      // 
      this.Button_Cancel.Location = new System.Drawing.Point(195, 96);
      this.Button_Cancel.Name = "Button_Cancel";
      this.Button_Cancel.Size = new System.Drawing.Size(101, 33);
      this.Button_Cancel.TabIndex = 1;
      this.Button_Cancel.Text = "Storno";
      this.Button_Cancel.UseVisualStyleBackColor = true;
      this.Button_Cancel.Click += new System.EventHandler(this.Button_Cancel_Click);
      // 
      // Label
      // 
      this.Label.AutoSize = true;
      this.Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Label.Location = new System.Drawing.Point(59, 31);
      this.Label.Name = "Label";
      this.Label.Size = new System.Drawing.Size(48, 16);
      this.Label.TabIndex = 2;
      this.Label.Text = "(unset)";
      // 
      // Button_Apply
      // 
      this.Button_Apply.Location = new System.Drawing.Point(83, 96);
      this.Button_Apply.Name = "Button_Apply";
      this.Button_Apply.Size = new System.Drawing.Size(101, 33);
      this.Button_Apply.TabIndex = 3;
      this.Button_Apply.Text = "Použít";
      this.Button_Apply.UseVisualStyleBackColor = true;
      this.Button_Apply.Click += new System.EventHandler(this.Button_Apply_Click);
      // 
      // UserTextInput
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(378, 159);
      this.Controls.Add(this.Button_Apply);
      this.Controls.Add(this.Label);
      this.Controls.Add(this.Button_Cancel);
      this.Controls.Add(this.TextBox);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MinimizeBox = false;
      this.Name = "UserTextInput";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Zadejte hodnotu";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox TextBox;
    private System.Windows.Forms.Button Button_Cancel;
    private System.Windows.Forms.Label Label;
    private System.Windows.Forms.Button Button_Apply;
  }
}