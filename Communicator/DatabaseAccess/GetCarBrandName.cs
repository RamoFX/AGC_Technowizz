namespace Communicator {
  public partial class DatabaseAccess {
    static public string GetCarBrandName(string warehouseName, string palletCode) {
      /*
       *
       *  Zde by se měl uskutečnit požadavek na databázi SAP
       *
       *  Aplikace posílá:
       *    - řetězec warehouseName (název skladu, např. CCx, ...)
       *    - řetězec palletCode (číslo čárkového kódu palety)
       *
       *  Aplikace přijímá:
       *    - řetězec (název značky nebo modelu auta, např. BM, MS, VO, ...)
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
        return palletCode switch {
          _ => ""
        };
      }



      if (warehouseName == "example") {
        return palletCode switch {
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



      return "";
    }
  }
}
