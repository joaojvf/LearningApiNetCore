using FluentAssertions;
using FluentAssertions.Execution;
using LearnTests.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
        public void CheckNameNotEmpty()
        {
            Assert.False(string.IsNullOrEmpty(_customer.Name));
        }

        [Fact]
        public void CheckTypeOfName()
        {
            Assert.IsType<string>(_customer.Name);
        }

        [Fact]
        public void CheckAge()
        {
            Assert.InRange(_customer.Age, 18, 60);
        }

        [Fact]
        public void CheckAgeInCollection()
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

        [Trait(@"Property", @"Customer.CreateCustomer")]
        [Fact(DisplayName = "Valid a customer model")]
        public void CheckModelState()
        {
            var customerFalse = new Customer() { Name = "Jo", Age = 23 };            
            var contextFalse = new ValidationContext(customerFalse, null, null);

            var customerTrue = new Customer() { Name = "Joao", Age = 23 };
            var contextTrue = new ValidationContext(customerTrue, null, null);

            var resultModelValidation = new List<ValidationResult>();
            TypeDescriptor.AddProviderTransparent(new AssociatedMetadataTypeTypeDescriptionProvider(typeof(Customer),
                typeof(Customer)), typeof(Customer));

            var isModelStateValidFalse = Validator.TryValidateObject(customerFalse, contextFalse, resultModelValidation, true);
            var isModelStateValidTrue = Validator.TryValidateObject(customerTrue, contextTrue, resultModelValidation, true);

            using( new AssertionScope())
            {
                isModelStateValidFalse.Should().Be(false);
                isModelStateValidTrue.Should().Be(true);
            }
        }
    }
}
