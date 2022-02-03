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
  public partial class NewName : Form {
    public new DialogResult DialogResult = DialogResult.None;
    public string FinalName;

    public NewName() {
      InitializeComponent();
    }

    private bool ValidateNewName(string newName) {
      Regex regex = new("^[a-zA-Z]$");

      if (newName.Trim().Length == 0) {
        MessageBox.Show("Textové pole nesmí být prázdné.");
        return false;
      } else if (regex.IsMatch(newName)) {
        MessageBox.Show("Textové pole smí obsahovat pouze malá nebo velká písmena A-Z.");
        return false;
      } else {
        return true;
      }
    }

    private void Button_Apply_Click(object sender, EventArgs e) {
      string newName = TextBox_NewName.Text;
      bool isValid = this.ValidateNewName(newName);

      if (isValid) {
        this.DialogResult = DialogResult.OK;
        this.FinalName = newName;
        this.Close();
      }
    }

    private void Button_Cancel_Click(object sender, EventArgs e) {
      this.DialogResult = DialogResult.Cancel;
      this.Close();
    }
  }
}
