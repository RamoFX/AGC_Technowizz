using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Core;
using Core.Extensions;
using Core.Settings;
using Core.UI;
using Core.UI.Dialogs;



namespace LayoutDesigner {
  public partial class Main {
    // Set state
    private void SetCurrentLayout(Layout.Entity layout) {
      this.CurrentLayout = layout;

      if (this.CurrentLayout != null) {
        this.CurrentLayout.Initialize(0);
      }

      // Post-hooks
      this.UpdateState();
    }

    private void SetCurrentSelection(string path) {
      string[] pathPieces = path.Split(this.Tree_Layout.PathSeparator.ToCharArray());
      int level = pathPieces.Length - 1;
      object currentSelection = null;

      // Find currentSelection which can be Layout, Zone or CarBrand
      if (level == 0 || level == 1) {
        if (level == 0) {
          if (pathPieces[level] == this.CurrentLayout.Name) {
            currentSelection = this.CurrentLayout;
          }
        } else {
          foreach (var zone in this.CurrentLayout.Zones) {
            if (level == 1) {
              if (pathPieces[level] == zone.Name) {
                currentSelection = zone;

                break;
              }
            }
          }
        }
      }

      this.CurrentSelection = currentSelection;

      // Post-hooks
      this.CurrentSelectionChangedHandler();
    }



    // Handle state
    private void CurrentLayoutChangedHandler() {
      // Draw
      this.PictureBox_Layout.Refresh();

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
    }
  }
}
