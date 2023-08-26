using Core.Enums;
using Core.Attributes.ValidationAttributes;
using Prism.Services.Dialogs;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text.RegularExpressions;

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
        [RegularExpression(@"^\s*[\p{L}]+\s*[\p{L}]+\.?\s*[\p{L}]+\.?\s*$")]
        [Required]
        public string Author
        {
            get { return _author; }
            set
            {
                // Удаляем лишние пробелы
                if (value != null)
                {
                    var val = Regex.Replace(value.Trim(), @"\s+", " ");
                    TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
                    SetProperty(ref _author, textInfo.ToTitleCase(val.Replace(" .", ".")));
                }
            }
        }

        private string _bookTitle;
        [StringLength(350)]
        [Required]
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
        [DateBetwenZeroAndNowYear]
        [Required]
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

            StartValidation();

            if (IsAllValid())
                RaiseRequestClose(new DialogResult(result, parametrs));
        }

        internal override void StartValidation()
        {
           base.StartValidation();

            RaisePropertyChanged(nameof(Author));
            RaisePropertyChanged(nameof(BookTitle));
            RaisePropertyChanged(nameof(YearOfPublishing));
        }
    }
}
