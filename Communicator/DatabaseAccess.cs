using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Communicator
{
  public class DatabaseAccess
  {
    public static Dictionary<string, int[]> Storage = new Dictionary<string, int[]>();

    public static string GetCarBrandFromContainerCode(string containerCode)
    {
      /*
       * 
       * Zde by se měl uskutečnit požadavek na databázi SAP
       * Aplikace posílá: řetězec - číslo čárkového kódu palety
       * Aplikace přijímá: řetězec - krátké označení auta (např. TOY, MS, ...)
       * 
       */

      if (DataProcessing.containerCode_name.ContainsKey(containerCode))
      {
        return DataProcessing.containerCode_name[containerCode];
      }
      System.Windows.Forms.MessageBox.Show($"Kód neexistuje\nPoužití náhodné zóny");
      return new string[] { "po", "ms", "sk", "bm" }.ElementAt(new Random().Next(4));
    }

    public static int GetZonePalletsCount(string zoneName) {
      /*
       * 
       * Zde by se měl uskutečnit požadavek na databázi SAP
       * Aplikace posílá: řetězec - název zóny (např. A1, AB98, ..)
       * Aplikace přijímá: číslo - počet palet v dané zóně
       * 
       */

      return new Random().Next(10);
    }

    public static void LoadDataFromDatabase(string Cesta_k_souboru = @"./data.csv")
    {
      using (StreamReader sr = new StreamReader(Cesta_k_souboru))
      {
        /*
         * 
         * Zde je zapotřebí výstup z databáze
         * soubor data.csv ve formátu [název zóny];[aktuální stav zóny];[maximalní počet palet v zóně]
         * 
         */

        while (!sr.EndOfStream)
        {
          string[] items = sr.ReadLine().Split(';');
          string name = items[0].Trim().ToLower();
          int nowSize = Convert.ToInt32(items[1]);
          int maxSize = Convert.ToInt32(items[2]);

          if (Storage.ContainsKey(items[0]))
            Storage[name] = new int[] { nowSize, maxSize };
          else
            Storage.Add(name, new int[] { nowSize, maxSize });
        }
        foreach (var a in DataProcessing.layout.Zones)
        {
          if (a.Type == Core.Storage.ZoneType.Storage)
          {
            int palletsNow = Storage[a.Name.ToLower()][0];
            a.PalletsCurrentlyStored = palletsNow;
          } 
        }
      }
    }
  }
}
