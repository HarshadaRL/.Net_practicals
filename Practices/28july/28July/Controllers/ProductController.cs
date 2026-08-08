using _28July.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using _28July.Models;

namespace _28July.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]

        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]

        public IActionResult GetProductById(int id)
        {
            var product = _service.GetById(id);
            if (product == null)
            {

                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            var created = _service.AddProduct(product);
            return Ok(created);
        }

        [HttpPut("{id}")]

        public IActionResult Update(int id , Product product)
        {
            var updated= _service.UpdateProduct(id, product);
            if(updated==null)
                return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            bool deleted = _service.DeleteProduct(id);

            if(!deleted)
                return NotFound();
            return NoContent();
        }
    }
}
