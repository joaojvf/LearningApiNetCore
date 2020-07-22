using LearnTests.Domain.Entities;
using LearnTests.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LearnTests.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository customerRepository;
        public CustomerController(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        [HttpGet]
        public ActionResult<Customer> Get()
        {
            return customerRepository.GetCustomer();
        }

        [HttpPost]
        public ActionResult<Customer> Post([FromBody] Customer newCustomer)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return newCustomer;
        }
    }
}