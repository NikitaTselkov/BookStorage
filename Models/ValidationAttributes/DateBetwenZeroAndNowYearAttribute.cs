using System.ComponentModel.DataAnnotations;

namespace Models.ValidationAttributes
{
    public class DateBetwenZeroAndNowYearAttribute : RangeAttribute
    {
        public DateBetwenZeroAndNowYearAttribute() : base(typeof(DateTime), "0", DateTime.Now.Year.ToString())
        {

        }
    }
}
