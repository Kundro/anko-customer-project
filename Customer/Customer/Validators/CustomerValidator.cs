using FluentValidation;
using CustomerLibrary.Entities;


namespace CustomerLibrary.Validators
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(customer => customer.FirstName).MaximumLength(50).WithMessage(ConstMessages.FirstNameLong);
            RuleFor(customer => customer.LastName).MaximumLength(50).WithMessage(ConstMessages.LastNameLong).NotEmpty().WithMessage(ConstMessages.LastNameReq);
            RuleFor(customer => customer.Addresses).NotEmpty().WithMessage(ConstMessages.AddressReq);
            RuleFor(customer => customer.Email).Matches(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$").WithMessage(ConstMessages.WrongEmail);
            RuleFor(customer => customer.PhoneNumber).Matches(@"^\+[1-9]\d{13}$").WithMessage(ConstMessages.WrongPhoneNumber);
            RuleFor(customer => customer.Notes).NotEmpty().WithMessage(ConstMessages.NotesReq);
        }
    }
}
