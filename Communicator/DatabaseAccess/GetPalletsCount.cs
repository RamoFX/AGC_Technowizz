namespace Communicator {
  public partial class DatabaseAccess {
    static public int GetPalletsCount(string warehouseName, string zoneName, int daysPeriod) {
      /*
       *
       *  Zde by se měl uskutečnit požadavek na databázi SAP
       *
       *  Aplikace posílá:
       *    - řetězec warehouseName - název skladu (např. CCx, ...)
       *    - řetězec zoneName - název zóny (např. C3, AB98, ...)
       *    - číslo daysCount - počet dní (např. 15, 79, ...)
       *
       *  Aplikace přijímá:
       *    - číslo - průměrný počet palet v dané zóně za období daysCount
       *
       */



      ////////////
      // Guards //
      ////////////

      if (daysPeriod == 0)
        return 0;



      ///////////////////////////
      // Pseudo database delay //
      ///////////////////////////

      SimulateDelay();



      //////////////////////////////
      // Pseudo database response //
      //////////////////////////////

      if (warehouseName == "CCx") {
        return zoneName switch {
          "C1" => 28,
          "C2" => 3,
          "C3" => 17,
          "C4" => 37,
          "C5" => 26,
          "C6" => 18,
          "C7" => 23,
          "C8" => 5,
          "C9" => 16,
          "C10" => 20,
          "C11" => 9,
          "C12" => 20,
          _ => 0
        };
      }



      return 0;
    }
  }
}
