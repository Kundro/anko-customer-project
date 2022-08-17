using System;
using System.Collections.Generic;

namespace CustomerLibrary.Entities
{
    public class Customer : Person
    {
        public override string FirstName { get => base.FirstName; set => base.FirstName = value; }
        public override string LastName { get => base.LastName; set => base.LastName = value; }
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
