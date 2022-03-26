using System.ComponentModel;
using Core.Settings;



namespace Settings {
  internal partial class SettingsProperties {
    [Category("Vykreslovač")]
    [DisplayName("Velikost názvů zón")]
    [Description("Velikost písma v px, který se používá ve vykreslovači rozložení")]
    public int ZoneNameSize {
      get => DynamicSettings.ZoneNameSize.Value.ToInt();
      set => DynamicSettings.ZoneNameSize.Value = value.ToString();
    }



    [Category("Vykreslovač")]
    [DisplayName("Velikost vykreslovací jednotky")]
    [Description("Velikost čtverečku, základní vykreslovací jednotky, v px")]
    public int UnitSize {
      get => DynamicSettings.UnitSize.Value.ToInt();
      set => DynamicSettings.UnitSize.Value = value.ToString();
    }
  }
}
