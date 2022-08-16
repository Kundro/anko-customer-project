using CustomerLibrary.Entities;
using Xunit;

namespace CustomerLibrary.Tests
{
    public class AddressTests
    {
        [Fact]
        public void ShouldBeAbleToCreateAddress()
        {
            Address address = new Address("line1", "line2", AddressType.Shipping, "Chicago", "60666", "Illinois", "USA");
            Assert.NotNull(address.AddressLine);
            Assert.Equal("line1", address.AddressLine);
        }

        [Fact]
        public void ShouldBeEqualAddressLine()
        {
            Address address = new Address("line1", "line2", AddressType.Shipping, "Chicago", "60666", "Illinois", "USA");
            Assert.NotNull(address.AddressLine);
            Assert.Equal("line1", address.AddressLine);
        }

        [Fact]
        public void ShouldBeEqualAddressLine2()
        {
            Address address = new Address("line1", "line2", AddressType.Shipping, "Chicago", "60666", "Illinois", "USA");
            Assert.Equal("line2", address.AddressLine2);
        }

        [Fact]
        public void ShouldBeEqualAddressLine2Null()
        {
            Address address = new Address("line1", "", AddressType.Shipping, "Chicago", "60666", "Illinois", "USA");
            address.AddressLine2.Equals(null);
        }

        [Fact]
        public void ShouldBeEqualAddressType()
        {
            Address address = new Address("line1", "line2", AddressType.Shipping, "Chicago", "60666", "Illinois", "USA");
            address.AddressType.Equals(AddressType.Shipping);
        }

        [Fact]
        public void ShouldBeEqualCity()
        {
            Address address = new Address("line1", "line2", AddressType.Shipping, "Chicago", "60666", "Illinois", "USA");
            Assert.NotNull(address.City);
            Assert.Equal("Chicago", address.City);
        }

        [Fact]
        public void ShouldBeEqualPostalCode()
        {
            Address address = new Address("line1", "line2", AddressType.Shipping, "Chicago", "60666", "Illinois", "USA");
            Assert.NotNull(address.PostalCode);
            Assert.Equal("60666", address.PostalCode);
        }

        [Fact]
        public void ShouldBeEqualState()
        {
            Address address = new Address("line1", "line2", AddressType.Shipping, "Chicago", "60666", "Illinois", "USA");
            Assert.NotNull(address.State);
            Assert.Equal("Illinois", address.State);
        }

        [Fact]
        public void ShouldBeEqualCountry()
        {
            Address address = new Address("line1", "line2", AddressType.Shipping, "Chicago", "60666", "Illinois", "USA");
            Assert.NotNull(address.Country);
            Assert.Equal("USA", address.Country);
        }
    }
}
