using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspMVCDemo.Validators
{
    public class Pesel : ValidationAttribute
    {
        public Pesel()
        {

        }



        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string pesel;

            // validation FTW!
            //return ValidationResult.Success;

            if (value == null)
                return ValidationResult.Success;

            if (value is string)
                pesel = value.ToString();
            else
                return new ValidationResult("Unable to cast provided PESEL value to string");

            if (pesel.Length != 11)
                return new ValidationResult(String.Format("Pesel %s is not 11 characters long", pesel));
            
            foreach(char c in pesel)
            {
                if(!char.IsDigit(c))
                    return new ValidationResult(String.Format("Pesel %s has non-digit character.", pesel));
            }

            // calculate checksum 
            int sum = 0;
            sum += 1 * (int)char.GetNumericValue(pesel.ElementAt(0));
            sum += 3 * (int)char.GetNumericValue(pesel.ElementAt(1));
            sum += 7 * (int)char.GetNumericValue(pesel.ElementAt(2));
            sum += 9 * (int)char.GetNumericValue(pesel.ElementAt(3));
            sum += 1 * (int)char.GetNumericValue(pesel.ElementAt(4));
            sum += 3 * (int)char.GetNumericValue(pesel.ElementAt(5));
            sum += 7 * (int)char.GetNumericValue(pesel.ElementAt(6));
            sum += 9 * (int)char.GetNumericValue(pesel.ElementAt(7));
            sum += 1 * (int)char.GetNumericValue(pesel.ElementAt(8));
            sum += 3 * (int)char.GetNumericValue(pesel.ElementAt(9));
            sum += 1 * (int)char.GetNumericValue(pesel.ElementAt(10));

            if(sum % 10 != 0)
                return new ValidationResult(String.Format("Pesel %s doesn't have correct checksum.", pesel));

            return ValidationResult.Success;
        }
    }
}
