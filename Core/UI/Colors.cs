namespace Core.UI {
  public static class Colors {
    static public string HexConverter(string hexColor) {
      switch (hexColor.Length) {
        case 3:
          hexColor += "F";
          goto case 4;
        case 4:
          string color = "";
          foreach (char c in hexColor)
            color += c + c.ToString();
          hexColor = color;
          break;

        case 6:
          hexColor += "FF";
          break;
        case 8:
          break;

        default:
          return "";
      }
      return hexColor;
    }
  }
}
