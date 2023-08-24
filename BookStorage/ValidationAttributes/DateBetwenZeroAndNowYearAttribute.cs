using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStorage.ValidationAttributes
{
    public class DateBetwenZeroAndNowYearAttribute : RangeAttribute
    {
        public DateBetwenZeroAndNowYearAttribute() : base(typeof(DateTime), "0", DateTime.Now.Year.ToString())
        {

        }
    }
}
