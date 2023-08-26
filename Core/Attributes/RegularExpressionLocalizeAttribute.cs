using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Core.Attributes
{
    public class RegularExpressionLocalizeAttribute : RegularExpressionAttribute
    {
        public RegularExpressionLocalizeAttribute([StringSyntax("Regex")] string pattern) : base(pattern)
        {
            
        }

        public override string FormatErrorMessage(string name)
        {
            ErrorMessage = TranslationSource.Instance["AuthorValidationErrorMessage"];
            return base.FormatErrorMessage(name);
        }
    }
}
