using LearnTests.Domain.Entities;
using LearnTests.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearnTests.Infra.Data.Repositories
{
    internal class CustomerRepository : ICustomerRepository
    {
        public Customer GetCustomer()
        {
            return new Customer() { Name = "Customer Get", Age = 18 };
        }
    }
}
