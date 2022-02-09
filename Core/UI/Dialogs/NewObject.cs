using System;
using System.Windows.Forms;



namespace Core.UI.Dialogs {
  public partial class NewObject : Form {
    public new DialogResult DialogResult;
    public Func<object, bool> ValueValidator;
    public object FinalValue;



    public NewObject(Func<object, bool> valueValidator, object initialObject, string labelText) {
      InitializeComponent();
      this.DialogResult = DialogResult.None;
      this.ValueValidator = valueValidator;
      this.PropertyGrid.SelectedObject = initialObject;
      this.Label.Text = labelText;
    }



    private void Button_Apply_Click(object sender, EventArgs e) {
      object newObject = PropertyGrid.SelectedObject;
      bool isValid = this.ValueValidator(newObject);

      if (isValid) {
        this.DialogResult = DialogResult.OK;
        this.FinalValue = newObject;
        this.Close();
      }
    }



    private void Button_Cancel_Click(object sender, EventArgs e) {
      this.DialogResult = DialogResult.Cancel;
      this.Close();
    }



    private void KeyboardShortcuts(object sender, KeyEventArgs e)
    {
      MessageBox.Show("");
      switch (e.KeyCode)
      {
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
