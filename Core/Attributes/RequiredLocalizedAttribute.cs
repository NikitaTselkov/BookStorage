using System.ComponentModel.DataAnnotations;

namespace Core.Attributes
{
    public class RequiredLocalizedAttribute : RequiredAttribute
    {
        public override string FormatErrorMessage(string name)
        {
            ErrorMessage = TranslationSource.Instance["RequiredValidationErrorMessage"];
            return base.FormatErrorMessage(name);
        }
    }
}
