using System.ComponentModel.DataAnnotations;

namespace Core.Attributes
{
    public class StringLengthLocalizeAttribute : StringLengthAttribute
    {
        public StringLengthLocalizeAttribute(int maximumLength) : base(maximumLength)
        {
        }

        public override string FormatErrorMessage(string name)
        {
            ErrorMessage = string.Format(TranslationSource.Instance["StringLengthValidationErrorMessage"], MaximumLength);
            return base.FormatErrorMessage(name);
        }
    }
}
