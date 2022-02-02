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
      ExampleLayoutUsage();
    }

    static private Layout? CreateExampleLayout() {
      static string[] CarBrands(params string[] carBrands) {
        return carBrands;
      }

      Layout example = new("Example", new(15, 8));

      Zone a1 = new("a1", new(0, 0), new(5, 3), 4, ZoneType.Storage, CarBrands("bm", "to"));
      Zone b1 = new("b1", new(5, 0), new(5, 4), 4, ZoneType.Storage, CarBrands("al"));
      Zone b2 = new("b2", new(4, 5), new(4, 2), 4, ZoneType.Storage, CarBrands("po"));
      Zone c1 = new("c1", new(11, 0), new(4, 2), 4, ZoneType.Storage, CarBrands("sk"));
      Zone c2 = new("c2", new(12, 3), new(1, 3), 4, ZoneType.Storage, CarBrands("al", "to"));
      Zone c3 = new("c3", new(9, 6), new(1, 1), 4, ZoneType.Storage, CarBrands("my"));

      Zone export = new("Export", new(11, 5), new(4, 3), 0, ZoneType.Other);
      Zone office = new("Office", new(0, 5), new(4, 3), 0, ZoneType.Other);

      example.Zones.Add(a1);
      example.Zones.Add(b1);
      example.Zones.Add(b2);
      example.Zones.Add(c1);
      example.Zones.Add(c2);
      example.Zones.Add(c3);
      example.Zones.Add(office);
      example.Zones.Add(export);

      bool didExport = example.Export();

      if (didExport) {
        Console.WriteLine($"Návrh rozložení uložen do \"{ example.GetPath() }\".");
        return example;
      } else {
        Console.WriteLine($"Návrh rozložení nebyl uložen.");
        return null;
      }
    }

    static private void ExampleLayoutUsage() {
      Layout? exampleLayout = CreateExampleLayout();

      if (exampleLayout != null) {
        const string carBrand = "bm";
        IEnumerable<string> suitableZonesNames = exampleLayout.GetCarBrandSuitableZonesNames(carBrand);

        Console.WriteLine($"Kam ukládat palety pro značku \"{ carBrand }\"? \nSem: { string.Join(", ", suitableZonesNames) }");
      }

      Console.WriteLine("Press any key for exit...");
      Console.ReadKey();
    }
  }
}
