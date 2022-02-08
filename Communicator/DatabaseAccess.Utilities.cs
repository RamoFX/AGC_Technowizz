using System;
using System.Threading;



namespace Communicator {
  public partial class DatabaseAccess {
    static internal readonly int MinimumDelay = 20;
    static internal readonly int MaximumDelay = 150;

    static internal readonly Random Random = new();

    static internal void SimulateDelay() {
      CallsCount++;

      if (!DoSimulateDelay)
        return;

      int delay = Random.Next(20, 300);
      Thread.Sleep(delay);
    }
  }
}
