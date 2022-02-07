﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;



namespace Core.UI.Dialogs {
  public partial class UserSelect : Form {
    public new DialogResult DialogResult;
    public object FinalValue;



    public UserSelect(List<object> selectItems, string displayMember, string labelText) {
      InitializeComponent();
      this.DialogResult = DialogResult.None;
      this.ListBox.DataSource = selectItems;
      this.ListBox.DisplayMember = displayMember;
      this.Label.Text = labelText;
    }



    private void Button_Apply_Click(object sender, EventArgs e) {
      object selected = this.ListBox.SelectedValue;
      bool isSelected = selected != null;

      if (isSelected) {
        this.DialogResult = DialogResult.OK;
        this.FinalValue = selected;
        this.Close();
      }
    }



    private void Button_Cancel_Click(object sender, EventArgs e) {
      this.DialogResult = DialogResult.Cancel;
      this.Close();
    }
  }
}