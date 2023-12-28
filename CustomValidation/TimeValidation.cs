using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace GigHub.CustomValidation
{
    public class TimeValidation:ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var date = new DateTime();
            var IsValid = DateTime.TryParseExact(Convert.ToString(value), "hh:mm", CultureInfo.CurrentCulture, DateTimeStyles.None, out date);
            return (IsValid);
        }

    }
}