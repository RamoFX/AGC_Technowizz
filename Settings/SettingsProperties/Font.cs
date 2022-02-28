using System.ComponentModel;

using Core;
using Core.Extensions;
using Core.Settings;



namespace Settings {
  internal partial class SettingsProperties {
    [Category("Písmo")]
    [DisplayName("Velikost názvů zón")]
    [Description("Velikost písma, který se používá ve vykreslovači rozložení")]
    public int ZoneNameSize {
      get => DynamicSettings.ZoneNameSize.Value.ToInt();
      set => DynamicSettings.ZoneNameSize.Value = value.ToString();
    }
  }
}
