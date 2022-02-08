namespace Communicator {
  public partial class DatabaseAccess {
    static public int GetPalletsCount(string warehouseName, string zoneName, string carBrandName, int daysCount) {
      /*
       * 
       *  Zde by se měl uskutečnit požadavek na databázi SAP
       *  
       *  Aplikace posílá:
       *    - řetězec warehouseName (název skladu, např. CCx, ...)
       *    - řetězec zoneName (název zóny, např. A1, AB98, ...)
       *    - řetězec carBrandName (název značky nebo modelu auta , např. BM, MS, VO, ...)
       *    - číslo daysCount - počet dní (např. 15, 79, ...)
       *    
       *  Aplikace přijímá:
       *    - číslo (průměrný počet palet v dané zóně za období daysCount)
       *  
       */



      ///////////////////////////
      // Pseudo database delay //
      ///////////////////////////
      
      SimulateDelay();



      //////////////////////////////
      // Pseudo database response //
      //////////////////////////////

      if (warehouseName == "CCx") {
        return zoneName switch {
          _ => 0
        };
      }



      if (warehouseName == "Neobvyklý") {
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
      }



      return 0;
    }
  }
}
