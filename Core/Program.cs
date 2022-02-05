using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

using Core.Helpers;
using Core.Storage;



namespace Core {
  // Use for development testing or debugging, won't be used as entrypoint
  class Program {
    static void Main() {
      //CreateLayout_Example1();
      CreateLayout_Example2();

      Console.WriteLine("\nPress any key for exit...");
      Console.ReadKey();
    }

    static private Layout CreateLayout_Example1() {
      Layout layout = new("Příklad 1", "CCx", new(99999, 99999), 4);



      //Zone creation
      /* code */



      // Export
      layout.Export();
      Console.WriteLine($"Návrh rozložení uložen do \"{ layout.GetPath() }\".");



      return layout;
    }

    static private Layout CreateLayout_Example2() {
      Layout layout = new("Příklad 2", "Neobvyklý", new(15, 8), 4, new Zone[] {
        new("A1", new(0, 0), new(5, 3), ZoneType.Storage, new CarBrand[] {
          new("BM", new(0, 0), new(5, 1)),
          new("TO", new(0, 1), new(5, 1)),
          new("NM", new(0, 2), new(5, 1))
        }),
        new("B1", new(5, 0), new(5, 4), ZoneType.Storage, new CarBrand[] {
          new("MY", new(5, 0), new(5, 2)),
          new("AL", new(5, 2), new(2, 2)),
          new("PO", new(7, 2), new(2, 2)),
          new("MS", new(9, 2), new(1, 2))
        }),
        new("B2", new(4, 5), new(4, 2), ZoneType.Storage, new CarBrand[] {
          new("VO", new(4, 5), new(4, 1)),
          new("SK", new(4, 6), new(4, 1))
        }),
        new("C1", new(11, 0), new(4, 2), ZoneType.Storage, new CarBrand[] {
          new("FI", new(11, 0), new(2, 2)),
          new("FO", new(13, 0), new(2, 2))
        }),
        new("C2", new(12, 3), new(1, 3), ZoneType.Storage, new CarBrand[] {
          new("VW", new(12, 3), new(1, 3))
        }),
        new("C3", new(9, 6), new(1, 1), ZoneType.Storage, new CarBrand[] {
          new("PE", new(9, 6), new(1, 1))
        }),
        new("Export", new(11, 5), new(4, 3), ZoneType.Other),
        new("Office", new(0, 5), new(4, 3), ZoneType.Other)
      });

      layout.Export();
      Process.Start("explorer.exe", Path.GetDirectoryName(layout.GetPath()));

      return layout;
    }
  }
}

