using FluentValidation;
using CustomerLibrary.Entities;
using System.Linq;

namespace CustomerLibrary.Validators
{
    public class AddressValidator : AbstractValidator<Address>
    {
        private const int MaxAddressLength = 100;
        private const int MaxCityLength = 50;
        private const int MaxPostalCodeLength = 6;
        private const int MaxStateLength = 20;
        public AddressValidator()
        {
            RuleFor(address => address.AddressLine)
                .NotEmpty().WithMessage(ConstMessages.AddressLineReq)
                .MaximumLength(MaxAddressLength).WithMessage(ConstMessages.AddressLineLong);
            RuleFor(address => address.AddressLine2)
                .MaximumLength(MaxAddressLength).WithMessage(ConstMessages.AddressLine2Long);
            RuleFor(address => address.City)
                .MaximumLength(MaxCityLength).WithMessage(ConstMessages.CityLong)
                .NotEmpty().WithMessage(ConstMessages.CityReq);
            RuleFor(address => address.PostalCode)
                .MaximumLength(MaxPostalCodeLength).WithMessage(ConstMessages.PostalCodeLong)
                .NotEmpty().WithMessage(ConstMessages.PostalReq);
            RuleFor(address => address.State)
                .MaximumLength(MaxStateLength).WithMessage(ConstMessages.StateLong)
                .NotEmpty().WithMessage(ConstMessages.StateReq);
            RuleFor(address => address.Country)
                .NotEmpty().WithMessage(ConstMessages.WrongCountry)
                .Must(address => ConstMessages.Countries.Contains(address)).WithMessage(ConstMessages.WrongCountry);
        }
    }
}
