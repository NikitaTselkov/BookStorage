using Core.Enums;

namespace Services
{
    public interface IBookService
    {
        public BookThemes GetThemeOfWeek();
    }
}
