using _16july.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _16july.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            List<Student> students = new List<Student>()
            {
                new Student { id = 101, name = "Gitesh", age = 18, course = "Java" ,gender="M", fees=5000,quali="HSC"},
                new Student { id = 102, name = "Om", age = 19, course = "C" ,gender="M", fees=5500,quali="HSC"},
                new Student { id = 103, name = "Sahil", age = 18, course = "C++" ,gender="M", fees=40000,quali="HSC"},
                new Student { id = 104, name = "Ashay", age = 17, course = "C#" ,gender="M", fees=3000,quali="HSC"}
            };
            return View(students);

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
