using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace LayoutDesigner.UI.Dialogs {
  public partial class UserTextInput : Form {
    public new DialogResult DialogResult;
    public Func<string, bool> ValueValidator;
    public string FinalValue;

    public UserTextInput(Func<string, bool> valueValidator, string labelText) {
      InitializeComponent();
      this.DialogResult = DialogResult.None;
      this.ValueValidator = valueValidator;
      this.Label.Text = labelText;
    }

    private void Button_Apply_Click(object sender, EventArgs e) {
      string newName = TextBox.Text;
      bool isValid = this.ValueValidator(newName);

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
  }
}
