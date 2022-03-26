namespace LayoutOverview {
  public partial class Main {
    private void CurrentLayoutChangedHandler() {
      // Draw
      Canvas_Layout.Refresh();

      // Tree view
      Tree_Layout.Nodes.Clear();

      if (CurrentLayout == null)
        return;

      // Add nodes
      var rootNode = Tree_Layout.Nodes.Add(CurrentLayout.Name);

      foreach (var zone in CurrentLayout.Zones) {
        if (zone.IsLoadable())
          rootNode.Nodes.Add($"{ zone.Name } ({ zone.StoredPercent } %)");

        else
          rootNode.Nodes.Add(zone.Name);
      }

      Tree_Layout.ExpandAll();
    }



    private void CurrentSelectionChangedHandler() {
      // Property grid
      Properties_CurrentSelection.SelectedObject = CurrentSelection;

      // Select correct tree view node
      Tree_Layout.SelectedNode = null;

      // Redraw
      Canvas_Layout.Refresh();
    }
  }
}
