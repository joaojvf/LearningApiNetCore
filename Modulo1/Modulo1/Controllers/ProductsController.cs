using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modulo1.Data;
using Modulo1.Models;

namespace Modulo1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private ProductDbContext productDbContext;

        public ProductsController(ProductDbContext _productDbContext)
        {
            productDbContext = _productDbContext;
        }
        // GET: api/Products
        [HttpGet]
        public IEnumerable<Product> Get(string sortPrice)
        {
            IQueryable<Product> products;

            switch (sortPrice)
            {
                case "desc":
                    products = productDbContext.Products.OrderByDescending(p => p.ProductName);
                    break;
                case "asc":
                    products = productDbContext.Products.OrderBy(p => p.ProductName);
                    break;
                default:
                    products = productDbContext.Products;
                    break;
            }
            return products;
        }

        // GET: api/Products/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            Product product = productDbContext.Products.SingleOrDefault(p => p.ProductId == id);

            if (product == null)
            {
                return NotFound("No Record Found...");
            }

            return Ok(product);
        }

        // POST: api/Products
        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            productDbContext.Products.Add(product);
            productDbContext.SaveChanges(true);

            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.ProductId)
            {
                return BadRequest();
            }

            try
            {

            }
            catch (Exception e)
            {
                productDbContext.Products.Update(product);
                productDbContext.SaveChanges(true);

                Console.WriteLine("erro: ", e);
                return NotFound("Erro... ");
            }


            return Ok("Product Updated");
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Product product = productDbContext.Products.SingleOrDefault(p => p.ProductId == id);

            if (product == null)
            {
                return NotFound("No Record Found...");
            }

            productDbContext.Products.Remove(product);
            productDbContext.SaveChanges(true);

            return Ok("Product Deleted..");
        }
    }
}
