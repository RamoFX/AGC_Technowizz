using System.ComponentModel;
using System.Drawing;

using Core.Extensions;
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
        get => new(this.Location, this.Size);
      }



      [Browsable(false)]
      public Color Color {
        get {
          DynamicSetting color;

          if (this.VerticalCapacity == 0)
            color = DynamicSettings.ZoneColor_Other;

          else if (this.StoredPercent == 100)
            color = DynamicSettings.ZoneColor_Full;

          else if (this.StoredPercent < 100 && this.StoredPercent >= 75)
            color = DynamicSettings.ZoneColor_AlmostFull;

          else if (this.StoredPercent < 75 && this.StoredPercent >= 50)
            color = DynamicSettings.ZoneColor_AboveHalf;

          else if (this.StoredPercent < 50 && this.StoredPercent >= 25)
            color = DynamicSettings.ZoneColor_BelowHalf;

          else if (this.StoredPercent < 25 && this.StoredPercent > 0)
            color = DynamicSettings.ZoneColor_AlmostEmpty;

          else
            color = DynamicSettings.ZoneColor_Empty;

          return color.Value.ToColor();
        }
      }
    }
  }
}
