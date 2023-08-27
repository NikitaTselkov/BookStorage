using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Windows.Data;

namespace Core.Extensions
{
    public class EnumLocalizationConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                FieldInfo fi = value.GetType().GetField(value.ToString());
                if (fi != null)
                {
                    var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

                    string description = null;

                    foreach (var attribute in attributes)
                    {
                        if (!string.IsNullOrEmpty(attribute.Description))
                        {
                            description = attribute.Description;
                            break;
                        }
                    }

                    return ((attributes.Length > 0) && (!string.IsNullOrEmpty(description))) ? description : value.ToString();
                }
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
