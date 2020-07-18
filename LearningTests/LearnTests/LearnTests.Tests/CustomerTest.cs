using LearnTests.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

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

        [Fact]
        public void checkAge()
        {
            Assert.InRange(_customer.Age, 18, 60);
        }

        [Fact]
        public void checkAgeInCollection()
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

            Assert.All(customers, 
                c => Assert.InRange(c.Age, 18, 60));
        }
    }
}
