using Core.Settings;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;



namespace Core.Settings {
  static public partial class DynamicSettings {
    static internal void PrepareSettingsFile() {
      if (!File.Exists(StaticSettings.SettingsFilePath)) {
        Directory.CreateDirectory(Path.GetDirectoryName(StaticSettings.SettingsFilePath));
        using var fileStream = File.Create(StaticSettings.SettingsFilePath);
      }
    }

    static internal void WriteSettingsValue(string key, string value) {
      PrepareSettingsFile();
      List<string> lines = File.ReadAllLines(StaticSettings.SettingsFilePath).ToList();
      int foundIndex = lines.FindIndex(line => line.StartsWith(key));
      if (foundIndex != -1)
        lines.RemoveAt(foundIndex);
      lines = lines.Append($"{key}{StaticSettings.SETTINGS_SEPARATOR}{value}").ToList();
      File.WriteAllLines(StaticSettings.SettingsFilePath, lines);
    }

    static internal string ReadSettingsValue(string key, string fallback) {
      PrepareSettingsFile();
      string[] lines = File.ReadAllLines(StaticSettings.SettingsFilePath);
      string maybeValue = lines.FirstOrDefault(line => line.StartsWith(key));
      return maybeValue != default ? maybeValue.Split(StaticSettings.SETTINGS_SEPARATOR)[1] : fallback;
    }
  }
}
