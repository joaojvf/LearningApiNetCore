using FluentAssertions;
using FluentAssertions.Execution;
using System;
using Xunit;

namespace Calculations.UnitTests
{
    [Trait(@"Class", @"Calculations.Customer")]
    public class CustomerTests : IClassFixture<CustomerFixtures>
    {
        private readonly CustomerFixtures _customerFixtures;
        public CustomerTests(CustomerFixtures customerFixtures)
        {
            _customerFixtures = customerFixtures;
        }

        [Trait(@"Property", @"Calculations.Customer.Name")]
        [Fact(DisplayName = "Name - Given a customer, I expect the name is not null and not empty")]
        public void checkNameNotEmpty()
        {
            _customerFixtures.Customer.Name.Should().NotBeNull()
                .And.NotBeNullOrWhiteSpace();
        }

        [Trait(@"Property", @"Calculations.Customer.Age")]
        [Fact(DisplayName = "Age - Given a customer, I expect the age is greater than or equal to 18 and less than or equal to 60")]
        public void checkAge()
        {
            _customerFixtures.Customer.Age.Should().BeInRange(18, 60);
        }

        [Trait(@"Method", @"Calculations.Customer.GetOrdersByName")]
        [Fact(DisplayName = "GetOrdersByName - Given to a customer, I expect the exception 'ArgumentException' to be thrown with the message 'Value does not fall within the expected range.' when executing the 'GetOrdersByName' method passing the name null or empty.")]
        public void GetOrdersByNameNotNull()
        {
            Action actEmpty = () => _customerFixtures.Customer.GetOrdersByName("");
            Action actNull = () => _customerFixtures.Customer.GetOrdersByName(null);
            Action actDefault = () => _customerFixtures.Customer.GetOrdersByName(default);

            var message = "Value does not fall within the expected range.";

            using (new AssertionScope())
            {
                actEmpty.Should().Throw<ArgumentException>("Name cannot be empty").WithMessage(message);
                actNull.Should().Throw<ArgumentException>("Name cannot be null").WithMessage(message);
                actDefault.Should().Throw<ArgumentException>("Name cannot be default").WithMessage(message);
            }
        }

        [Trait(@"Method", @"Calculations.Customer.GetOrdersByName")]
        [Fact(DisplayName = "GetOrdersByName - Given to a customer, I expect to receive the customer's position when executing the 'GetOrdersByName' method by passing the name.")]
        public void GetOrdersByName()
        {
            var result = _customerFixtures.Customer.GetOrdersByName(_customerFixtures.Customer.Name);
            result.Should().BeGreaterThan(0);
        }
    }
}
