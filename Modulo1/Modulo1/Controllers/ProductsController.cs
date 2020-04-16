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
    public class ProductsController : ControllerBase
    {
        static List<Product> _products = new List<Product>()
        {
            new Product(){ProductId = 0, ProductName =  "Laptop", ProductPrice = "200"},
            new Product(){ProductId = 1, ProductName =  "Smartphone", ProductPrice = "100"},
        };

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_products);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _products.RemoveAt(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Product product)
        {
            _products.Add(product);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Product product)
        {
            _products[id] = product;
        }



    }
}