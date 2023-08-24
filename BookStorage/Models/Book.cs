using BookStorage.ValidationAttributes;
using System.Configuration;

namespace BookStorage.Models
{
    public class Book
    {
        [RegexStringValidator(@"^[\p{L}]+\s[\p{L}]+$")]
        public string Author { get; init; }
        public string Title { get; init; }
        public BookThemes Theme { get; init; }

        /// <summary>
        /// Проверяет находится ли значение между 0 и текущим годом.
        /// </summary>
        [DateBetwenZeroAndNowYear]
        public int YearOfPublishing { get; init; }

        public Book(string author, string title, BookThemes theme, int yearOfPublishing)
        {
            Author = author;
            Title = title;
            Theme = theme;
            YearOfPublishing = yearOfPublishing;
        }
    }
}
