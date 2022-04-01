﻿namespace ZoneAssigner {
  public partial class Main {
    private void CurrentLayoutChangedHandler() {
      // Draw
      Canvas_Layout.Refresh();
    }



    private void CurrentSelectionChangedHandler() {
      // Reinitialize data
      CurrentLayout.Initialize(DAYS_PERIOD);

      // Redraw
      Canvas_Layout.Refresh();
    }
  }
}
