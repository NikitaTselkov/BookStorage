using BookStorage.Models;
using Core.Enums;
using DataBaseAccess.Repository;
using Models;
using Prism.Commands;
using Prism.Services.Dialogs;
using System.Collections.Generic;

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

        private List<Book> _books;
        public List<Book> Books
        {
            get { return _books; }
            set { SetProperty(ref _books, value); }
        }

        private readonly IBookRepository _bookRepository;
        private readonly IDialogService _dialogService;

        #region Commands

        private DelegateCommand _addBook;
        public DelegateCommand AddBook =>
            _addBook ?? (_addBook = new DelegateCommand(ExecuteAddBook));

        private DelegateCommand<object> _deleteBook;
        public DelegateCommand<object> DeleteBook =>
            _deleteBook ?? (_deleteBook = new DelegateCommand<object>(ExecuteDeleteBook));

        private DelegateCommand<object> _editBook;
        public DelegateCommand<object> EditBook =>
            _editBook ?? (_editBook = new DelegateCommand<object>(ExecuteEditBook));

        #endregion

        public MainWindowViewModel(IBookRepository bookRepository, IDialogService dialogService)
        {
            _bookRepository = bookRepository;
            _dialogService = dialogService;

            Books = new List<Book>(_bookRepository.GetAll());

            _bookRepository.OnBooksChanged += UpdateBooks;

            SetLanguage(Languages.en);
        }

        ~MainWindowViewModel()
        {
            _bookRepository.OnBooksChanged -= UpdateBooks;
        }

        private void ExecuteAddBook()
        {
            var message = TranslationSource.Instance["AddBook"];

            _dialogService.ShowDialog(DialogsNames.UpsertDialog, new DialogParameters($"Message={message}"), r =>
            {
                if (r.Result == ButtonResult.OK)
                {
                    var book = GetBookFromCallBack(r.Parameters);

                    _bookRepository.Add(book);
                    _bookRepository.Save();
                }
            });
        }

        private void ExecuteEditBook(object param)
        {
            if (param is Book book)
            {
                var currentBook = _bookRepository.Get(g => g.Id == book.Id);

                var message = TranslationSource.Instance["EditBook"];
                var parametrs = new DialogParameters
                {
                    { "Message", message },
                    { "Author", book.Author },
                    { "BookTitle", book.Title },
                    { "Theme", book.Theme },
                    { "YearOfPublishing", book.YearOfPublishing }
                };

                _dialogService.ShowDialog(DialogsNames.UpsertDialog, parametrs, r =>
                {
                    if (r.Result == ButtonResult.OK)
                    {
                        var book = GetBookFromCallBack(r.Parameters);

                        currentBook.Update(book);
                        _bookRepository.Update(currentBook);
                    }
                });
            }
        }

        private void ExecuteDeleteBook(object param)
        {
            if (param is Book book)
            {
                var message = $"Delete the book: {book.Title}";

                _dialogService.ShowDialog(DialogsNames.NotificationDialog, new DialogParameters($"Message={message}"), r =>
                {
                    if (r.Result == ButtonResult.OK)
                    {
                        _bookRepository.Remove(book);
                        _bookRepository.Save();
                    }
                });
            }
        }

        private void UpdateBooks()
        {
            Books = new List<Book>(_bookRepository.GetAll());
        }


        private static Book GetBookFromCallBack(IDialogParameters parameters)
        {
            var author = parameters.GetValue<string>("Author");
            var bookTitle = parameters.GetValue<string>("BookTitle");
            var theme = parameters.GetValue<BookThemes>("Theme");
            var yearOfPublishing = parameters.GetValue<int>("YearOfPublishing");

            return new Book(author, bookTitle, theme, yearOfPublishing);
        }
    }
}
