using System;
using System.Windows.Forms;



namespace Core.UI.Dialogs {
  public partial class TextInput : Form {
    public new DialogResult DialogResult;
    public Validator<string> Validator;
    public string FinalValue;



    public TextInput(Validator<string> validator, string label, string initialValue) {
      InitializeComponent();
      this.DialogResult = DialogResult.None;
      this.Validator = validator;
      this.Text = label;
      this.TextBox.Text = initialValue;
    }

    public TextInput(Validator<string> validator, string label)
      : this(validator, label, "") { }



    private void Button_Apply_Click(object sender, EventArgs e) {
      string newName = TextBox.Text;
      bool isValid = this.Validator(newName);

      if (isValid) {
        this.DialogResult = DialogResult.OK;
        this.FinalValue = newName;
        this.Close();
      }
    }



    private void Button_Cancel_Click(object sender, EventArgs e) {
      this.DialogResult = DialogResult.Cancel;
      this.Close();
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
