using Core.Enums;
using Prism.Services.Dialogs;
using System.Globalization;
using System.Text.RegularExpressions;
using Core.Attributes;

namespace BookStorage.ViewModels.Dialogs
{
    public class UpsertDialogViewModel : DialogViewModelBase
    {
        private string _author;
        /// <summary>
        /// Проверяет формат ФИО:
        /// Иванов Иван Иванович
        /// Иванов Иван И.
        /// Иванов И.И.
        /// </summary>
        [RegularExpressionLocalize(@"^\s*[\p{L}]+\s*[\p{L}]+\.?\s*[\p{L}]+\.?\s*$")]
        [RequiredLocalized]
        public string Author
        {
            get { return _author; }
            set { SetProperty(ref _author, value); }
        }
        
        private string _bookTitle;
        [StringLengthLocalize(350)]
        [RequiredLocalized]
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

        private string _yearOfPublishing;
        /// <summary>
        /// Проверяет находится ли значение между 0 и текущим годом.
        /// </summary>
        [DateBetwenZeroAndNowYearAttributeLocalize]
        [RequiredLocalized]
        public string YearOfPublishing
        {
            get { return _yearOfPublishing; }
            set 
            {
                if (value != null)
                    SetProperty(ref _yearOfPublishing, value);
            }
        }


        public override void OnDialogOpened(IDialogParameters parameters)
        { 
            base.OnDialogOpened(parameters);
            Author = parameters.GetValue<string>(nameof(Author));
            BookTitle = parameters.GetValue<string>(nameof(BookTitle));
            Theme = parameters.GetValue<BookThemes>(nameof(Theme));
            YearOfPublishing = parameters.GetValue<string>(nameof(YearOfPublishing));
        }

        protected override void CloseDialog(string parameter)
        {
            ButtonResult result;
            if (parameter?.ToLower() == "true")
            {
                StartValidation();

                IDialogParameters parametrs = new DialogParameters
                {
                    { "Author", Author },
                    { "BookTitle", BookTitle },
                    { "Theme", Theme },
                    { "YearOfPublishing", YearOfPublishing }
                };
                result = ButtonResult.OK;

                if (IsAllValid())
                    RaiseRequestClose(new DialogResult(result, parametrs));
            }
            else if (parameter?.ToLower() == "false")
            {
                result = ButtonResult.Cancel;
                RaiseRequestClose(new DialogResult(result));
            }
        }

        internal override void StartValidation()
        {
           base.StartValidation();

            // Удаляем лишние пробелы
            if (Author != null)
            {
                var val = Regex.Replace(Author.Trim(), @"\s+", " ");
                TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
                Author = textInfo.ToTitleCase(val.Replace(" .", "."));
            }

            RaisePropertyChanged(nameof(Author));
            RaisePropertyChanged(nameof(BookTitle));
            RaisePropertyChanged(nameof(YearOfPublishing));
        }
    }
}
