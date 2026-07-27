using Microsoft.AspNetCore.Mvc;
using _22Jul.Models;

namespace AutomobileManagementSystem.Controllers
{
    public class ManufacturerController : Controller
    {
        public IActionResult Manufacturer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Manufacturer(Manufacturer manufacturer)
        {
            if (ModelState.IsValid)
            {
                return View("ManufacturerDetails", manufacturer);
            }

            return View(manufacturer);
        }
    }
}
