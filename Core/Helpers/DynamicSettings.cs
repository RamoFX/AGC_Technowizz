using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;



namespace Core {
  static public partial class DynamicSettings {
    static private void PrepareSettingsFile() {
      if (!File.Exists(StaticSettings.SettingsFilePath)) {
        Directory.CreateDirectory(Path.GetDirectoryName(StaticSettings.SettingsFilePath));
        using var fileStream = File.Create(StaticSettings.SettingsFilePath);
      }
    }

    static public void WriteSettingsValue(string key, string value) {
      PrepareSettingsFile();
      List<string> lines = File.ReadAllLines(StaticSettings.SettingsFilePath).ToList();
      int foundIndex = lines.FindIndex(line => line.StartsWith(key));
      if (foundIndex != -1)
        lines.RemoveAt(foundIndex);
      lines = lines.Append($"{key}{StaticSettings.SettingsSeparator}{value}").ToList();
      File.WriteAllLines(StaticSettings.SettingsFilePath, lines);
    }

    static public string ReadSettingsValue(string key, string fallback) {
      PrepareSettingsFile();
      string[] lines = File.ReadAllLines(StaticSettings.SettingsFilePath);
      string maybeValue = lines.FirstOrDefault(line => line.StartsWith(key));
      return maybeValue != default ? maybeValue.Split(StaticSettings.SettingsSeparator)[1] : fallback;
    }
  }
}
