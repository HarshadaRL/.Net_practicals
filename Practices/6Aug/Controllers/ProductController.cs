using _5_Aug.Models;
using _5_Aug.Repository;
using Microsoft.AspNetCore.Mvc;

namespace _5_Aug.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository repository;

        public ProductController(IProductRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var products = repository.GetAll();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var product = repository.GetProduct(id);

            if (product == null)
            {
                return NotFound(new { Message = "Product not found." });
            }

            return Ok(product);
        }

        [HttpPost]
        public IActionResult AddProduct([FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            repository.AddProduct(product);

            return Ok(new
            {
                Message = "Product added successfully."
            });
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] Product product)
        {
            if (id != product.Id)
            {
                return BadRequest(new
                {
                    Message = "Product ID mismatch."
                });
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingProduct = repository.GetProduct(id);

            if (existingProduct == null)
            {
                return NotFound(new
                {
                    Message = "Product not found."
                });
            }

            repository.UpdateProduct(product);

            return Ok(new
            {
                Message = "Product updated successfully."
            });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var existingProduct = repository.GetProduct(id);

            if (existingProduct == null)
            {
                return NotFound(new
                {
                    Message = "Product not found."
                });
            }

            repository.DeleteProduct(id);

            return Ok(new
            {
                Message = "Product deleted successfully."
            });
        }
    }
}