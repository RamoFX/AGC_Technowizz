using System.Drawing;
using System.Drawing.Imaging;
using Core.Settings;



namespace LayoutOverview {
  partial class Main {
    private void InitializeStatusStrip() {
      for (int i = 0; i <= 5; i++) {
        Bitmap bitmap = new(32, 32, PixelFormat.Format24bppRgb);
        Graphics graphics = Graphics.FromImage(bitmap);
        DynamicSetting colorSettings = DynamicSettings.ZoneColor_Empty;
        string text = "";

        switch (i) {
          case 0:
            colorSettings = DynamicSettings.ZoneColor_Full;
            text = "100%";
            break;

          case 1:
            colorSettings = DynamicSettings.ZoneColor_AlmostFull;
            text = "99% - 75%";
            break;

          case 2:
            colorSettings = DynamicSettings.ZoneColor_AboveHalf;
            text = "74% - 50%";
            break;

          case 3:
            colorSettings = DynamicSettings.ZoneColor_BelowHalf;
            text = "49% - 25%";
            break;

          case 4:
            colorSettings = DynamicSettings.ZoneColor_AlmostEmpty;
            text = "24% - 1%";
            break;

          case 5:
            colorSettings = DynamicSettings.ZoneColor_Empty;
            text = "0%";
            break;
        }

        graphics.Clear(StatusStrip.BackColor);
        graphics.FillRectangle(new SolidBrush(colorSettings.Value.ToColor()), 0, 0, 32, 32);
        StatusStrip.Items.Add(text, bitmap);
      }
    }
  }
}
