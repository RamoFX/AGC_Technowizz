namespace Core.Settings {
  public class DynamicSetting {
    private readonly string Key;
    public readonly string Fallback;

    public string Value {
      get => DynamicSettings.ReadSettingsValue(Key, Fallback);
      set => DynamicSettings.WriteSettingsValue(Key, value);
    }

    public DynamicSetting(string key, string fallback) {
      Key = key;
      Fallback = fallback;
    }
  }
}
