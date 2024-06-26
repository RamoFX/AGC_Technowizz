﻿using System;
using System.Windows.Forms;
using Core.UI;
using Core.Settings;
using Core;



namespace Settings {
  public partial class Main : Form {
    public Main() {
      InitializeComponent();
    }

    private readonly SettingsProperties SettingsProperties = new SettingsProperties();

    private void Main_Load(object sender, EventArgs e) {
      propertyGrid.SelectedObject = SettingsProperties;
    }

    private void buttonResetSettings_Click(object sender, EventArgs e) {
      var dialogResult = MessageBoxes.SettingsReset();

      if (dialogResult == DialogResult.Yes) {
        // Layout drawer
        SettingsProperties.ZoneNameSize = DynamicSettings.ZoneNameSize.Fallback.ToInt();

        // Colors
        SettingsProperties.GridColor = DynamicSettings.GridColor.Fallback.ToColor();

        SettingsProperties.ZoneColor_Other = DynamicSettings.ZoneColor_Other.Fallback.ToColor();

        SettingsProperties.ZoneColor_Full = DynamicSettings.ZoneColor_Full.Fallback.ToColor();
        SettingsProperties.ZoneColor_AlmostFull = DynamicSettings.ZoneColor_AlmostFull.Fallback.ToColor();
        SettingsProperties.ZoneColor_AboveHalf = DynamicSettings.ZoneColor_AboveHalf.Fallback.ToColor();
        SettingsProperties.ZoneColor_BelowHalf = DynamicSettings.ZoneColor_BelowHalf.Fallback.ToColor();
        SettingsProperties.ZoneColor_AlmostEmpty = DynamicSettings.ZoneColor_AlmostEmpty.Fallback.ToColor();
        SettingsProperties.ZoneColor_Empty = DynamicSettings.ZoneColor_Empty.Fallback.ToColor();



        propertyGrid.SelectedObject = SettingsProperties;
      }
    }
  }
}
