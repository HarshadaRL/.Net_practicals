using _23_July.Models;
using Microsoft.AspNetCore.Mvc;

namespace _23_July.Controllers
{
    public class HomeController : Controller
    {
        // GET : Login
        public IActionResult Login()
        {
            return View();
        }

        // POST : Login
        [HttpPost]
        public IActionResult Login(string username, string Password)
        {
            // Simple hardcoded login
            if (username == "admin" && Password =="12345")
            {
                HttpContext.Session.SetString("User", username);
                return RedirectToAction("Index", "Product");
            }

            ViewBag.Message = "Invalid username or password";

            return View();
        }
      
        }
    }

