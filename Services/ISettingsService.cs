namespace Services
{
    public interface ISettingsService
    {
        public string GetValue(string key);
        public void AddOrUpdateAppSettings(string key, string value);
    }
}
