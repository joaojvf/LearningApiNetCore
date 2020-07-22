using FluentAssertions;
using FluentAssertions.Execution;
using LearnTests.API.Controllers;
using LearnTests.Domain.Entities;
using LearnTests.Domain.Interfaces.Repositories;
using LearnTests.Infra.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
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

        [Fact(DisplayName = "Check return if bad request or new customer from post")]
        public void PostCustomerController()
        {
            var customer = new Customer() { Name = "Joao", Age = 23 };
            var responseValid = _customerController.Post(customer);

            _customerController.ModelState.AddModelError("Name", "O nome deve ter pelo menos 4 caracteres.");
            var responseBadRequest = _customerController.Post(customer);
            var result = Assert.IsType<BadRequestObjectResult>(responseBadRequest.Result);

            using (new AssertionScope())
            {
                responseValid.Value.Should().BeOfType(typeof(Customer), "");
                result.StatusCode.Should().Be(400);
            }
        }

    }
}
