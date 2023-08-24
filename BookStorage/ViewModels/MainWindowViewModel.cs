using BookStorage.Models;
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
        }
    }
}
