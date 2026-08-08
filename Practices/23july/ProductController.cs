//using _23_July.Models;
//using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using _23_July.Models;
using Microsoft.AspNetCore.Mvc;
namespace _23_July.Controllers
{
    public class ProductController:Controller
    {
        public IActionResult Index()
        {
            // Check login
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("User")))
            {
                return RedirectToAction("Login", "Home");
            }

            List<Product> products = new List<Product>()
                    {
                        new Product { Id = 1, Name = "Laptop",  Price = 78000 },
                        new Product { Id = 2, Name = "Phone",   Price = 80000 },
                        new Product { Id = 3, Name = "Charger", Price = 700 },
                        new Product { Id = 4, Name = "Earphone", Price = 8000 }
                    };

            return View(products);
        }

    }
}
