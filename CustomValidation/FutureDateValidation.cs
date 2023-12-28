using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace GigHub.CustomValidation
{
    public class FutureDateValidation :ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime date;
            string[] formats = {"dd MMM yyyy"};
            var IsValid= DateTime.TryParseExact(Convert.ToString(value), formats, CultureInfo.CurrentCulture, DateTimeStyles.None,out date);
            return (IsValid && date> DateTime.Now);
        }
    }
}