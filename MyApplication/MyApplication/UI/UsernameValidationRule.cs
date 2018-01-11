using MyApplication.DAO;
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
    public class UsernameValidationRule : ValidationRule
    {
        
        Regex regex = new Regex(@"[a-zA-Z0-9]+([_-]?[a-zA-Z0-9])*");

        //Provjeravam validnost username i da li se nalazi takvo vec u bazi
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string username = value as string;
            if (username != null && regex.Match(username).Success && new UserDAO().GetByUsername(username) == null)
                return new ValidationResult(true, null);
            else
                return new ValidationResult(false, "Username format invalid or username already exists");
        }
    }
}
