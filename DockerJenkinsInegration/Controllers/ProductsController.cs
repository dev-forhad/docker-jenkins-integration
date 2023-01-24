using DockerJenkinsInegration.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DockerJenkinsInegration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        // In-memory list of products for demonstration purposes
        private static List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "Product 1", Quantity = 10, Price = 9.99m, Description = "This is the first product" },
            new Product { Id = 2, Name = "Product 2", Quantity = 20, Price = 19.99m, Description = "This is the second product" },
            new Product { Id = 3, Name = "Product 3", Quantity = 30, Price = 29.99m, Description = "This is the third product" }
        };

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return products;
        }

        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return products.FirstOrDefault(p => p.Id == id);
        }

        [HttpPost]
        public void Post([FromBody] Product product)
        {
            products.Add(product);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Product product)
        {
            var existingProduct = products.FirstOrDefault(p => p.Id == id);
            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Quantity = product.Quantity;
                existingProduct.Price = product.Price;
                existingProduct.Description = product.Description;
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            products.RemoveAll(p => p.Id == id);
        }
    }
}
