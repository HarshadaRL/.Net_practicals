using _7_Aug.Models;
using _7_Aug.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _7_Aug.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService service;

        public ProductController(IProductService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(service.GetProducts());
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var product = service.GetProductById(id);

            if (product == null)
                return NotFound("Product is not available");

            return Ok(product);
        }

        [HttpPost]
        public IActionResult AddP(Product product)
        {
            service.AddProduct(product);
            return Ok(product);
        }
    }
}
