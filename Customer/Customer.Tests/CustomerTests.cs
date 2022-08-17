using Xunit;
using System.Collections.Generic;
using CustomerLibrary.Entities;
using CustomerLibrary.Validators;
using FluentValidation.TestHelper;

namespace CustomerLibrary.Tests
{
    public class CustomerTests
    {
        CustomerValidator customerValidator = new CustomerValidator();

        [Fact]
        public void ShouldBeAbleToCreateCustomer()
        {
            Customer customer = new Customer("name", "surname", new List<Address>(), "+9123456789112", "mail.a@mail.ru", 0.0m, new List<string>() { "note1", "note2" });
            Assert.Equal("name", customer.FirstName);
            Assert.Equal("surname", customer.LastName);
            Assert.Equal("+9123456789112", customer.PhoneNumber);
            Assert.Equal("mail.a@mail.ru", customer.Email);
            Assert.Equal("note1", customer.Notes[0]);
            Assert.Equal(0.0m, customer.TotalPurchasesAmount);
            Assert.Equal(new List<Address>(), customer.Addresses);
        }

        [Fact]
        public void ShouldBeCreateWrongCustomer()
        {
            Customer customer = new Customer(new string('n', 51), "", null, "+142", "mailmail@ma", 0, new List<string>());
            var res = customerValidator.TestValidate(customer);

            res.ShouldHaveValidationErrorFor(customer => customer.FirstName);
            res.ShouldHaveValidationErrorFor(customer => customer.LastName);
            res.ShouldHaveValidationErrorFor(customer => customer.Addresses);
            res.ShouldHaveValidationErrorFor(customer => customer.Email);
            res.ShouldHaveValidationErrorFor(customer => customer.Notes);
            res.ShouldHaveValidationErrorFor(customer => customer.PhoneNumber);
        }
    }
}
