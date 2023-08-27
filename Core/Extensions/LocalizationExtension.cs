using System.Globalization;
using System.Windows.Data;

namespace Core.Extensions
{
    public class LocalizationExtension : Binding
    {
        public LocalizationExtension() { }

        public LocalizationExtension(string name) : base("[" + name + "]")
        {
            this.Mode = BindingMode.OneWay;
            this.Source = TranslationSource.Instance;
        }
    }
}
