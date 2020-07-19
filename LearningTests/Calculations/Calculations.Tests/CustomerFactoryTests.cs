using FluentAssertions;
using System;
using Xunit;

namespace Calculations.UnitTests
{
    [Trait(@"Class", @"Calculations.CustomerFactory")]
    public class CustomerFactoryTests
    {
        [Trait(@"Method", @"Calculations.CustomerFactory.CreateCustomer")]
        [Theory(DisplayName = "CreateCustomer - Given to a customer factory, I expect to receive an instance of an object of type 'LoayalCustomer' " +
            "when executing the 'CreateCustomer' method passing values greater than 100.")]
        [InlineData(101)]
        [InlineData(102)]
        [InlineData(1000)]
        public void LoyalCustomerForOrderG100(int orderCount)
        {
            var customer = CustomerFactory.CreateCustomer(orderCount);
            customer.Should().BeOfType<LoayalCustomer>();
        }

        [Trait(@"Method", @"Calculations.CustomerFactory.CreateCustomer")]
        [Theory(DisplayName = "CreateCustomer - Given a factory of customers, I expect to receive an instance of object of type 'Customer' " +
            "when executing the 'CreateCustomer' method passing values less than or equal to 100 and 'LoayalCustomer' for values greater than 100.")]
        [InlineData(90, typeof(Customer))]
        [InlineData(100, typeof(Customer))]
        [InlineData(101, typeof(LoayalCustomer))]
        [InlineData(102, typeof(LoayalCustomer))]
        [InlineData(1000, typeof(LoayalCustomer))]
        public void FactoryByOrder(int orderCount, Type type)
        {
            var customer = CustomerFactory.CreateCustomer(orderCount);
            customer.Should().BeOfType(type);
        }
    }
}
