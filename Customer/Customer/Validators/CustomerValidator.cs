using CustomerLibrary.Entities;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CustomerLibrary.Validators
{
    public class CustomerValidator
    {
        public static List<string> Validate(Customer customer)
        {
            List<string> errors = new List<string>();

            if (customer.FirstName.Length > 50)
            {
                errors.Add("First name is too long");
            }
            if (customer.LastName.Length > 50)
            {
                errors.Add("Last name is too long");
            }
            if (string.IsNullOrWhiteSpace(customer.LastName))
            {
                errors.Add("Last name required");
            }
            if(customer.Addresses.Count == 0)
            {
                errors.Add("Required at least 1 address");
            }
            if (!Regex.IsMatch(customer.PhoneNumber, @"^\+[1-9]\d{13}$"))
            {
                errors.Add("Incorrect phone number format");
            }
            if (!Regex.IsMatch(customer.Email, @"^[a-zA-Z0-9_.+-]+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$"))
            {
                errors.Add("Incorrect email address format");
            }
            if(customer.Notes.Count == 0)
            {
                errors.Add("Required at least 1 note");
            }

            return errors;
        }
    }
}
