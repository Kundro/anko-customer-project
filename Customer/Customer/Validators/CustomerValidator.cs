using FluentValidation;
using CustomerLibrary.Entities;


namespace CustomerLibrary.Validators
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        private const int FirstNameMaxLength = 50;
        private const int LastNameMaxLength = 50;
        public CustomerValidator()
        {
            RuleFor(customer => customer.FirstName).MaximumLength(FirstNameMaxLength).WithMessage(ConstMessages.FirstNameLong);
            RuleFor(customer => customer.LastName).MaximumLength(LastNameMaxLength).WithMessage(ConstMessages.LastNameLong).NotEmpty().WithMessage(ConstMessages.LastNameReq);
            RuleFor(customer => customer.Addresses).NotEmpty().WithMessage(ConstMessages.AddressReq);
            RuleFor(customer => customer.Email).Matches(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$").WithMessage(ConstMessages.WrongEmail);
            RuleFor(customer => customer.PhoneNumber).Matches(@"^\+[1-9]\d{13}$").WithMessage(ConstMessages.WrongPhoneNumber);
            RuleFor(customer => customer.Notes).NotEmpty().WithMessage(ConstMessages.NotesReq);
        }
    }
}
