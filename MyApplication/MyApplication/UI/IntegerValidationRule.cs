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
    public class IntegerValidationRule : ValidationRule
    {
        private Regex regex;

        public IntegerValidationRule()
        {
            regex = new Regex(@"[1-9]\d*");
        }

        //Brojevi (kolicina) moraju biti ne-negativni [1,...)
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string input = value as string;
            if (input != null && regex.Match(input).Success)
                return new ValidationResult(true, null);
            else
                return new ValidationResult(false, "Must be greater than 0");
        }
    }
}
