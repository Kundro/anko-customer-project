using CustomerLibrary.Entities;
using CustomerLibrary.Validators;
using Xunit;

namespace CustomerLibrary.Tests
{
    public class AddressValidatorTests
    {
        [Fact]
        public void ShouldReturnLongAddressLine()
        {
            Address address = new Address(new string('1', 101), "line2", AddressType.Shipping, "Chicago", "60666", "Illinois", "USA");
            var current = AddressValidator.Validate(address);
            Assert.Contains("Address line is too long", current);
        }

        [Fact]
        public void ShouldReturnWrongAddressLine()
        {
            Address address = new Address("", "line2", AddressType.Shipping, "Chicago", "60666", "Illinois", "USA");
            var current = AddressValidator.Validate(address);
            Assert.Contains("Address line required", current);
        }

        [Fact]
        public void ShouldReturnLongAddressLine2()
        {
            Address address = new Address("line", new string('2', 101), AddressType.Shipping, "Chicago", "60666", "Illinois", "USA");
            var current = AddressValidator.Validate(address);
            Assert.Contains("Address line 2 is too long", current);
        }

        [Fact]
        public void ShouldReturnLongCity()
        {
            Address address = new Address("line", "line2", AddressType.Shipping, new string('c', 51), "60666", "Illinois", "USA");
            var current = AddressValidator.Validate(address);
            Assert.Contains("City name is too long", current);
        }

        [Fact]
        public void ShouldReturnLongPostalCode()
        {
            Address address = new Address("line", "line2", AddressType.Shipping, "Chicago", new string('c', 7), "Illinois", "USA");
            var current = AddressValidator.Validate(address);
            Assert.Contains("Postal code is too long", current);
        }

        [Fact]
        public void ShouldNotReturnCity()
        {
            Address address = new Address("line", "line2", AddressType.Shipping, "", "60666", "Illinois", "USA");
            var current = AddressValidator.Validate(address);
            Assert.Contains("City name required", current);
        }

        [Fact]
        public void ShouldNotReturnPostalCode()
        {
            Address address = new Address("line", "line2", AddressType.Shipping, "Chicago", "", "Illinois", "USA");
            var current = AddressValidator.Validate(address);
            Assert.Contains("Postal code required", current);
        }

        [Fact]
        public void ShouldNotReturnState()
        {
            Address address = new Address("line", "line2", AddressType.Shipping, "Chicago", "60666", "", "USA");
            var current = AddressValidator.Validate(address);
            Assert.Contains("State name required", current);
        }

        [Fact]
        public void ShouldReturnLongState()
        {
            Address address = new Address("line", "line2", AddressType.Shipping, "Chicago", "60666", new string('c', 21), "USA");
            var current = AddressValidator.Validate(address);
            Assert.Contains("State name is too long", current);
        }

        [Fact]
        public void ShouldReturnWrongCountry()
        {
            Address address = new Address("line", "line2", AddressType.Shipping, "Chicago", "60666", "Illinois", "Belarus");
            var current = AddressValidator.Validate(address);
            Assert.Contains("Wrong country name", current);
        }
    }
}
