using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;


namespace Communicator {
  public class DatabaseAccess {
    static public string GetCarBrand(string containerCode) {
      /*
       * 
       *  Zde by se měl uskutečnit požadavek na databázi SAP
       *  Aplikace posílá: řetězec - číslo čárkového kódu palety
       *  Aplikace přijímá: řetězec - krátké označení auta (např. PO, MS, ...)
       * 
       */

      // Pseudo database response
      DatabaseAccessDelay();

      return containerCode switch {
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

    static public int GetZonePalletsCount(string warehouseName, string zoneName, string carBrandName) {
      /*
       * 
       *  Zde by se měl uskutečnit požadavek na databázi SAP
       *  Aplikace posílá: řetězec - název skladu (např. CCx, ..)
       *  Aplikace posílá: řetězec - název zóny (např. A1, AB98, ..)
       *  Aplikace posílá: řetězec - název značky nebo modelu auta (např. BM, MS, VO, ..)
       *  Aplikace přijímá: číslo - počet palet pro danou značku nebo model auta v dané zóně
       * 
       */

      // Pseudo database response
      DatabaseAccessDelay();

      if (warehouseName == "CCx") {
        return zoneName switch {
          _ => 0
        };
      } else if (warehouseName == "Neobvyklý") {
        return zoneName switch {
          "A1" => carBrandName switch {
            "BM" => 20,
            "TO" => 15,
            "NM" => 5,
            _ => 0
          },
          "B1" => carBrandName switch {
            "MY" => 11,
            "AL" => 16,
            "PO" => 7,
            "MS" => 1,
            _ => 0
          },
          "B2" => carBrandName switch {
            "VO" => 17,
            "SK" => 17,
            _ => 0
          },
          "C1" => carBrandName switch {
            "FI" => 5,
            "FO" => 5,
            _ => 0
          },
          "C2" => carBrandName switch {
            "VW" => 9,
            _ => 0
          },
          "C3" => carBrandName switch {
            "PE" => 1,
            _ => 0
          },
          _ => 0
        };
      } else {
        return 0;
      }
    }

    static public int GetAveragePalletsLoad(string zoneName, int daysCount) {
      /*
       * 
       *  Zde by se měl uskutečnit požadavek na databázi SAP
       *  Aplikace posílá: řetězec - název zóny (např. A1, AB98, ..)
       *  Aplikace posílá: číslo - počet dní (např. 15, 79, ..)
       *  Aplikace přijímá: číslo - průměrný počet palet v dané zóně za období daysCount
       *  
       */

      // Pseudo database response
      DatabaseAccessDelay();

      return zoneName switch {
        "A1" => 40,
        "B1" => 35,
        "B2" => 34,
        "C1" => 10,
        "C2" => 9,
        "C3" => 1,
        _ => 0
      };
    }



    // Sleep
    static private readonly Random Random = new();

    static private int CallsCount = 0;

    static private void DatabaseAccessDelay() {
      CallsCount++;
      int delay = Random.Next(20, 300);
#if DEBUG
      Thread.Sleep(delay);
#endif
    }

    static public int GetTotalCallsCount() {
      return CallsCount;
    }
  }
}
