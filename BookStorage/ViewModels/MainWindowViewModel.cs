using Core;
using Core.Enums;
using DataBaseAccess.Repository;
using Core.Models;
using Prism.Commands;
using Prism.Services.Dialogs;
using System.Collections.Generic;
using Services;
using System.ComponentModel;
using System;
using Prism.Common;
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

        private BookThemes _themeOfWeek;
        public BookThemes ThemeOfWeek
        {
            get { return _themeOfWeek; }
            set { SetProperty(ref _themeOfWeek, value); }
        }

        private Languages _currentLanguage;      
        public Languages CurrentLanguage
        {
            get { return _currentLanguage; }
            set
            {
                SetProperty(ref _currentLanguage, value);
                SetLanguage(_currentLanguage);
                RaisePropertyChanged(nameof(ThemeOfWeek));
                Books = new ObservableCollection<Book>(_bookRepository.GetAll());
            }
        }

        public ObservableCollection<Book> Books { get; set; }

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

        public MainWindowViewModel(IBookRepository bookRepository, IDialogService dialogService, IBookThemeService bookThemeService)
        {
            _bookRepository = bookRepository;
            _dialogService = dialogService;

            Books = new ObservableCollection<Book>(_bookRepository.GetAll());

            ThemeOfWeek = bookThemeService.GetThemeOfWeek();

            _bookRepository.OnCollectionChanged += UpdateBooks;
        }

        ~MainWindowViewModel()
        {
            _bookRepository.OnCollectionChanged -= UpdateBooks;
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
                var message = TranslationSource.Instance["DeleteBook"] + $": {book.Title}";

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

        private void UpdateBooks(object sender, CollectionChangeEventArgs e)
        {
            if (e.Action == CollectionChangeAction.Add)
                Books.Add((Book)e.Element);

            else if(e.Action == CollectionChangeAction.Remove)
                Books.Remove((Book)e.Element);
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
