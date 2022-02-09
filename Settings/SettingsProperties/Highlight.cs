using System.ComponentModel;

using Core;
using Core.Extensions;



namespace Settings {
  internal partial class SettingsProperties {
    [DisplayName("Doba probliknutí")]
    [Category("Blikání")]
    public int Highlight_Duration {
      get => DynamicSettings.Highlight_Duration.Value.ToInt();
      set => DynamicSettings.Highlight_Duration.Value = value.ToString();
    }



    [DisplayName("Celkový počet bliknutí")]
    [Category("Blikání")]
    public int Highlight_TotalFlashesCount {
      get => DynamicSettings.Highlight_TotalFlashesCount.Value.ToInt();
      set => DynamicSettings.Highlight_TotalFlashesCount.Value = value.ToString();
    }
  }
}
