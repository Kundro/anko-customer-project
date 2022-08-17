using CustomerLibrary.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CustomerLibrary.Validators
{
    public class AddressValidator
    {
        static readonly string[] COUNTRIES =
        {
            "USA",
            "united states",
            "United States",
            "United States of America",
            "Canada",
            "canada"
        };
        const string ADDRESS_LINE_LONG = "Address line is too long";
        const string ADDRESS_LINE_2_LONG = "Address line 2 is too long";
        const string ADDRESS_LINE_REQ = "Address line required";
        const string CITY_LONG = "City name is too long";
        const string CITY_REQ = "City name required";
        const string POSTAL_CODE_LONG = "Postal code is too long";
        const string POSTAL_REQ = "Postal code required";
        const string STATE_REQ = "State name required";
        const string STATE_LONG = "State name is too long";
        const string WRONG_COUNTRY = "Wrong country name";



        public static List<string> Validate(Address address)
        {
            var errors = new List<string>();

            if (address.AddressLine.Length > 100)
            {
                errors.Add(ADDRESS_LINE_LONG);
            }
            if (string.IsNullOrWhiteSpace(address.AddressLine))
            {
                errors.Add(ADDRESS_LINE_REQ);
            }
            if (address.AddressLine2.Length > 100)
            {
                errors.Add(ADDRESS_LINE_2_LONG);
            }
            if (address.City.Length > 50)
            {
                errors.Add(CITY_LONG);
            }
            if(address.PostalCode.Length > 6)
            {
                errors.Add(POSTAL_CODE_LONG);
            }
            if (string.IsNullOrWhiteSpace(address.City))
            {
                errors.Add(CITY_REQ);
            }
            if (string.IsNullOrWhiteSpace(address.PostalCode))
            {
                errors.Add(POSTAL_REQ);
            }
            if (string.IsNullOrWhiteSpace(address.State))
            {
                errors.Add(STATE_REQ);
            }
            if (address.State.Length > 20)
            {
                errors.Add(STATE_LONG);
            }
            if (!COUNTRIES.Contains(address.Country))
            {
                errors.Add(WRONG_COUNTRY);
            }

            return errors;
        }
    }
}
