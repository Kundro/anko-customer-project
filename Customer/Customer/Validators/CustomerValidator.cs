using FluentValidation;
using CustomerLibrary.Entities;


namespace CustomerLibrary.Validators
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        

        /*
        public static List<string> Validate(Customer customer)
        {
            List<string> errors = new List<string>();

            if (customer.FirstName?.Length > 50)
            {
                errors.Add(ConstMessages.FirstNameLong);
            }
            if (customer.LastName.Length > 50)
            {
                errors.Add(ConstMessages.LastNameLong);
            }
            if (string.IsNullOrWhiteSpace(customer.LastName))
            {
                errors.Add(ConstMessages.LastNameReq);
            }
            if(customer.Addresses.Count == 0)
            {
                errors.Add(ConstMessages.AddressReq);
            }
            if (!Regex.IsMatch(customer.PhoneNumber, @"^\+[1-9]\d{13}$"))
            {
                errors.Add(ConstMessages.WrongPhoneNumber);
            }
            if (!Regex.IsMatch(customer.Email, @"^[a-zA-Z0-9_.+-]+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$"))
            {
                errors.Add(ConstMessages.WrongEmail);
            }
            if(customer.Notes.Count == 0)
            {
                errors.Add(ConstMessages.NotesReq);
            }

            return errors;
        }
        */
    }
}
