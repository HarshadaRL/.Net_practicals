using EmployeeManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Controllers
{
    public class DepartmentController : Controller
    {
        public IActionResult Details()
        {
            if (TempData["Department"] == null)
            {
                return RedirectToAction("Register", "Employee");
            }

            Department department = new Department
            {
                DepartmentName = TempData["Department"].ToString(),
                DepartmentHead = "Mr. Rahul Sharma",
                HeadContactNumber = "9876543210",
                HeadEmail = "rahul@company.com"
            };

            return View(department);
        }
    }
}