using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Core.UI.Dialogs
{
  public partial class Help : Form
  {
    public Help()
    {
      InitializeComponent();
    }

    private void Help_Load(object sender, EventArgs e)
    {
      Color100_PictureBox.BackColor = Colors.Color100;
      Color99_75_PictureBox.BackColor = Colors.Color99_75;
      Color74_50_PictureBox.BackColor = Colors.Color74_50;
      Color49_25_PictureBox.BackColor = Colors.Color49_25;
      Color24_1_PictureBox.BackColor = Colors.Color24_1;
      Color0_PictureBox.BackColor = Colors.Color0;
    }
  }
}
