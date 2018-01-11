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
    public class StringValidationRule : ValidationRule
    {
        Regex regex;

        public StringValidationRule()
        {
            regex = new Regex(@"\S");
        }

        //U poljima koja zahtijevaju string ne zelim da dozvolim unos whitespace-ova
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string input = value as string;
            if (input != null && regex.Match(input).Success)
                return new ValidationResult(true, null);
            else
                return new ValidationResult(false, "This field can not be empty");
        }
    }
}
