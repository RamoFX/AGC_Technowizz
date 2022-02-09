using System;
using System.Windows.Forms;



namespace Core.UI.Dialogs {
  public partial class UserNewObject : Form {
    public new DialogResult DialogResult;
    public Func<object, bool> ValueValidator;
    public object FinalValue;



    public UserNewObject(Func<object, bool> valueValidator, object initialObject, string labelText) {
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
  }
}
