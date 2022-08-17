using Xunit;
using System.Collections.Generic;
using CustomerLibrary.Entities;
using CustomerLibrary.Validators;
using FluentValidation.TestHelper;

namespace CustomerLibrary.Tests
{
    public class AddressTests
    {
        AddressValidator addressValidator = new AddressValidator();

        [Fact]
        public void ShouldBeAbleToCreateAddress()
        {
            Address address = new Address("line1", "line2", AddressType.Shipping, "Chicago", "60666", "Illinois", "USA");
            Assert.Equal("line1", address.AddressLine);
            Assert.Equal("line2", address.AddressLine2);
            Assert.Equal(AddressType.Shipping, address.AddressType);
            Assert.Equal("Chicago", address.City);
            Assert.Equal("60666", address.PostalCode);
            Assert.Equal("Illinois", address.State);
            Assert.Equal("USA", address.Country);
        }

        [Fact]
        public void ShouldBeCreateWrongAddress()
        {
            Address address = new Address("", new string('1', 101), null, null, "1234567", new string('s',21), "Belarus");
            var res = addressValidator.TestValidate(address);
            res.ShouldHaveValidationErrorFor(address => address.AddressLine);
            res.ShouldHaveValidationErrorFor(address => address.AddressLine2);
            res.ShouldHaveValidationErrorFor(address => address.State);
            res.ShouldHaveValidationErrorFor(address => address.Country);
            res.ShouldHaveValidationErrorFor(address => address.PostalCode);
            res.ShouldHaveValidationErrorFor(address => address.City);
        }

        [Theory]
        [InlineData("Belarus")]
        [InlineData("USW")]
        [InlineData("russia")]
        public void ShouldBeCreateWrongCountryName(string country)
        {
            Address address = new Address("Street", "6/A", AddressType.Billing, "Chicago", "60666", "Illinois", country);

            var res = addressValidator.TestValidate(address);
            res.ShouldHaveValidationErrorFor(address => address.Country);
        }
    }
}
