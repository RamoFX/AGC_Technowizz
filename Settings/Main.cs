using System;
using System.Windows.Forms;
using Core;
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

    private void buttonResetSettings_Click(object sender, EventArgs e)
    {
      settingsProperties.StartupLayoutName = DynamicSettings.StartupLayoutName.Fallback;
      settingsProperties.Highlight_Duration = DynamicSettings.Highlight_Duration.Fallback.ToInt();
      settingsProperties.Highlight_TotalFlashesCount = DynamicSettings.Highlight_TotalFlashesCount.Fallback.ToInt();
      settingsProperties.NeutralColor_Dark = DynamicSettings.LayoutColor.Fallback.ToColor();
      settingsProperties.NeutralColor_Light = DynamicSettings.GridColor.Fallback.ToColor();
      settingsProperties.ZoneColor_Storage = DynamicSettings.ZoneColor_Storage.Fallback.ToColor();
      settingsProperties.ZoneColor_Other = DynamicSettings.ZoneColor_Other.Fallback.ToColor();
      settingsProperties.CarBrandColor_Full = DynamicSettings.CarBrandColor_Full.Fallback.ToColor();
      settingsProperties.CarBrandColor_AlmostFull = DynamicSettings.CarBrandColor_AlmostFull.Fallback.ToColor();
      settingsProperties.CarBrandColor_AboveHalf = DynamicSettings.CarBrandColor_AboveHalf.Fallback.ToColor();
      settingsProperties.CarBrandColor_BelowHalf = DynamicSettings.CarBrandColor_BelowHalf.Fallback.ToColor();
      settingsProperties.CarBrandColor_AlmostEmpty = DynamicSettings.CarBrandColor_AlmostEmpty.Fallback.ToColor();
      settingsProperties.CarBrandColor_Empty = DynamicSettings.CarBrandColor_Empty.Fallback.ToColor();
    }
  }
}
