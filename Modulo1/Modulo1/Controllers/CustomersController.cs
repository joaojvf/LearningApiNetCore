using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modulo1.Models;

namespace Modulo1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        static List<Customer> customers = new List<Customer>() {
            new Customer() { Id = 1, Name = "Tom Cruise", Email = "tomcruise@gmail.com", Phone = "3322" }, 
            new Customer() { Id = 1, Name = "Robert Downy Jr", Email = "robert@gmail.com", Phone = "326" },
            new Customer() { Id = 1, Name = "Chris patt", Email = "cpatt@hotmail.com", Phone = "659" },
        };

        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return customers;
        }

        [HttpPost]
        public IActionResult Post([FromBody]Customer customer)
        {
            if (ModelState.IsValid)
            {
                customers.Add(customer);
                return Ok();
            }

            return BadRequest(ModelState);
        }

    }
}