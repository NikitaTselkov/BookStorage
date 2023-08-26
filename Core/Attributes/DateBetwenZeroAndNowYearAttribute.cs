using System.ComponentModel.DataAnnotations;

namespace Core.Attributes
{
    public class DateBetwenZeroAndNowYearAttributeLocalize : ValidationAttribute
    {
        public DateBetwenZeroAndNowYearAttributeLocalize()
        {

        }

        public override bool IsValid(object value)
        {
            if (value == null)
                return false;

            if (int.TryParse(value.ToString(), out int year))
            {
                return year >= 0 && year <= DateTime.Now.Year;
            }

            return false;
        }

        public override string FormatErrorMessage(string name)
        {
            ErrorMessage = string.Format(TranslationSource.Instance["DateBetwenZeroAndNowYearValidationErrorMessage"], DateTime.Now.Year);
            return base.FormatErrorMessage(name);
        }
    }
}
