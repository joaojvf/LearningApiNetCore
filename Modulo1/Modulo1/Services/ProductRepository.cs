using Modulo1.Data;
using Modulo1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Modulo1.Services
{
    public class ProductRepository : IProduct
    {
        private ProductDbContext productsDbContext;

        public ProductRepository(ProductDbContext _productDbContext)
        {
            productsDbContext = _productDbContext;
        }

        public IEnumerable<Product> GetProducts()
        {
            return productsDbContext.Products;
        }
        public Product GetProduct(int id)
        {
            var product = productsDbContext.Products.SingleOrDefault(m => m.ProductId == id);
            return product;
        }
        public void AddProduct(Product product)
        {
            productsDbContext.Products.Add(product);
            productsDbContext.SaveChanges(true);
        }
        public void UpdateProduct(Product product)
        {
            productsDbContext.Products.Update(product);
            productsDbContext.SaveChanges(true);
        }
        public void DeleteProduct(int id)
        {
            var product = productsDbContext.Products.Find(id);
            productsDbContext.Products.Remove(product);
            productsDbContext.SaveChanges(true);
        }
    }
}
