using System;
using System.Windows.Forms;

using Core;
using Core.UI;
using Core.Extensions;



namespace Settings {
  public partial class Main : Form {
    public Main() {
      InitializeComponent();
    }

    SettingsProperties settingsProperties = new SettingsProperties();

    private void Main_Load(object sender, EventArgs e) {
      propertyGrid.SelectedObject = settingsProperties;
    }

    private void buttonResetSettings_Click(object sender, EventArgs e) {
      var dialogResult = MessageBoxes.SettingsReset();

      if (dialogResult == DialogResult.Yes) {
        settingsProperties.StartupLayoutName = DynamicSettings.StartupLayoutName.Fallback;
        settingsProperties.Highlight_Duration = DynamicSettings.Highlight_Duration.Fallback.ToInt();
        settingsProperties.Highlight_TotalFlashesCount = DynamicSettings.Highlight_TotalFlashesCount.Fallback.ToInt();
        settingsProperties.LayoutColor = DynamicSettings.LayoutColor.Fallback.ToColor();
        settingsProperties.GridColor = DynamicSettings.GridColor.Fallback.ToColor();
        settingsProperties.ZoneColor_Storage = DynamicSettings.ZoneColor_Storage.Fallback.ToColor();
        settingsProperties.ZoneColor_Other = DynamicSettings.ZoneColor_Other.Fallback.ToColor();
        settingsProperties.ZoneColor_Full = DynamicSettings.ZoneColor_Full.Fallback.ToColor();
        settingsProperties.ZoneColor_AlmostFull = DynamicSettings.ZoneColor_AlmostFull.Fallback.ToColor();
        settingsProperties.ZoneColor_AboveHalf = DynamicSettings.ZoneColor_AboveHalf.Fallback.ToColor();
        settingsProperties.ZoneColor_BelowHalf = DynamicSettings.ZoneColor_BelowHalf.Fallback.ToColor();
        settingsProperties.ZoneColor_AlmostEmpty = DynamicSettings.ZoneColor_AlmostEmpty.Fallback.ToColor();
        settingsProperties.ZoneColor_Empty = DynamicSettings.ZoneColor_Empty.Fallback.ToColor();

        propertyGrid.SelectedObject = settingsProperties;
      }
    }
  }
}
