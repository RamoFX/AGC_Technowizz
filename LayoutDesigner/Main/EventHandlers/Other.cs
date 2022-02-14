using System.Windows.Forms;



namespace LayoutDesigner {
  public partial class Main {
    // Other
    private void TreeView_Layout_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e) {
      this.SetCurrentSelection(e.Node.FullPath);
    }

    private void PropertyGrid_CurrentSelection_PropertyValueChanged(object s, PropertyValueChangedEventArgs e) {
      this.UpdateState();
    }

    private void PictureBox_Layout_Paint(object sender, PaintEventArgs e) {
      this.DrawLayout(e.Graphics);
    }
  }
}
