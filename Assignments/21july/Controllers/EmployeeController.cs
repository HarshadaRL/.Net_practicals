using EmployeeManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Controllers
{
    public class EmployeeController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Employee emp)
        {
            if (ModelState.IsValid)
            {
                TempData["Department"] = emp.Department;

                return View("Success", emp);
            }

            return View(emp);
        }
    }
}