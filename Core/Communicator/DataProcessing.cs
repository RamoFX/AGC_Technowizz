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

    public static Dictionary<string, string> containerCode_name = new Dictionary<string, string>();

    static bool IsZoneFull(Zone zone) {
      if (zone.PalletsCurrentlyStored == zone.PalletsCanBeStored) return true;
      return false;
    }

    public static void Setup() {
      layout = Layout.Import(layoutName);
      //DatabaseAccess.LoadDataFromDatabase();

      // Load test data
      using (StreamReader sr = new StreamReader("../test_data.csv")) {
        sr.ReadLine();
        while (!sr.EndOfStream) {
          string[] items_in_line = sr.ReadLine().Split(';');
          string number = Convert.ToInt32(items_in_line[7]).ToString();
          string name = items_in_line[5].Trim();
          containerCode_name.Add(number, name.Split(' ')[2].Trim());
        }
      }
    }

    public static string GetZoneFromCarBrand(string carBrand) {
      foreach (Zone zone in layout.Zones) {
        if (zone.CarBrands.Contains(carBrand.ToLower()) && !IsZoneFull(zone))
          return zone.Name;
      }
      return "X";
    }

    public static string[] ShowEmptyZones() {
      List<string> returnArray = new List<string>();
      foreach (Zone zone in layout.Zones)
        if (zone.PalletsCurrentlyStored == 0 && zone.Type == ZoneType.Storage) returnArray.Add(zone.Name);

      return returnArray.ToArray();
    }
  }
}
