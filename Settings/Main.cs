using System;
using System.Windows.Forms;



namespace Settings {
  public partial class Main : Form {
    public Main() {
      InitializeComponent();
    }

    private void Main_Load(object sender, EventArgs e) {
      propertyGrid.SelectedObject = new SettingsProperties();
    }
  }
}
