using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Communicator
{
  static public class Comm
  {
    private static string CONFIG = "";
    const string FullErrorMessage = "Plno";
    public static Dictionary<string, int[]> Storage = new Dictionary<string, int[]>();

    public static void Setup(string path = @"./Config.conf")
    {
      // Vytvoření configu
      StreamReader sr = new StreamReader(path);
      foreach (string line in sr.ReadToEnd().Split('\n'))
        if (line.StartsWith("#") || line.Length <= 3) continue;
        else CONFIG += line + "\n";
      sr.Close();

      // Načtení plnosti skladu
      LoadDataFromDatabase();

      // Načtení testovacích dat
      using (sr = new StreamReader("./test_data.csv"))
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

    private static Dictionary<string, string> containerCode_name = new Dictionary<string, string>();
    public static string GetCarBrandFromContainerCode(string containerCode)
    {
      /*
       * 
       *  Zde se uskutečňuje požadavek na SAP.
       *  Aplikace potřebuje z kódu palety získat značku auta, konkrétně řetězec o délce dvou nebo tří písmen (např. "TO" nebo "MS").
       *  Podle značky auta se zjistí zóna, kde by se měla paleta nacházet (soubor Config.conf).
       *  K těmto datům my nemáme přístup, proto pro správnou funkčnost aplikace je potřeba toto implementovat.
       * 
       */

      if (containerCode_name.ContainsKey(containerCode))
      {
        return containerCode_name[containerCode];
      }
      System.Windows.Forms.MessageBox.Show($"Kód neexistuje\nPoužití náhodné zóny");
      return new string[] { "PO", "MS", "SK", "BM" }.ElementAt(new Random().Next(4));
    }

    public static string GetZoneFromCarBrand(string carBrand)
    {
      Dictionary<string, string> carZonePairs = new Dictionary<string, string>();

      // Načtení configu
      foreach (string line in CONFIG.Split('\n'))
      {
        if (line.Length > 0)
        {
          string[] splittedLine = line.Split(':');
          carZonePairs.Add(splittedLine[0], splittedLine[1]);
        }
      }

      if (carZonePairs.ContainsKey(carBrand.ToUpper()))
      {
        // Pokud je definováno více zón
        if (carZonePairs[carBrand.ToUpper()].Contains(","))
        {
          string[] zones = carZonePairs[carBrand.ToUpper()].Split(',');
          bool full;
          string zone = "";

          foreach (string _zone in zones)
          {
            zone = _zone;
            full = IsZoneFull(zone);
            if (!full)
            {
              // Alespoň jedna zóna není plná (definováno více zón)
              AddToStorage(zone);
              return zone;
            }
          }
          // Všechny zóny jsou plné (definováno více zón)
          System.Windows.Forms.MessageBox.Show(FullErrorMessage);
          return zone;
        }

        if (!IsZoneFull(carZonePairs[carBrand.ToUpper()]))
        {
          // Není plná zóna (pouze 1 definována)
          AddToStorage(carZonePairs[carBrand.ToUpper()]);
          return carZonePairs[carBrand.ToUpper()];
        }
        // Je plná zóna (pouze 1 definována)
        System.Windows.Forms.MessageBox.Show(FullErrorMessage);
        return carZonePairs[carBrand.ToUpper()];
      }
      return "Neznámá značka";
    }

    public static bool IsZoneFull(string zone)
    {
      zone = zone.Trim().ToUpper();
      // Testování plnosti zóny

      if (Storage[zone][0] >= Storage[zone][1]) return true;
      return false;
    }

    private static void AddToStorage(string key)
    {
      key = key.Trim().ToUpper();

      // Přidání do skladu (z důvodu výpočtu plnosti)
      Storage[key][0]++;
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

        // Nahrání souboru do plnosti skladu
        while (!sr.EndOfStream)
        {
          string[] items = sr.ReadLine().Split(';');
          if (Storage.ContainsKey(items[0]))
            Storage[items[0].ToUpper().Trim()] = new int[] { Convert.ToInt32(items[1]), Convert.ToInt32(items[2]) };
          else
            Storage.Add(items[0].ToUpper().Trim(), new int[] { Convert.ToInt32(items[1]), Convert.ToInt32(items[2]) });
        }
      }
    }

    public static int GetStorageUsage(string zone)
    {
      return Storage[zone][0];
    }

    public static string[] ShowEmptyZones()
    {
      List<string> returnArray = new List<string>();
      foreach (KeyValuePair<string, int[]> keyValuePair in Storage)
        if (keyValuePair.Value[0] == 0) returnArray.Add(keyValuePair.Key);

      return returnArray.ToArray();
    }
  }
}
