﻿
namespace Core.UI.Dialogs {
  partial class UserSelect {
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
      this.Label = new System.Windows.Forms.Label();
      this.Button_Cancel = new System.Windows.Forms.Button();
      this.ListBox = new System.Windows.Forms.ListBox();
      this.SuspendLayout();
      // 
      // Button_Apply
      // 
      this.Button_Apply.Location = new System.Drawing.Point(61, 256);
      this.Button_Apply.Name = "Button_Apply";
      this.Button_Apply.Size = new System.Drawing.Size(101, 34);
      this.Button_Apply.TabIndex = 9;
      this.Button_Apply.Text = "Použít";
      this.Button_Apply.UseVisualStyleBackColor = true;
      this.Button_Apply.Click += new System.EventHandler(this.Button_Apply_Click);
      // 
      // Label
      // 
      this.Label.AutoSize = true;
      this.Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Label.Location = new System.Drawing.Point(58, 33);
      this.Label.Name = "Label";
      this.Label.Size = new System.Drawing.Size(48, 16);
      this.Label.TabIndex = 8;
      this.Label.Text = "(unset)";
      // 
      // Button_Cancel
      // 
      this.Button_Cancel.Location = new System.Drawing.Point(173, 256);
      this.Button_Cancel.Name = "Button_Cancel";
      this.Button_Cancel.Size = new System.Drawing.Size(101, 34);
      this.Button_Cancel.TabIndex = 7;
      this.Button_Cancel.Text = "Storno";
      this.Button_Cancel.UseVisualStyleBackColor = true;
      this.Button_Cancel.Click += new System.EventHandler(this.Button_Cancel_Click);
      // 
      // ListBox
      // 
      this.ListBox.FormattingEnabled = true;
      this.ListBox.Location = new System.Drawing.Point(61, 64);
      this.ListBox.Name = "ListBox";
      this.ListBox.Size = new System.Drawing.Size(213, 186);
      this.ListBox.TabIndex = 10;
      // 
      // NewSelect
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(335, 340);
      this.Controls.Add(this.ListBox);
      this.Controls.Add(this.Button_Apply);
      this.Controls.Add(this.Label);
      this.Controls.Add(this.Button_Cancel);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.Name = "NewSelect";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Výběr";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button Button_Apply;
    private System.Windows.Forms.Label Label;
    private System.Windows.Forms.Button Button_Cancel;
    private System.Windows.Forms.ListBox ListBox;
  }
}