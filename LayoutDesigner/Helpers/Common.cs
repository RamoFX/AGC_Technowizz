using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace LayoutDesigner.Helpers {
  static class Common {
    static public void SwitchToForm(Form from, Form to) {
      from.Hide();
      to.ShowDialog();
      from.Close();
    }
  }
}
