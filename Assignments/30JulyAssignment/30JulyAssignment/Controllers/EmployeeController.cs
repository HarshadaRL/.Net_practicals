using _30JulyAssignment.Models;
using _30JulyAssignment.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _30JulyAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // GET: api/employee
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_employeeService.GetAllEmployees());
        }

        // GET: api/employee/101
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var employee = _employeeService.GetEmployeeById(id);

            if (employee == null)
                return NotFound("Employee not found.");

            return Ok(employee);
        }

        // POST: api/employee
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = _employeeService.AddEmployee(employee);

            if (result.Contains("exists") ||
                result.Contains("inactive") ||
                result.Contains("not found"))
                return BadRequest(result);

            return Ok(result);
        }

        // PUT: api/employee/101
        [HttpPut("{id}")]
        public IActionResult Update(int id, Employee employee)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = _employeeService.UpdateEmployee(id, employee);

            if (result == "Employee not found.")
                return NotFound(result);

            if (result.Contains("exists") ||
                result.Contains("inactive") ||
                result.Contains("not found"))
                return BadRequest(result);

            return Ok(result);
        }

        // DELETE: api/employee/101
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _employeeService.DeleteEmployee(id);

            if (result == "Employee not found.")
                return NotFound(result);

            return Ok(result);
        }

        // GET: api/employee/search
        [HttpGet("search")]
        public IActionResult SearchEmployee(string? FirstName, string? Email, int? DepartmentId, string? status, int? employeeId)
           
        {
            var employees = _employeeService.SearchEmployee( FirstName,  Email,  DepartmentId,  status,  employeeId);
                

            return Ok(employees);
        }

        // GET: api/employee/department/1
        [HttpGet("department/{departmentId}")]
        public IActionResult GetEmployeesByDepartment(int departmentId)
        {
            var employees = _employeeService.GetEmployeeByDeptId(departmentId);

            return Ok(employees);
        }
    }
}
