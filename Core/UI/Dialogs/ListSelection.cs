using System;
using System.Collections.Generic;
using System.Windows.Forms;



namespace Core.UI.Dialogs {
  public partial class ListSelection : Form {
    public new DialogResult DialogResult;
    public object FinalValue;



    public ListSelection(List<object> selectItems, string displayMember, string labelText) {
      InitializeComponent();
      DialogResult = DialogResult.None;
      ListBox.DataSource = selectItems;
      ListBox.DisplayMember = displayMember;
      Text = labelText;
    }



    private void Button_Apply_Click(object sender, EventArgs e) {
      object selected = ListBox.SelectedValue;
      bool isSelected = selected != null;

      if (isSelected) {
        DialogResult = DialogResult.OK;
        FinalValue = selected;
        Close();
      }
    }



    private void Button_Cancel_Click(object sender, EventArgs e) {
      DialogResult = DialogResult.Cancel;
      Close();
    }



    private void KeyboardShortcuts(object sender, KeyEventArgs e) {
      switch (e.KeyCode) {
        case Keys.Enter:
          Button_Apply.PerformClick();
          break;

        case Keys.Escape:
          Button_Cancel.PerformClick();
          break;
      }
    }



    private void ListBox_MouseDoubleClick(object sender, MouseEventArgs e) {
      Button_Apply.PerformClick();
    }
  }
}
