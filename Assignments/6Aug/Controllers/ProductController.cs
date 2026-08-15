using _06Aug_2026.Models;
using _06Aug_2026.Repository;
using Microsoft.AspNetCore.Mvc;

namespace _06Aug_2026.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService service;

        public ProductsController(IProductService service)
        {
            this.service = service;
        }

        //fetch all product from product table
        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(service.GetProducts());
        }

        //fetch product detail from product table based on PId
        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = service.GetProductById(id);

            if (product == null)
            {
                return NotFound("Product Not Found");
            }

            return Ok(product);
        }

        //add new product record in product table
        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                service.AddProduct(product);
                return Ok("Product Added Successfully");
            }

            return BadRequest(ModelState);
        }

        //modify product details from product table based on PId
        [HttpPut]
        public IActionResult UpdateProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                service.UpdateProduct(product);
                return Ok("Product Updated Successfully");
            }

            return BadRequest(ModelState);
        }

        //remove product record from product table based on PId
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = service.GetProductById(id);

            if (product == null)
            {
                return NotFound("Product Not Found");
            }

            service.DeleteProduct(id);
            return Ok("Product Deleted Successfully");
        }
    }
}
