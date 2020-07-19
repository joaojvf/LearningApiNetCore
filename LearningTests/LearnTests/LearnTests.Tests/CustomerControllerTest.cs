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
            _customerController = new CustomerController(new CustomerRepository());
        }

        [Fact]
        public void getCustomerWithRepository()
        {
            var result = _customerController.Get();
            Assert.Equal("customer get", result.Value.Name, ignoreCase: true);
        }
    }
}
