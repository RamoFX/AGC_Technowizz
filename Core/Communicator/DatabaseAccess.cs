using Core.Helpers;
using Core.Storage;
using System;
using System.Linq;


namespace Core.Communicator
{
  public class DatabaseAccess {
    static public string GetCarBrandFromContainerCode(string containerCode) {
      /*
       * 
       *  Zde by se měl uskutečnit požadavek na databázi SAP
       *  Aplikace posílá: řetězec - číslo čárkového kódu palety
       *  Aplikace přijímá: řetězec - krátké označení auta (např. PO, MS, ...)
       * 
       */

      // Pseudo database response
      DatabaseAccessDelay();
      return containerCode switch
      {
        "0" => "BM",
        "1" => "TO",
        "2" => "NM",
        "3" => "MY",
        "4" => "AL",
        "5" => "PO",
        "6" => "MS",
        "7" => "VO",
        "8" => "SK",
        "9" => "FI",
        "10" => "VW",
        "11" => "FO",
        "12" => "PE",
        _ => ""
      };
    }

    static public int GetZonePalletsCountFromZoneName(string zoneName) {
      /*
       * 
       *  Zde by se měl uskutečnit požadavek na databázi SAP
       *  Aplikace posílá: řetězec - název zóny (např. A1, AB98, ..)
       *  Aplikace přijímá: číslo - počet palet v dané zóně
       * 
       */

      // Pseudo database response
      DatabaseAccessDelay();
      return zoneName switch {
        "A1" => 28,
        "B1" => 31,
        "B2" => 17,
        "C1" => 5,
        "C2" => 9,
        "C3" => 1,
        _ => 0
      };
    }

    static public int GetAveragePalletsLoadFromZoneNameAndDaysCount(string zoneName, int daysCount) {
      /*
       * 
       *  Zde by se měl uskutečnit požadavek na databázi SAP
       *  Aplikace posílá: řetězec - název zóny (např. A1, AB98, ..)
       *  Aplikace posílá: číslo - počet dní (např. 15, 79, ..)
       *  Aplikace přijímá: číslo - průměrný počet palet v dané zóně za období daysCount
       *  
       */

      // Pseudo database response
      Func<string, int> zoneNameToAveragePalletsLoad = (zn) => {
        Random random = new(daysCount);
        Layout layout = Layout.Import(DynamicSettings.ZA_StartupLayoutName.Value);
        Zone zone = layout.Zones.Find(zone => zone.Name == zn);
        bool isZoneStorage = zone.Type == ZoneType.Storage;

        return zn.ToCharArray().Aggregate(0, (sum, @char) => isZoneStorage ? ( sum + @char + random.Next((int) ( zone.MaxCapacity * 0.1 )) ) % zone.MaxCapacity : 0);
      };

      DatabaseAccessDelay();
      return zoneName switch {
        "A1" => zoneNameToAveragePalletsLoad("A1"),
        "B1" => zoneNameToAveragePalletsLoad("B1"),
        "B2" => zoneNameToAveragePalletsLoad("B2"),
        "C1" => zoneNameToAveragePalletsLoad("C1"),
        "C2" => zoneNameToAveragePalletsLoad("C2"),
        "C3" => zoneNameToAveragePalletsLoad("C3"),
        _ => 0
      };
    }


    static private readonly Random Random = new();

    static private void DatabaseAccessDelay() {
      int delay = Random.Next(20, 300);
      System.Threading.Thread.Sleep(delay);
    }
  }
}
