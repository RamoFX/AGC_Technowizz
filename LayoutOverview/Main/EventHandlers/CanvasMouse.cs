using System.Windows.Forms;

using Core.UI;



namespace LayoutOverview {
  public partial class Main {
    private void Canvas_Layout_MouseClick(object sender, MouseEventArgs e) {
      if (this.CurrentLayout == null)
        return;

      var target = Utilities.MatchEntity(e.Location, this.CurrentUnitSize, this.CurrentLayout);

      // Hooks
      this.SetCurrentSelection(target);
    }
  }
}
