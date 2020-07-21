using FluentAssertions;
using LearnTests.API.Controllers;
using LearnTests.Domain.Entities;
using LearnTests.Domain.Interfaces.Repositories;
using LearnTests.Infra.Data.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LearnTests.Tests
{
    public class CustomerControllerTest
    {
        private readonly CustomerController _customerController;

        public CustomerControllerTest()
        {
            var fakeCustomerRepository = new Mock<ICustomerRepository>();

            fakeCustomerRepository.Setup(cr => cr.GetCustomer())
                .Returns(new Customer { Name = "customer get", Age = 34 });

            _customerController = new CustomerController(fakeCustomerRepository.Object);
        }

        [Fact(DisplayName = "Check name returned of repository.")]
        public void GetCustomerWithRepository()
        {
            var result = _customerController.Get();
            result.Value.Name.Should().BeEquivalentTo("Customer get", "");
        }

    }
}
