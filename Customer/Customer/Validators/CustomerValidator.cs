using CustomerLibrary.Entities;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CustomerLibrary.Validators
{
    public class CustomerValidator
    {
        const string FIRST_NAME_LONG = "First name is too long";
        const string LAST_NAME_LONG = "Last name is too long";
        const string LAST_NAME_REQ = "Last name required";
        const string ADDRESS_REQ = "Required at least 1 address";
        const string WRONG_PHONE_NUMBER = "Incorrect phone number format";
        const string WRONG_EMAIL = "Incorrect email address format";
        const string NOTES_REQ = "Required at least 1 note";

        public static List<string> Validate(Customer customer)
        {
            List<string> errors = new List<string>();

            if (customer.FirstName.Length > 50)
            {
                errors.Add(FIRST_NAME_LONG);
            }
            if (customer.LastName.Length > 50)
            {
                errors.Add(LAST_NAME_LONG);
            }
            if (string.IsNullOrWhiteSpace(customer.LastName))
            {
                errors.Add(LAST_NAME_REQ);
            }
            if(customer.Addresses.Count == 0)
            {
                errors.Add(ADDRESS_REQ);
            }
            if (!Regex.IsMatch(customer.PhoneNumber, @"^\+[1-9]\d{13}$"))
            {
                errors.Add(WRONG_PHONE_NUMBER);
            }
            if (!Regex.IsMatch(customer.Email, @"^[a-zA-Z0-9_.+-]+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$"))
            {
                errors.Add(WRONG_EMAIL);
            }
            if(customer.Notes.Count == 0)
            {
                errors.Add(NOTES_REQ);
            }

            return errors;
        }
    }
}
