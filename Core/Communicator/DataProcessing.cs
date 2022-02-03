using Core.Storage;
using System;
using System.Collections.Generic;
using System.IO;



namespace Core.Communicator
{
  static public class DataProcessing
  {
    public static Layout ActiveLayout;
    public static Dictionary<string, string> containerCode_name = new Dictionary<string, string>();

    static bool IsZoneFull(Zone zone) => zone.PalletsCurrentlyStored == zone.PalletsCanBeStored;

    public static void Setup(string layoutName = "Example") {
      ActiveLayout = Layout.Import(layoutName);

      string PathToLastLayout = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
        "AGC_Technowizz_Layouts",
        "Layout.last"
      );

      File.WriteAllText(
        PathToLastLayout,
        layoutName,
        System.Text.Encoding.UTF8
      );

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
      foreach (Zone zone in ActiveLayout.Zones) {
        if (zone.CarBrands.Contains(carBrand) && !IsZoneFull(zone))
          return zone.Name;
      }
      return "X";
    }

    public static string[] ShowEmptyZones() {
      List<string> returnArray = new List<string>();
      foreach (Zone zone in ActiveLayout.Zones)
        if (zone.PalletsCurrentlyStored == 0 && zone.Type == ZoneType.Storage) returnArray.Add(zone.Name);

      return returnArray.ToArray();
    }
  }
}
