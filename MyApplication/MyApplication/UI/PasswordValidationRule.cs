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
    public class PasswordValidationRule : ValidationRule
    {

        Regex regex = new Regex(@"(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}");

        //Password treba da je minimum 8 karaktera, bar 1 slovo i bar 1 broj
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string password = value as string;
            if (password != null && regex.Match(password).Success)
                return new ValidationResult(true, null);
            else
                return new ValidationResult(false, "Password format invalid");
        }
    }
}
