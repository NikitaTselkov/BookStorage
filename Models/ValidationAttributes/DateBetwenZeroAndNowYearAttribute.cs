using System.ComponentModel.DataAnnotations;

namespace Models.ValidationAttributes
{
    public class DateBetwenZeroAndNowYearAttribute : ValidationAttribute
    {
        public DateBetwenZeroAndNowYearAttribute() : base("Value must be between 0 and " + DateTime.Now.Year)
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
    }
}
