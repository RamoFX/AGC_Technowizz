using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Core.UI.Dialogs {
  public partial class Dialog : Form {
    public new DialogResult DialogResult;

    public Dialog(string title) {
      InitializeComponent();
      this.DialogResult = DialogResult.None;
      this.Text = title;
    }
  }
}
