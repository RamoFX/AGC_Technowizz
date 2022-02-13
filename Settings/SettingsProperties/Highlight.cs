using System.ComponentModel;

using Core;
using Core.Extensions;
using Core.Settings;



namespace Settings {
  internal partial class SettingsProperties {
    [Category("Blikání")]
    [DisplayName("Doba probliknutí")]
    public int Highlight_Duration {
      get => DynamicSettings.Highlight_Duration.Value.ToInt();
      set => DynamicSettings.Highlight_Duration.Value = value.ToString();
    }



    [Category("Blikání")]
    [DisplayName("Celkový počet bliknutí")]
    public int Highlight_TotalFlashesCount {
      get => DynamicSettings.Highlight_TotalFlashesCount.Value.ToInt();
      set => DynamicSettings.Highlight_TotalFlashesCount.Value = value.ToString();
    }
  }
}
