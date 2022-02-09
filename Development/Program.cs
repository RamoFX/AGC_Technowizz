using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

using Core.Storage;



namespace Development {
  class Program {
    static void Main() {
      //CreateLayout_Example1();
      CreateLayout_Example2();
    }

    static private Layout CreateLayout_Example1() {
      Layout layout = new("Příklad 1", "CCx", new(99999, 99999));



      //Zone creation
      /* code */



      // Export
      layout.Export();
      Console.WriteLine($"Návrh rozložení uložen do \"{ layout.GetPath() }\".");



      return layout;
    }

    static private Layout CreateLayout_Example2() {
      Layout layout = new("Příklad 2", "example", new(15, 8), new Zone[] {
        new("A1", new(0, 0), new(5, 3), ZoneType.Storage, new CarBrand[] {
          new("BM", new(0, 0), new(5, 1), 4),
          new("TO", new(0, 1), new(5, 1), 4),
          new("NM", new(0, 2), new(5, 1), 4)
        }),
        new("B1", new(5, 0), new(5, 4), ZoneType.Storage, new CarBrand[] {
          new("MY", new(0, 0), new(5, 2), 4),
          new("AL", new(0, 2), new(2, 2), 4),
          new("PO", new(2, 2), new(2, 2), 4),
          new("MS", new(4, 2), new(1, 2), 4)
        }),
        new("B2", new(4, 6), new(4, 2), ZoneType.Storage, new CarBrand[] {
          new("VO", new(0, 0), new(4, 1), 4),
          new("SK", new(0, 1), new(4, 1), 4)
        }),
        new("C1", new(11, 0), new(4, 2), ZoneType.Storage, new CarBrand[] {
          new("FI", new(0, 0), new(2, 2), 4),
          new("FO", new(2, 0), new(2, 2), 4)
        }),
        new("C2", new(12, 3), new(3, 1), ZoneType.Storage, new CarBrand[] {
          new("VW", new(0, 0), new(3, 1), 4)
        }),
        new("C3", new(9, 6), new(1, 1), ZoneType.Storage, new CarBrand[] {
          new("PE", new(0, 0), new(1, 1), 4)
        }),
        new("Export", new(11, 5), new(4, 3), ZoneType.Other),
        new("Office", new(0, 5), new(4, 3), ZoneType.Other)
      });

      layout.Export();

      LayoutManager.EnsureLayoutDirectory();
      Process.Start("explorer.exe", Path.GetDirectoryName(layout.GetPath()));

      return layout;
    }
  }
}
