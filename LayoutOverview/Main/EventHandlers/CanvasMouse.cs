using System.Windows.Forms;

using Core.UI;



namespace LayoutOverview {
  public partial class Main {
    private void Canvas_Layout_MouseClick(object sender, MouseEventArgs e) {
      if (CurrentLayout == null)
        return;

      var target = Utilities.MatchEntity(e.Location, CurrentUnitSize, CurrentLayout);

      // Hooks
      SetCurrentSelection(target);
    }
  }
}
