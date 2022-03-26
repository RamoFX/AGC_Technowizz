namespace ZoneAssigner {
  public partial class Main {
    private void CurrentLayoutChangedHandler() {
      // Draw
      Canvas_Layout.Refresh();
    }



    private void CurrentSelectionChangedHandler() {
      // Redraw
      Canvas_Layout.Refresh();
    }
  }
}
