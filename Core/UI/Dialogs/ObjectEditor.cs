using System;
using System.Windows.Forms;



namespace Core.UI.Dialogs {
  public partial class ObjectEditor : Form {
    public new DialogResult DialogResult;
    public Validator<object> Validator;
    public object FinalValue;



    public ObjectEditor(Validator<object> validator, object initialObject, string labelText) {
      InitializeComponent();
      DialogResult = DialogResult.None;
      Validator = validator;
      PropertyGrid.SelectedObject = initialObject;
      Text = labelText;
    }



    private void Button_Apply_Click(object sender, EventArgs e) {
      object newObject = PropertyGrid.SelectedObject;
      bool isValid = Validator(newObject);

      if (isValid) {
        DialogResult = DialogResult.OK;
        FinalValue = newObject;
        Close();
      }
    }



    private void Button_Cancel_Click(object sender, EventArgs e) {
      DialogResult = DialogResult.Cancel;
      Close();
    }
  }
}
