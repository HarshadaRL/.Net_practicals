using Automobile.Models;
using Automobile.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Automobile.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutomobileController : ControllerBase
    {
        private readonly IAutomobileService automobileService;

        public AutomobileController(
            IAutomobileService automobileService)
        {
            this.automobileService = automobileService;
        }

        [HttpGet]
        public ActionResult<List<Vehicle>> GetVehicles()
        {
            return Ok(automobileService.GetVehicles());
        }

        [HttpGet("{id}")]
        public ActionResult<Vehicle> GetVehicleById(int id)
        {
            var vehicle = automobileService.GetVehicleById(id);

            if (vehicle == null)
                return NotFound("Vehicle not found");

            return Ok(vehicle);
        }

        [HttpPost]
        public ActionResult<Vehicle> CreateVehicle(Vehicle vehicle)
        {
            try
            {
                var result = automobileService.CreateVehicle(vehicle);

                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}