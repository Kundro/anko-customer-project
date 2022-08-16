using Xunit;
using System.Collections.Generic;
using CustomerLibrary.Entities;

namespace CustomerLibrary.Tests
{
    public class CustomerTests
    {
        [Fact]
        public void ShouldBeAbleToCreateCustomer()
        {
            Customer customer = new Customer("name", "surname", new List<Address>(), "number", "email", 0.0m, new List<string>());
        }

        [Fact]
        public void ShouldBeEqualFirstName()
        {
            Customer customer = new Customer("name", "surname", new List<Address>(), "number", "email", 0.0m, new List<string>());

            Assert.Equal("name", customer.FirstName);
        }

        [Fact]
        public void ShouldBeEqualLastName()
        {
            Customer customer = new Customer("name", "surname", new List<Address>(), "number", "email", 0.0m, new List<string>());

            Assert.Equal("surname", customer.LastName);
        }

        [Fact]
        public void ShouldBeEqualAddressList()
        {
            Customer customer = new Customer("name", "surname", new List<Address>(), "number", "email", 0.0m, new List<string>());
            Assert.NotNull(customer.Addresses);
            Assert.IsType<List<Address>>(customer.Addresses);
        }

        [Fact]
        public void ShouldBeEqualPhoneNumber()
        {
            Customer customer = new Customer("name", "surname", new List<Address>(), "number", "email", 0.0m, new List<string>());

            Assert.Equal("number", customer.PhoneNumber);
        }

        [Fact]
        public void ShouldBeEqualEmail()
        {
            Customer customer = new Customer("name", "surname", new List<Address>(), "number", "email", 0.0m, new List<string>());

            Assert.Equal("email", customer.Email);
        }

        [Fact]
        public void ShouldBeEqualTotalPurchasesAmount()
        {
            Customer customer = new Customer("name", "surname", new List<Address>(), "number", "email", 0.0m, new List<string>());

            Assert.Equal(0.0m, customer.TotalPurchasesAmount);
        }

        [Fact]
        public void ShouldBeEqualNotes()
        {
            Customer customer = new Customer("name", "surname", new List<Address>(), "number", "email", 0.0m, new List<string>());
            Assert.IsType<List<string>>(customer.Notes);
            Assert.NotNull(customer.Notes);

        }
    }
}
