
using _22july.Models;
using Microsoft.AspNetCore.Mvc;

namespace _22july.Controllers
{
    public class HomeController : Controller
    {
        // Display Form
        public IActionResult Index()
        {
            return View();
        }

        // Receive Form Data
        [HttpPost]
        public IActionResult Index(Product product)
        {
            if (ModelState.IsValid)
            {
                return Content(
                    $"Product: {product.Name}, Price: {product.Price}, Category: {product.Category}, Stock: {product.Stock}"
                );
            }

            return View(product);
        }
    }
}