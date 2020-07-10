using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Calculations.Tests
{
    public class CustomerTest
    {
        [Fact]
        public void checkNameNotEmpty()
        {
            var customer = new Customer();
            Assert.NotNull(customer.Name);
            Assert.False(string.IsNullOrEmpty(customer.Name));
        }

        [Fact]
        public void checkAge()
        {
            var customer = new Customer();
            Assert.InRange(customer.Age, 18, 60);
        }


        [Fact]
        public void GetOrdersByNameNotNull()
        {
            var customer = new Customer();
            Assert.Throws<ArgumentException>(
                () => customer.GetOrdersByName(""));
        }

        [Fact]
        public void LoyalCustomerForOrderG100()
        {
            var customer = CustomerFactory.CreateCustomer(101);
            Assert.IsType(typeof(LoayalCustomer), customer);
        }
    }
}
