using BookStorage.Enums;
using BookStorage.Models;
using Prism.Commands;
using Prism.Mvvm;
using System.Collections.ObjectModel;

namespace BookStorage.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private Languages _currentLanguage;
        public Languages CurrentLanguage
        {
            get { return _currentLanguage; }
            set
            {
                SetProperty(ref _currentLanguage, value);
                SetLanguage(_currentLanguage);
            }
        }

        public ObservableCollection<Book> Books { get; set; }

        public MainWindowViewModel()
        {
            Books = new ObservableCollection<Book>()
            {
                new Book("Лев Толстой", "Война и мир", BookThemes.History, 1869),
                new Book("Федор Достоевский", "Преступление и наказание", BookThemes.Crime, 1866),
                new Book("Лев Толстой", "Война и мир", BookThemes.History, 1869),
                new Book("Федор Достоевский", "Преступление и наказание", BookThemes.Crime, 1866),
                new Book("Лев Толстой", "Война и мир", BookThemes.History, 1869),
                new Book("Федор Достоевский", "Преступление и наказание", BookThemes.Crime, 1866),
                new Book("Лев Толстой", "Война и мир", BookThemes.History, 1869),
                new Book("Федор Достоевский", "Преступление и наказание", BookThemes.Crime, 1866),
                new Book("Лев Толстой", "Война и мир", BookThemes.History, 1869),
                new Book("Федор Достоевский", "Преступление и наказание", BookThemes.Crime, 1866),
                new Book("Лев Толстой", "Война и мир", BookThemes.History, 1869),
                new Book("Федор Достоевский", "Преступление и наказание", BookThemes.Crime, 1866),
                new Book("Лев Толстой", "Война и мир", BookThemes.History, 1869),
                new Book("Федор Достоевский", "Преступление и наказание", BookThemes.Crime, 1866),
                new Book("Лев Толстой", "Война и мир", BookThemes.History, 1869),
                new Book("Федор Достоевский", "Преступление и наказание", BookThemes.Crime, 1866),
                new Book("Федор Достоевский", "Преступление и наказание", BookThemes.ScienceFiction, -1)
            };

            SetLanguage(Languages.en);
        }
    }
}
