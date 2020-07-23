using FluentAssertions;
using LearnTests.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Extensions;

namespace LearnTests.Tests
{
    public class CustomerTest
    {
        private Customer _customer;
        public CustomerTest()
        {
            _customer = new Customer()
            {
                Name = "Joao Victor",
                Age = 19
            };
        }

        [Fact]
        public void checkNameNotEmpty()
        {
            Assert.False(string.IsNullOrEmpty(_customer.Name));
        }

        [Fact]
        public void checkTypeOfName()
        {
            Assert.IsType<string>(_customer.Name);
        }

        [Fact(DisplayName = "Check a interval of age.")]
        public void CheckAge()
        {
            Assert.InRange(_customer.Age, 18, 60);
        }

        [Fact(DisplayName = "validates a Collection if age is between 18 and 60 and return true.")]
        public void CreateCollection_CheckRangeOfAge_ReturnTrue()
        {
            List<Customer> customers = new List<Customer>()
            {
                _customer,
                new Customer()
                {
                    Name = "Caio",
                    Age = 21
                },
                new Customer()
                {
                    Name = "Dolph",
                    Age = 28
                },
            };

            customers.Should().Contain(c => c.Age >= 18 && c.Age <= 60);
        }
    }
}
