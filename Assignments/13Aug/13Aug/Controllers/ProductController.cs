using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _12Aug.Data;
using _12Aug.Models;

namespace _12Aug.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext context;

        public ProductController(AppDbContext context)
        {
            this.context = context;
        }

        // ==========================================
        // CUSTOMER
        // View all products
        // ==========================================

        // GET: api/Product
        [HttpGet]
        [Authorize(Roles = "Customer,Admin")]
        public async Task<IActionResult> GetProducts()
        {
            var products = await context.Products.ToListAsync();

            return Ok(products);
        }

        // ==========================================
        // CUSTOMER + ADMIN
        // View single product
        // ==========================================

        // GET: api/Product/1
        [HttpGet("{id}")]
        [Authorize(Roles = "Customer,Admin")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await context.Products
                .FindAsync(id);

            if (product == null)
            {
                return NotFound("Product not found");
            }

            return Ok(product);
        }

        // ==========================================
        // ADMIN ONLY
        // Add product
        // ==========================================

        // POST: api/Product
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddProduct(
            Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            context.Products.Add(product);

            await context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetProduct),
                new { id = product.Id },
                product);
        }

        // ==========================================
        // ADMIN ONLY
        // Update product
        // ==========================================

        // PUT: api/Product/1
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateProduct(
            int id,
            Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingProduct = await context.Products
                .FindAsync(id);

            if (existingProduct == null)
            {
                return NotFound("Product not found");
            }

            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Price = product.Price;
            existingProduct.Stock = product.Stock;

            await context.SaveChangesAsync();

            return Ok(existingProduct);
        }

        // ==========================================
        // ADMIN ONLY
        // Delete product
        // ==========================================

        // DELETE: api/Product/1
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await context.Products
                .FindAsync(id);

            if (product == null)
            {
                return NotFound("Product not found");
            }

            context.Products.Remove(product);

            await context.SaveChangesAsync();

            return Ok("Product deleted successfully");
        }
    }
}