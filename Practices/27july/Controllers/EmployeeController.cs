using Microsoft.AspNetCore.Mvc;
using _27july.Models;

namespace _27july.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        static List<Employee> employees = new List<Employee>()
        {
            new Employee() { Id = 101, Name = "Mamta", LastName = "B", Dept = "IT", PhoneNum = 789654, Loc = "Delhi", Prof = "Manager" },
            new Employee() { Id = 102, Name = "John", LastName = "Amit", Dept = "IT", PhoneNum = 890654, Loc = "Delhi", Prof = "Manager" },
            new Employee() { Id = 103, Name = "Bob", LastName = "Alice", Dept = "Admin", PhoneNum = 700054, Loc = "Delhi", Prof = "Manager" }
        };

        // Get all employee list
        [HttpGet]
        public IActionResult getEmployee()
        {
            return Ok(employees);
        }

        // Get employee by id
        [HttpGet("{id}")]
        public IActionResult getEmployeeById(int id)
        {
            var employee = employees.FirstOrDefault(x => x.Id == id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }



        // Add new employee
        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            employees.Add(employee);
            return Ok(employee);
        }

        // Edit employee
        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id, Employee employee)
        {
            var employee1 = employees.FirstOrDefault(x => x.Id == id);

            if (employee1 == null)
            {
                return NotFound();
            }

            employee1.LastName = employee.LastName;

            return Ok(employee1);
        }

        [HttpGet("Dept/{dept}")]
        public IActionResult GetEmployeeByDept(string dept)
        {
            var result = employees.Where(s =>
                s.Dept.Equals(dept, StringComparison.OrdinalIgnoreCase));

            if (!result.Any())
            {
                return NotFound("Not employee found under this dept");
            }

            return Ok(result);
        }
        // Get employee by id
        [HttpGet("{loc}")]
        public IActionResult getEmployeeByLoc(string loc)
        {
            var employee = employees.FirstOrDefault(x => x.Loc == loc);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        // Get employee by id
        [HttpGet("Profile{prof}")]
        public IActionResult getEmployeeByprof(string prof)
        {
            var employee = employees.FirstOrDefault(x => x.Prof == prof);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }
    }
}