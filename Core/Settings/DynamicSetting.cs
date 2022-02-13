namespace Core.Settings {
  public class DynamicSetting {
    private readonly string Key;
    public readonly string Fallback;

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
