using CustomerLibrary.Entities;
using CustomerLibrary.Validators;
using System.Collections.Generic;
using Xunit;

namespace CustomerLibrary.Tests
{
    public class CustomerValidatorTests
    {
        [Fact]
        public void ShouldReturnLongFirstName()
        {
            Customer customer = new Customer(new string('n', 51), "surname", new List<Address>(), "number", "email", 0.0m, new List<string>());
            var current = CustomerValidator.Validate(customer);
            Assert.Contains("First name is too long", current);
        }

        [Fact]
        public void ShouldReturnLongLastName()
        {
            Customer customer = new Customer("name", new string('s', 51), new List<Address>(), "number", "email", 0.0m, new List<string>());
            var current = CustomerValidator.Validate(customer);
            Assert.Contains("Last name is too long", current);  
        }

        [Fact]
        public void ShouldNotReturnLastName()
        {
            Customer customer = new Customer("name", "", new List<Address>(), "number", "email", 0.0m, new List<string>());
            var current = CustomerValidator.Validate(customer);
            Assert.Contains("Last name required", current);
        }

        [Fact]
        public void ShouldNotReturnAddress()
        {
            Customer customer = new Customer("name", "surname", new List<Address>(), "number", "email", 0.0m, new List<string>());
            var current = CustomerValidator.Validate(customer);
            Assert.Contains("Required at least 1 address", current);
        }

        [Theory]
        [InlineData("+1111111111111")]
        [InlineData("919367788755")]
        [InlineData("91936778875a")]
        public void ShouldReturnWrongPhoneNumber(string phoneNumber)
        {
            Customer customer = new Customer("name", "surname", new List<Address>(), phoneNumber, "email", 0.0m, new List<string>());
            var current = CustomerValidator.Validate(customer);
            Assert.Contains("Incorrect phone number format", current);
        }

        [Theory]
        [InlineData("mail@mailru")]
        [InlineData("mailmailru")]
        [InlineData("mailmail.ru")]
        public void ShouldReturnWrongEmail(string email)
        {
            Customer customer = new Customer("name", "surname", new List<Address>(), "number", email, 0.0m, new List<string>());
            var current = CustomerValidator.Validate(customer);
            Assert.Contains("Incorrect email address format", current);
        }

        [Fact]
        public void ShouldNotReturnWrongEmail()
        {
            Customer customer = new Customer("name", "surname", new List<Address>(), "number", "mail.kb@mail.ru", 0.0m, new List<string>());
            var current = CustomerValidator.Validate(customer);
            Assert.DoesNotContain("Incorrect email address format", current);
        }

        [Fact]
        public void ShouldNotReturnNotes()
        {
            Customer customer = new Customer("name", "surname", new List<Address>(), "number", "email", 0.0m, new List<string>());
            var current = CustomerValidator.Validate(customer);
            Assert.Contains("Required at least 1 note", current);
        }

        [Fact]
        public void ShouldNotReturnWrongNotes()
        {
            Customer customer = new Customer("name", "surname", new List<Address>(), "number", "email", 0.0m, new List<string>() { "firstNote"});
            var current = CustomerValidator.Validate(customer);
            Assert.DoesNotContain("Required at least 1 note", current);
        }
    }
}
