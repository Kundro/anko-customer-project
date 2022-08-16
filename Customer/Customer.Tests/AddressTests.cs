using CustomerLibrary.Entities;
using System;
using Xunit;

namespace CustomerLibrary.Tests
{
    public class AddressTests
    {
        [Fact]
        public void ShouldBeAbleToCreateAddress()
        {
            Address address = new Address("line1", "line2", AddressType.Shipping);
            Assert.NotNull(address.AddressLine);
            Assert.Equal("line1", address.AddressLine);
        }

        [Fact]
        public void ShouldBeEqualAddressLine()
        {
            Address address = new Address("line1", "line2", AddressType.Shipping);
            Assert.NotNull(address.AddressLine);
            Assert.Equal("line1", address.AddressLine);
        }

        [Fact]
        public void ShouldBeEqualAddressLine2()
        {
            Address address = new Address("line1", "line2", AddressType.Shipping);
            Assert.NotNull(address.AddressLine2);
            Assert.Equal("line2", address.AddressLine2);
        }

        [Fact]
        public void ShouldBeEqualAddressType()
        {
            Address address = new Address("line1", "line2", AddressType.Shipping);
            address.AddressType.Equals(AddressType.Shipping);
        }
    }
}
