namespace CustomerLibrary
{
    class ConstMessages
    {
        // Customer Validator
        public const string LastNameLong = "Last name is too long";
        public const string FirstNameLong = "First name is too long";
        public const string LastNameReq = "Last name required";
        public const string AddressReq = "Required at least 1 address";
        public const string WrongPhoneNumber = "Incorrect phone number format";
        public const string WrongEmail = "Incorrect email address format";
        public const string NotesReq = "Required at least 1 note";

        // Address Validator
        public const string AddressLineLong = "Address line is too long";
        public const string AddressLine2Long = "Address line 2 is too long";
        public const string AddressLineReq = "Address line required";
        public const string CityLong = "City name is too long";
        public const string CityReq = "City name required";
        public const string PostalCodeLong = "Postal code is too long";
        public const string PostalReq = "Postal code required";
        public const string StateReq = "State name required";
        public const string StateLong = "State name is too long";
        public const string WrongCountry = "Wrong country name";

        // Countries
        public static readonly string[] Countries =
        {
            "USA",
            "United States",
            "United States of America",
            "Canada",
        };
    }
}
