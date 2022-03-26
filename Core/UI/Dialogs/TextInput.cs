using System;
using System.Windows.Forms;



namespace Core.UI.Dialogs {
  public partial class TextInput : Form {
    public new DialogResult DialogResult;
    public Validator<string> Validator;
    public string FinalValue;



    public TextInput(Validator<string> validator, string label, string initialValue) {
      InitializeComponent();
      DialogResult = DialogResult.None;
      Validator = validator;
      Text = label;
      TextBox.Text = initialValue;
    }

    public TextInput(Validator<string> validator, string label)
      : this(validator, label, "") { }



    private void Button_Apply_Click(object sender, EventArgs e) {
      string newName = TextBox.Text;
      bool isValid = Validator(newName);

      if (isValid) {
        DialogResult = DialogResult.OK;
        FinalValue = newName;
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
  }
}
