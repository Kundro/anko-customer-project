using Xunit;
using System.Collections.Generic;
using CustomerLibrary.Entities;
using CustomerLibrary.Validators;
using FluentValidation.TestHelper;

namespace CustomerLibrary.Tests
{
    public class CustomerTests
    {
        [Fact]
        public void ShouldBeAbleToCreateCustomer()
        {
            Customer customer = new Customer(firstName: "name", lastName: "surname", addresses: new List<Address>(), phoneNumber: "+9123456789112", email: "mail.a@mail.ru", totalPurchasesAmount: 0.0m, notes: new List<string>() { "note1", "note2" });
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
            CustomerValidator customerValidator = new CustomerValidator();

            Customer customer = new Customer(new string('n', 51), "", null, "+142", "mailmail@ma", 0, new List<string>());
            var res = customerValidator.TestValidate(customer);

            res.ShouldHaveValidationErrorFor(customer => customer.FirstName);
            res.ShouldHaveValidationErrorFor(customer => customer.LastName);
            res.ShouldHaveValidationErrorFor(customer => customer.Addresses);
            res.ShouldHaveValidationErrorFor(customer => customer.Email);
            res.ShouldHaveValidationErrorFor(customer => customer.Notes);
            res.ShouldHaveValidationErrorFor(customer => customer.PhoneNumber);
        }

        [Fact]
        public void ShouldBeAbleToCreateCustomerUsingCustomerCreateParams()
        {
            CustomerCreateParams customerCreateParams = new CustomerCreateParams();
            Customer customer = new Customer(firstName: "name", lastName: "surname", customerCreateParams);

            Assert.Equal(customer.FirstName, customerCreateParams.FirstName);
            Assert.Equal(customer.LastName, customerCreateParams.LastName);
            Assert.Equal(customer.Addresses, customerCreateParams.Addresses);
            Assert.Equal(customer.Notes, customerCreateParams.Notes);
            Assert.Equal(customer.TotalPurchasesAmount, customerCreateParams.TotalPurchasesAmount);
            Assert.Equal(customer.Email, customerCreateParams.Email);
            Assert.Equal(customer.PhoneNumber, customerCreateParams.PhoneNumber);
        }
    }
}
