using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MyApplication.UI
{
    public class DiscountValidationRule : ValidationRule
    {
        //Za popust ne zelim da dozvolim unos negativnog broja i broja veceg od 1.0 (Sto predstavlja 100% popust)
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string input = value as string;
            if (input != null)
            {
                try
                {
                    decimal discount = decimal.Parse(input);
                    if (discount > 0.0M && discount < 0.99M)
                        return new ValidationResult(true, null);
                }
                catch (Exception)
                {
                    return new ValidationResult(false, "Discount should be between 0 and 0.99");
                }
            }
            return new ValidationResult(false, "Discount should be between 0 and 0.99");
        }
    }
}
