using _29July.Models;
using _29July.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace _29July.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _service;

         public EmployeeController(IEmployeeService service)
        {
          _service = service;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.getEmployees());
        }

        [HttpGet("deptid/{deptid}")]
        public IActionResult GetById(int deptid)
        {
            var employee = _service.getEmployee(deptid);
            if(employee == null) 
                return NotFound("Employees with id not found");
            return Ok(employee);
        }

        [HttpGet("name/{name}")]
        public IActionResult GetByName(string name)
        {
            var employee1 = _service.getEmployeeName(name);
            if (employee1 == null)
                return NotFound("Employee with name not found");
            return Ok(employee1);
        }

        [HttpPost]
        public IActionResult Post(Employee employee)
        {
            var res = _service.addEmployee(employee);
            return Ok(res);
        }

    }
}
