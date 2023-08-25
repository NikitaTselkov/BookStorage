using Core.Enums;
using Models.ValidationAttributes;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Book
    {
        [Key]
        public int Id { get; init; }

        [RegularExpression(@"^[\p{L}]+\s[\p{L}]+$")]
        public string Author { get; private set; }
        public string Title { get; private set; }
        public BookThemes Theme { get; private set; }

        /// <summary>
        /// Проверяет находится ли значение между 0 и текущим годом.
        /// </summary>
        [DateBetwenZeroAndNowYear]
        public int YearOfPublishing { get; private set; }

        public Book(string author, string title, BookThemes theme, int yearOfPublishing)
        {
            Author = author;
            Title = title;
            Theme = theme;
            YearOfPublishing = yearOfPublishing;
        }

        public void Update(string author, string title, BookThemes theme, int yearOfPublishing)
        {
            Author = author;
            Title = title;
            Theme = theme;
            YearOfPublishing = yearOfPublishing;
        }

        public void Update(Book book)
        {
            Author = book.Author;
            Title = book.Title;
            Theme = book.Theme;
            YearOfPublishing = book.YearOfPublishing;
        }
    }
}
