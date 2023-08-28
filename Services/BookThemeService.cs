using Core.Enums;

namespace Services
{
    public class BookThemeService : IBookThemeService
    {
        private readonly ISettingsService _settings;

        public BookThemeService(ISettingsService settings)
        {
            _settings = settings;
        }

        public BookThemes GetThemeOfWeek()
        {
            var currentDate = DateTime.Now.Date.ToShortDateString();
            var lastUpdateDate = _settings.GetValue(SettingsKeys.ThemeOfWeekDateLastUpdate);
            var nextUpdateDate = string.IsNullOrEmpty(lastUpdateDate) ? DateTime.Now : Convert.ToDateTime(lastUpdateDate);

            int num_days = DayOfWeek.Monday - DateTime.Now.DayOfWeek;
            if (num_days <= 0) num_days += 7;

            nextUpdateDate = nextUpdateDate.AddDays(num_days);

            if (currentDate != nextUpdateDate.ToShortDateString())
            {
                var themeOfWeek = _settings.GetValue(SettingsKeys.ThemeOfWeek);
                
                if (Enum.TryParse(themeOfWeek, out BookThemes theme))
                    return theme;
            }

            var random = new Random();
            Array values = Enum.GetValues(typeof(BookThemes));
            var newthemeOfWeek = values.GetValue(random.Next(values.Length));

            _settings.AddOrUpdateAppSettings(SettingsKeys.ThemeOfWeek, newthemeOfWeek?.ToString());
            _settings.AddOrUpdateAppSettings(SettingsKeys.ThemeOfWeekDateLastUpdate, currentDate);

            return (BookThemes)newthemeOfWeek;
        }
    }
}
