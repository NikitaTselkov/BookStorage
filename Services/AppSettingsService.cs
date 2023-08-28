using System.Configuration;

namespace Services
{
    public class AppSettingsService : ISettingsService
    {
        private Configuration _config;
        private KeyValueConfigurationCollection _appSetting;

        public AppSettingsService()
        {
            _config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            _appSetting = _config.AppSettings.Settings;
        }

        public string GetValue(string key)
        {
            if(_appSetting.AllKeys.Contains(key))
                return _appSetting[key].Value;

            return string.Empty;
        }

        public void AddOrUpdateAppSettings(string key, string value)
        {
            try
            {
                if (_appSetting[key] == null)
                {
                    _appSetting.Add(key, value);
                }
                else
                {
                    _appSetting[key].Value = value;
                }
                _config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(_config.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error writing app settings");
            }
        }
    }
}
