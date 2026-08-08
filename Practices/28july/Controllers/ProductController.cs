
using _28july.Models;
using _28july.Services;
using Microsoft.AspNetCore.Mvc;

namespace _28Jul.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/Product
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAll()
        {
            var products = _productService.GetAll();
            return Ok(products);
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        public ActionResult<Product> GetById(int id)
        {
            var product = _productService.GetById(id);
            if (product == null)
            {
                return NotFound($"Product with Id = {id} not found.");
            }

            return Ok(product);
        }

        // POST: api/Product
        [HttpPost]
        public ActionResult<Product> AddProduct([FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdProduct = _productService.AddProduct(product);
            return CreatedAtAction(nameof(GetById), new { id = createdProduct.Id }, createdProduct);
        }

        // PUT: api/Product/5
        [HttpPut("{id}")]
        public ActionResult<Product> UpdateProduct(int id, [FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedProduct = _productService.UpdateProduct(id, product);
            if (updatedProduct == null)
            {
                return NotFound($"Product with Id = {id} not found.");
            }

            return Ok(updatedProduct);
        }

        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var isDeleted = _productService.DeleteProduct(id);
            if (!isDeleted)
            {
                return NotFound($"Product with Id = {id} not found.");
            }

            return NoContent(); // 204 No Content
        }
    }
}