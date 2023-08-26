using System.ComponentModel;
using System.Reflection;

namespace Core.Extensions
{
    public class EnumDescriptionTypeConverter : EnumConverter
    {
        public EnumDescriptionTypeConverter(Type type)
            : base(type)
        {
        }

        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
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

                return string.Empty;
            }

            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}
