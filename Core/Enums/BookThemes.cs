using Core.Attributes;
using Core.Extensions;
using System.ComponentModel;

namespace Core.Enums
{
    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum BookThemes
    {
        [Translation("Фантастика", "ru")]
        Fantasy,
        [Translation("Научная фантастика", "ru")]
        ScienceFiction,
        [Translation("Романтика", "ru")]
        Romance,
        [Translation("Детектив", "ru")]
        Mystery,
        [Translation("Триллер", "ru")]
        Thriller,
        [Translation("Ужасы", "ru")]
        Horror,
        [Translation("История", "ru")]
        History,
        [Translation("Биография", "ru")]
        Biography,
        [Translation("Поэзия", "ru")]
        Poetry,
        [Translation("Искусство", "ru")]
        Art,
        [Translation("Философия", "ru")]
        Philosophy,
        [Translation("Психология", "ru")]
        Psychology,
        [Translation("Информатика", "ru")]
        Computing,
        [Translation("Бизнес", "ru")]
        Business,
        [Translation("Путешествия", "ru")]
        Travel,
        [Translation("Природа", "ru")]
        Nature,
        [Translation("Здоровье", "ru")]
        Health,
        [Translation("Спорт", "ru")]
        Sport,
        [Translation("Юмор", "ru")]
        Humor,
        [Translation("Дети", "ru")]
        Children,
        [Translation("Криминал", "ru")]
        Crime
    }
}
