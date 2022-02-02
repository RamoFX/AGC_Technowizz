using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using Core.Storage;



namespace Core.Communicator
{
  static public class DataProcessing
  {
    public static Layout layout;

    const string layoutName = "Example";
    const string FullErrorMessage = "Plno";

    public static Dictionary<string, string> containerCode_name = new();

    public static void Setup()
    {
      layout = Layout.Import(layoutName);

      // Load test data
      using (StreamReader sr = new("../test_data.csv"))
      {
        sr.ReadLine();
        while (!sr.EndOfStream)
        {
          string[] items_in_line = sr.ReadLine().Split(';');
          string number = Convert.ToInt32(items_in_line[7]).ToString();
          string name = items_in_line[5].Trim();
          containerCode_name.Add(number, name.Split(' ')[2].Trim());
        }
      }
    }

    public static string GetZoneFromCarBrand(string carBrand)
    {
      IEnumerable<Zone> suitableZones = layout.GetSuitableZones(carBrand);

      if (suitableZones.Count() > 0) {
        return suitableZones.First().Name;
      } else {
        return "X";
      }
    }

    public static string[] ShowEmptyZones()
    {
      return layout.Zones
        .FindAll(zone => zone.PalletsCanBeStored == 0)
        .Select(zone => zone.Name)
        .ToArray();
    }
  }
}
