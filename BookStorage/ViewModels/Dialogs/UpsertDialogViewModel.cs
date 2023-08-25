using Core.Enums;
using Models;
using Models.ValidationAttributes;
using Prism.Services.Dialogs;

namespace BookStorage.ViewModels.Dialogs
{
    public class UpsertDialogViewModel : DialogViewModelBase
    {
        private string _author;
        public string Author
        {
            get { return _author; }
            set { SetProperty(ref _author, value); }
        }

        private string _bookTitle;
        public string BookTitle
        {
            get { return _bookTitle; }
            set { SetProperty(ref _bookTitle, value); }
        }

        private BookThemes _theme;
        public BookThemes Theme
        {
            get { return _theme; }
            set { SetProperty(ref _theme, value); }
        }

        private int _yearOfPublishing;
        public int YearOfPublishing
        {
            get { return _yearOfPublishing; }
            set { SetProperty(ref _yearOfPublishing, value); }
        }


        public override void OnDialogOpened(IDialogParameters parameters)
        { 
            base.OnDialogOpened(parameters);
            Author = parameters.GetValue<string>(nameof(Author));
            BookTitle = parameters.GetValue<string>(nameof(BookTitle));
            Theme = parameters.GetValue<BookThemes>(nameof(Theme));
            YearOfPublishing = parameters.GetValue<int>(nameof(YearOfPublishing));
        }

        protected override void CloseDialog(string parameter)
        {
            ButtonResult result = ButtonResult.None;
            IDialogParameters parametrs = null;

            if (parameter?.ToLower() == "true")
            {
                parametrs = new DialogParameters
                {
                    { "Author", Author },
                    { "BookTitle", BookTitle },
                    { "Theme", Theme },
                    { "YearOfPublishing", YearOfPublishing }
                };
                result = ButtonResult.OK;
            }
            else if (parameter?.ToLower() == "false")
                result = ButtonResult.Cancel;

            RaiseRequestClose(new DialogResult(result, parametrs));
        }
    }
}
