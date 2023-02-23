using System.ComponentModel.DataAnnotations;

namespace AjaxDemoASPMVC.Test
{
   
    public class DateRangeAttribute : RangeAttribute
    {
        public DateRangeAttribute(string minimumValue)
            : base(typeof(DateTime), minimumValue, DateTime.Now.ToShortDateString())
        {
        }
    }
}

