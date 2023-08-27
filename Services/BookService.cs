using Core.Enums;

namespace Services
{
    public class BookService : IBookService
    {
        public BookThemes GetThemeOfWeek()
        {
            var random = new Random();
            Array values = Enum.GetValues(typeof(BookThemes));
            return (BookThemes)values.GetValue(random.Next(values.Length));
        }
    }
}
