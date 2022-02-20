using System;
using System.ComponentModel;
using System.Windows.Forms;



namespace Core.UI.Dialogs {
  public partial class ObjectEditor : Form {
    public new DialogResult DialogResult;
    public Validator<object> Validator;
    public object FinalValue;



    public ObjectEditor(Validator<object> validator, object initialObject, string labelText) {
      InitializeComponent();
      this.DialogResult = DialogResult.None;
      this.Validator = validator;
      this.PropertyGrid.SelectedObject = initialObject;
      this.Text = labelText;
    }



    private void Button_Apply_Click(object sender, EventArgs e) {
      object newObject = PropertyGrid.SelectedObject;
      bool isValid = this.Validator(newObject);

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
