using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerLibrary
{
    public class Customer : Person
    {
        public List<Address> Addresses { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public decimal? TotalPurchasesAmount { get; set; }
        public List<string> Notes { get; set; }
        public Customer(string firstName, string lastName, List<Address> addresses, string phoneNumber, string email, decimal? totalPurchasesAmount, List<string> notes) : base(firstName, lastName)
        {
            Addresses = addresses;
            PhoneNumber = phoneNumber;
            Email = email;
            TotalPurchasesAmount = totalPurchasesAmount;
            Notes = notes;
        }
    }
}
