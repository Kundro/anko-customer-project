namespace CustomerLibrary.Entities
{
    public enum AddressType
    {
        Unknown,
        Shipping,
        Billing
    }
    public class Address
    {
        public Address(string addressLine, string addressLine2, AddressType? addressType, string city, string postalCode, string state, string country)
        {
            AddressLine = addressLine;
            AddressLine2 = addressLine2;

            if (addressType.HasValue)
            {
                AddressType = addressType.Value;
            }

            City = city;
            PostalCode = postalCode;
            State = state;
            Country = country;
        }

        public string AddressLine { get; set; } = string.Empty;
        public string AddressLine2 { get; set; }
        public AddressType AddressType { get; set; } = AddressType.Unknown;
        public string City { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
    }
}
