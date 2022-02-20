namespace LayoutDesigner {
  public partial class Main {
    private void CurrentLayoutChangedHandler() {
      // Draw
      this.Canvas_Layout.Refresh();

      // Tree view
      this.Tree_Layout.Nodes.Clear();

      if (this.CurrentLayout == null)
        return;

      // Add nodes
      var rootNode = Tree_Layout.Nodes.Add(this.CurrentLayout.Name);

      foreach (var zone in this.CurrentLayout.Zones) {
        rootNode.Nodes.Add(zone.Name);
      }

      this.Tree_Layout.ExpandAll();
    }



    private void CurrentSelectionChangedHandler() {
      // Property grid
      this.Properties_CurrentSelection.SelectedObject = this.CurrentSelection;

      // Select correct tree view node
      this.Tree_Layout.SelectedNode = null;

      // Redraw
      this.Canvas_Layout.Refresh();
    }
  }
}
