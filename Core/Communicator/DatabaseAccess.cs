using System;
using System.Linq;



namespace Core.Communicator {
  public class DatabaseAccess {
    public static string GetCarBrandFromContainerCode(string containerCode) {
      /*
       * 
       * Zde by se měl uskutečnit požadavek na databázi SAP
       * Aplikace posílá: řetězec - číslo čárkového kódu palety
       * Aplikace přijímá: řetězec - krátké označení auta (např. PO, MS, ...)
       * 
       */

      // Pseudo database
      //return containerCode switch {
      //  "1" => "MS",
      //  "2" => "SK",
      //  "3" => "BM",
      //  _ => "PO",
      //};

      if (DataProcessing.containerCode_name.ContainsKey(containerCode)) {
        return DataProcessing.containerCode_name[containerCode];
      }

      System.Windows.Forms.MessageBox.Show($"Kód neexistuje\nPoužití náhodné zóny");

      return new string[] { "PO", "MS", "SK", "BM" }.ElementAt(new Random().Next(4));
    }

    public static int GetZonePalletsCount(string zoneName) {
      /*
       * 
       * Zde by se měl uskutečnit požadavek na databázi SAP
       * Aplikace posílá: řetězec - název zóny (např. A1, AB98, ..)
       * Aplikace přijímá: číslo - počet palet v dané zóně
       * 
       */

      // Pseudo database
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
  }
}
