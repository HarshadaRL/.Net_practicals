using _21july.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _21july.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }

       //handle form submission
[HttpPost]
public ActionResult Register(Student student)
{
    if (ModelState.IsValid)
    {
        TempData["StudentName"] = student.name;
        return RedirectToAction("Schedule");
    }

    return View(student);
}

//course schedule page
public ActionResult Schedule()
{
    List<Course> course = new List<Course>()
    {
        new Course
        {
            courseName = "asp.net",
            sem = "sem 3",
            sessionTime = "9.30am - 12.00pm",
            days = "Mon - tue"
        },

        new Course
        {
            courseName = "java",
            sem = "sem 3",
            sessionTime = "9.30am - 11.00am",
            days = "tue - wed"
        },

        new Course
        {
            courseName = "html",
            sem = "sem 3",
            sessionTime = "9.30am - 11.00am",
            days = "Fri - sat"
        }
    };

    return View(course);
}

    }
}
