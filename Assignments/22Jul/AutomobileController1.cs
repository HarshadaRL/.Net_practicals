using _22Jul.Models;
using Microsoft.AspNetCore.Mvc;

namespace _22Jul.Controllers
{
    public class AutomobileController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Automobile automobile)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Message = "Automobile Registered Successfully";
                ViewBag.VehicleName = automobile.VehicleName;
                ViewBag.Brand = automobile.Brand;

                return View("Success", automobile);
            }

            return View(automobile);
        }
    }
}
