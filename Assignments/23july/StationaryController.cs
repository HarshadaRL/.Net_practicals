
    using _23_July.Models;
using Microsoft.AspNetCore.Mvc;
namespace _23_July.Controllers
{
    public class StationaryController:Controller
    {
    public IActionResult Stationary()
    {
        return View();
    }
    [HttpPost]
    public ActionResult Stationary(Stationary st)
    {
        if (ModelState.IsValid)
        {
            //normally save to db
            return Content($"Product: {st.Name}, " +
                $"Price: {st.Price}, " +
                $"Brand: {st.Brand}, " +
                $"Stock: {st.stock}");
        }

        return View(st);


    }

}
}
