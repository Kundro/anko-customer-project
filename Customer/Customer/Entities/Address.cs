using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerLibrary.Entities
{
    public enum AddressType
    {
        Shipping,
        Billing
    }
    public class Address
    {
        public Address(string addressLine, string addressLine2, AddressType addressType)
        {
            AddressLine = addressLine;
            AddressLine2 = addressLine2;
            AddressType = addressType;     
        }

        public string AddressLine { get; set; }
        public string AddressLine2 { get; set; }
        public AddressType AddressType { get; set; }
        
    }
}
