namespace Core.Helpers {
  public class DynamicSetting {
    private readonly string Key;
    private readonly string Fallback;

    public string Value {
      get => DynamicSettings.ReadSettingsValue(this.Key, this.Fallback);
      set => DynamicSettings.WriteSettingsValue(this.Key, value);
    }

    public DynamicSetting(string key, string fallback) {
      this.Key = key;
      this.Fallback = fallback;
    }
  }
}
