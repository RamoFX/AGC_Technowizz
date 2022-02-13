﻿using System.ComponentModel;

using Core;
using Core.Settings;



namespace Settings {
  internal partial class SettingsProperties {
    [Category("Rozložení")]
    [DisplayName("Název počátečního rozvržení")]
    [Description("Název počátečního rozvržení v aplikaci ZoneAssigner.")]
    public string StartupLayoutName {
      get => DynamicSettings.StartupLayoutName.Value;
      set => DynamicSettings.StartupLayoutName.Value = value;
    }
  }
}
