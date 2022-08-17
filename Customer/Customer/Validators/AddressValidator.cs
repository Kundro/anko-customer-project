using CustomerLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomerLibrary.Validators
{
    public class AddressValidator
    {
        private const int MaxAddressLength = 100;
        private const int MaxCityLength = 50;
        private const int MaxPostalCodeLength = 6;
        private const int MaxStateLength = 20;


        public static List<string> Validate(Address address)
        {
            var errors = new List<string>();

            if (address.AddressLine.Length > MaxAddressLength)
            {
                errors.Add(ConstMessages.AddressLineLong);
            }
            if (string.IsNullOrWhiteSpace(address.AddressLine))
            {
                errors.Add(ConstMessages.AddressLineReq);
            }
            if (address.AddressLine2?.Length > MaxAddressLength)
            {
                errors.Add(ConstMessages.AddressLine2Long);
            }
            if (address.City.Length > MaxCityLength)
            {
                errors.Add(ConstMessages.CityLong);
            }
            if(address.PostalCode.Length > MaxPostalCodeLength)
            {
                errors.Add(ConstMessages.PostalCodeLong);
            }
            if (string.IsNullOrWhiteSpace(address.City))
            {
                errors.Add(ConstMessages.CityReq);
            }
            if (string.IsNullOrWhiteSpace(address.PostalCode))
            {
                errors.Add(ConstMessages.PostalReq);
            }
            if (string.IsNullOrWhiteSpace(address.State))
            {
                errors.Add(ConstMessages.StateReq);
            }
            if (address.State.Length > MaxStateLength)
            {
                errors.Add(ConstMessages.StateLong);
            }
            if (!ConstMessages.Countries.Contains(address.Country, StringComparer.OrdinalIgnoreCase))
            {
                errors.Add(ConstMessages.WrongCountry);
            }

            return errors;
        }
    }
}
