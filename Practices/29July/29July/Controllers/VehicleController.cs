using _29July.Models;
using _29July.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _29July.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {

        private readonly IVehicleService _service;


        public VehicleController(IVehicleService service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.GetVehicles());
        }

        [HttpGet("id/{id}")]
        public IActionResult GetById(int id)
        {
            var vehicle = _service.GetVehicleById(id);
            if (vehicle == null)
                return NotFound("Vehicle with id not found");
            return Ok(vehicle);
        }

        [HttpGet("name/{name}")]
        public IActionResult GetByName(string name)
        {
            var vehicle1 = _service.GetVehicleByName(name);
            if (vehicle1 == null)
                return NotFound("Vehicle with name not found");
            return Ok(vehicle1);
        }

        [HttpGet("type/{type}")]
        public IActionResult GetByType(string type)
        {
            var vehicle2 = _service.GetVehicleByType(type);
            if (vehicle2 == null)
                return NotFound("Vehicle with type not found");
            return Ok(vehicle2);
        }

        [HttpPost]
        public IActionResult Post(Vehicle vehicle)
        {
            var res = _service.addVehicle(vehicle);
            return Ok(res);
        }

    }
}

   

