using Xunit;
using System.Collections.Generic;
using CustomerLibrary.Entities;
using CustomerLibrary.Validators;
using FluentValidation.TestHelper;

namespace CustomerLibrary.Tests
{
    public class AddressTests
    {
        [Fact]
        public void ShouldBeAbleToCreateAddress()
        {
            Address address = new Address(addressLine2: "line2", addressLine: "line1", addressType: AddressType.Shipping, city: "Chicago", postalCode:  "60666", state: "Illinois", country: "USA");
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
            AddressValidator addressValidator = new AddressValidator();

            Address address = new Address(addressLine: "", addressLine2: new string('1', 101), addressType: null, city: null, postalCode: "1234567", state: new string('s',21), country: "Belarus");
            var res = addressValidator.TestValidate(address);
            res.ShouldHaveValidationErrorFor(address => address.AddressLine);
            res.ShouldHaveValidationErrorFor(address => address.AddressLine2);
            res.ShouldHaveValidationErrorFor(address => address.City);
            res.ShouldHaveValidationErrorFor(address => address.State);
            res.ShouldHaveValidationErrorFor(address => address.PostalCode);
            res.ShouldHaveValidationErrorFor(address => address.Country);
        }

        [Fact]
        public void ShouldBeAbleToCreateAddressUsingCreateAddressParams()
        {
            CreateAddressParams createAddressParams = new CreateAddressParams();
            Address address = new Address(createAddressParams);

            Assert.Equal(address.AddressLine, createAddressParams.AddressLine);
            Assert.Equal(address.AddressLine2, createAddressParams.AddressLine2);
            Assert.Equal(address.State, createAddressParams.State);
            Assert.Equal(address.Country, createAddressParams.Country);
            Assert.Equal(address.City, createAddressParams.City);
            Assert.Equal(address.AddressType, createAddressParams.AddressType);
            Assert.Equal(address.PostalCode, createAddressParams.PostalCode);
        }

        [Theory]
        [InlineData("Belarus")]
        [InlineData("USW")]
        [InlineData("russia")]
        public void ShouldBeCreateWrongCountryName(string country)
        {
            AddressValidator addressValidator = new AddressValidator();

            Address address = new Address("Street", "6/A", AddressType.Billing, "Chicago", "60666", "Illinois", country);

            var res = addressValidator.TestValidate(address);
            res.ShouldHaveValidationErrorFor(address => address.Country);
        }
    }
}
