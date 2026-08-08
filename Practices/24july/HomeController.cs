using _24_July.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using System.Diagnostics;

namespace _24_July.Controllers
{
    public class HomeController : Controller
    {
       



        public IActionResult Index()
        {
            return View();
        }

        // Post : login
        [HttpPost]
        public ActionResult Index(Student student)
        {
            if (ModelState.IsValid)
            {
                if (student.Username == "admin" && student.Password == "123456")
                {
                    HttpContext.Session.SetString("User", student.Username);

                    return RedirectToAction("Dashboard");
                }

                ViewBag.Error = "Invalid username or password";
            }

            return View(student);
        }
        // GET : Dashboard
        
        public IActionResult Dashboard()
        {
            if (HttpContext.Session.GetString("User") == null)
            {
                ViewBag.User = HttpContext.Session.GetString("User");
                return RedirectToAction("Index");
            }


            return View();
        }
        [HttpPost]
        public IActionResult Dashboard(Register register)
        {
            //if (HttpContext.Session.GetString("User") == null)
            //{

            //    return RedirectToAction("Index");
            //}



            if (ModelState.IsValid)
            {
                ViewBag.Message = "Student " + register.name + "registered successfully in college";


            }

            return View(register);
        }


            
        
       


        // Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

    }
}



