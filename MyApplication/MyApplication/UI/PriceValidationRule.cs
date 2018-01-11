using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MyApplication.UI
{
    public class PriceValidationRule : ValidationRule
    {
        Regex regex = new Regex(@"\d+\.?\d*");

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string price = value as string;
            if (price != null && regex.Match(price).Success)
                return new ValidationResult(true, null);
            else
                return new ValidationResult(false, "Price should be a number");
        }
    }
}
