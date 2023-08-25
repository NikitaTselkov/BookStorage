using Models.ValidationAttributes;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Book
    {
        [Key]
        public int Id { get; init; }

        [RegularExpression(@"^[\p{L}]+\s[\p{L}]+$")]
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
