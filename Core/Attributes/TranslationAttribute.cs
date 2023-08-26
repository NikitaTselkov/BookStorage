using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Core.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class TranslationAttribute : DescriptionAttribute
    {
        private readonly string _culture;
        private readonly string _translation;

        public TranslationAttribute(string translation, string culture)
        {
            _translation = translation;
            _culture = culture;
        }

        public override string Description
        {
            get
            {
                string description = string.Empty;

                if (TranslationSource.Instance.CurrentCulture.ToString() == _culture)
                    description = _translation;

                return description;
            }
        }
    }
}
