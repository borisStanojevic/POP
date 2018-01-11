using MyApplication.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyApplication.Util
{
    public class InputValidator
    {

        public static bool ValidateString(string text)
        {
            if (text == "")
                return false;
            else
                return true;
        }

        public static bool ValidateInteger(string text)
        {
            try
            {
                int number = int.Parse(text);
                if (number > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool ValidatePrice(string text)
        {
            try
            {
                decimal price = decimal.Parse(text);
                if (price > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool ValidateDiscount(string text)
        {
            try
            {
                decimal discount = decimal.Parse(text);
                if (discount > 0.0M && discount < 0.99M)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool ValidateUsername(string text)
        {
            Regex regex = new Regex(@"[a-zA-Z0-9]+([_-]?[a-zA-Z0-9])*");
            if (regex.Match(text).Success && new UserDAO().GetByUsername(text) == null)
                return true;
            else
                return false;
        }

        public static bool ValidatePassword(string text)
        {
            Regex regex = new Regex(@"(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}");
            if (regex.Match(text).Success)
                return true;
            else
                return false;
        }

    }
}
