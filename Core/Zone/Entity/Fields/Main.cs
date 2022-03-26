using System.ComponentModel;
using System.Drawing;
using Core.Settings;



namespace Core {
  public partial class Zone {
    public partial class Entity {
      [Browsable(true), DisplayName("Název")]
      public string Name { get; set; }



      [Browsable(true), DisplayName("Značka auta")]
      public string CarBrand { get; set; }



      [Browsable(true), DisplayName("Vertikální kapacita")]
      [Description(@"Maximální počet vertikálně umístěných palet. Pokud zóna není určena pro ukládání palet, zadejte hodnotu ""0"".")]
      public int VerticalCapacity { get; set; }



      [Browsable(true), DisplayName("Rozměry")]
      public Size Size { get; set; }



      [Browsable(true), DisplayName("Souřadnice")]
      public Point Location { get; set; }



      [Browsable(false)]
      public Rectangle Rectangle {
        get => new(Location, Size);
      }



      [Browsable(false)]
      public Color Color {
        get {
          DynamicSetting color;

          if (VerticalCapacity == 0)
            color = DynamicSettings.ZoneColor_Other;

          else if (StoredPercent == 100)
            color = DynamicSettings.ZoneColor_Full;

          else if (StoredPercent < 100 && StoredPercent >= 75)
            color = DynamicSettings.ZoneColor_AlmostFull;

          else if (StoredPercent < 75 && StoredPercent >= 50)
            color = DynamicSettings.ZoneColor_AboveHalf;

          else if (StoredPercent < 50 && StoredPercent >= 25)
            color = DynamicSettings.ZoneColor_BelowHalf;

          else if (StoredPercent < 25 && StoredPercent > 0)
            color = DynamicSettings.ZoneColor_AlmostEmpty;

          else
            color = DynamicSettings.ZoneColor_Empty;

          return color.Value.ToColor();
        }
      }
    }
  }
}
