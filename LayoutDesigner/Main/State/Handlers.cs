namespace LayoutDesigner {
  public partial class Main {
    private void CurrentLayoutChangedHandler() {
      // Draw
      this.Canvas_Layout.Refresh();

      // TreeView
      this.Tree_Layout.Nodes.Clear();

      if (this.CurrentLayout != null) {
        var rootNode = Tree_Layout.Nodes.Add(this.CurrentLayout.Name);

        foreach (var zone in this.CurrentLayout.Zones) {
          rootNode.Nodes.Add(zone.Name);
        }

        this.Tree_Layout.ExpandAll();
      }
    }



    private void CurrentSelectionChangedHandler() {
      this.Properties_CurrentSelection.SelectedObject = this.CurrentSelection;
      this.Canvas_Layout.Refresh();
    }
  }
}
