using System;
using System.Collections.Generic;
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
      //ExampleLayoutUsage();

      Console.WriteLine("\nPress any key for exit...");
      Console.ReadKey();
    }

    static private Layout? CreateExampleLayout() {
      static string[] CarBrands(params string[] carBrands) {
        return carBrands;
      }

      Layout example2 = new("Example2", new(15, 8));

      Zone a1 = new("A1", new(0, 0), new(5, 3), 4, ZoneType.Storage, CarBrands("BM", "TO", "NM", "MY"));
      Zone b1 = new("B1", new(5, 0), new(5, 4), 4, ZoneType.Storage, CarBrands("AL"));
      Zone b2 = new("B2", new(4, 5), new(4, 2), 4, ZoneType.Storage, CarBrands("PO", "MS", "VO"));
      Zone c1 = new("C1", new(11, 0), new(4, 2), 4, ZoneType.Storage, CarBrands("SK", "FI"));
      Zone c2 = new("C2", new(12, 3), new(1, 3), 4, ZoneType.Storage, CarBrands("AL", "TO", "VW"));
      Zone c3 = new("C3", new(9, 6), new(1, 1), 4, ZoneType.Storage, CarBrands("MY", "FO", "PE"));

      Zone export = new("Export", new(11, 5), new(4, 3), 0, ZoneType.Other);
      Zone office = new("Office", new(0, 5), new(4, 3), 0, ZoneType.Other);

      example2.Zones.Add(a1);
      example2.Zones.Add(b1);
      example2.Zones.Add(b2);
      example2.Zones.Add(c1);
      example2.Zones.Add(c2);
      example2.Zones.Add(c3);
      example2.Zones.Add(office);
      example2.Zones.Add(export);

      example2.Export();

      Console.WriteLine($"Návrh rozložení uložen do \"{ example2.GetPath() }\".");
      return example2;
    }

    static private void ExampleLayoutUsage() {
      Layout? exampleLayout = CreateExampleLayout();

      if (exampleLayout != null) {
        const string carBrand = "AL";
        string zone = exampleLayout.GetFirstSuitableZoneOrDefault(carBrand)?.Name ?? "×";

        Console.WriteLine($"Kam ukládat palety pro značku \"{ carBrand }\"? \nSem: { zone }");
      }
    }
  }
}

