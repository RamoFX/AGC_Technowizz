namespace ZoneAssigner {
  public partial class Main {
    private void CurrentLayoutChangedHandler() {
      // Draw
      this.Canvas_Layout.Refresh();
    }



    private void CurrentSelectionChangedHandler() {
      // Redraw
      this.Canvas_Layout.Refresh();
    }
  }
}
