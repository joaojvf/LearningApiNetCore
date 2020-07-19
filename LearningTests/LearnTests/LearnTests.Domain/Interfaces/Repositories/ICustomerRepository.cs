using LearnTests.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearnTests.Domain.Interfaces.Repositories
{
    public interface ICustomerRepository
    {
        Customer GetCustomer();
    }
}
