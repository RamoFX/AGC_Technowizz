using System.ComponentModel;
using System.Drawing;

using Core;
using Core.Extensions;



namespace Settings {
  internal partial class SettingsProperties {
    [DisplayName("Barva okrajů")]
    [Category("Barva")]
    public Color NeutralColor_Dark {
      get => DynamicSettings.LayoutColor.Value.ToColor();
      set => DynamicSettings.LayoutColor.Value = value.Name;
    }



    [DisplayName("Barva mřížky")]
    [Category("Barva")]
    public Color NeutralColor_Light {
      get => DynamicSettings.GridColor.Value.ToColor();
      set => DynamicSettings.GridColor.Value = value.Name;
    }



    [DisplayName("Barva zóny pro uložení")]
    [Category("Barva")]
    public Color ZoneColor_Storage {
      get => DynamicSettings.ZoneColor_Storage.Value.ToColor();
      set => DynamicSettings.ZoneColor_Storage.Value = value.Name;
    }



    [DisplayName("Barva ostatních zón")]
    [Category("Barva")]
    public Color ZoneColor_Other {
      get => DynamicSettings.ZoneColor_Other.Value.ToColor();
      set => DynamicSettings.ZoneColor_Other.Value = value.Name;
    }



    [DisplayName("Barva plné zóny")]
    [Category("Barva")]
    [Description("100%")]
    public Color CarBrandColor_Full {
      get => DynamicSettings.CarBrandColor_Full.Value.ToColor();
      set => DynamicSettings.CarBrandColor_Full.Value = value.Name;
    }



    [DisplayName("Barva skoro plné zóny")]
    [Category("Barva")]
    [Description("99% ... 75%")]
    public Color CarBrandColor_AlmostFull {
      get => DynamicSettings.CarBrandColor_AlmostFull.Value.ToColor();
      set => DynamicSettings.CarBrandColor_AlmostFull.Value = value.Name;
    }



    [DisplayName("Barva zóny zaplněné nad polovinu")]
    [Category("Barva")]
    [Description("74% ... 50%")]
    public Color CarBrandColor_AboveHalf {
      get => DynamicSettings.CarBrandColor_AboveHalf.Value.ToColor();
      set => DynamicSettings.CarBrandColor_AboveHalf.Value = value.Name;
    }



    [DisplayName("Barva zóny zaplněné do poloviny")]
    [Category("Barva")]
    [Description("49% ... 25%")]
    public Color CarBrandColor_BelowHalf {
      get => DynamicSettings.CarBrandColor_BelowHalf.Value.ToColor();
      set => DynamicSettings.CarBrandColor_BelowHalf.Value = value.Name;
    }



    [DisplayName("Barva skoro prázdné zóny")]
    [Category("Barva")]
    [Description("24% ... 1%")]
    public Color CarBrandColor_AlmostEmpty {
      get => DynamicSettings.CarBrandColor_AlmostEmpty.Value.ToColor();
      set => DynamicSettings.CarBrandColor_AlmostEmpty.Value = value.Name;
    }



    [DisplayName("Barva prázdné zóny")]
    [Category("Barva")]
    [Description("0%")]
    public Color CarBrandColor_Empty {
      get => DynamicSettings.CarBrandColor_Empty.Value.ToColor();
      set => DynamicSettings.CarBrandColor_Empty.Value = value.Name;
    }
  }
}
