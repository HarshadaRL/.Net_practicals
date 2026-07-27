using _27Jul.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace _27Jul.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        static List<Employee> employees = new List<Employee>()
        {
            new Employee(){ Id =101, Name="Jack", LastName="B", Dept="IT", PhoneNum=126567, Location="Mumbai", Profile="Manager"},
            new Employee(){ Id =102, Name="John", LastName="h", Dept="CSE", PhoneNum=126587,  Location="Pune", Profile="CEO"}

        };

        [HttpGet]

        public IActionResult getEmployee()
        {
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public IActionResult getEmployeeId(int id)
        {
            var employee = employees.FirstOrDefault(x => x.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);

        }

        [HttpPost]

        public IActionResult AddEmployee(Employee employee)
        {
            employees.Add(employee);

            return Ok(employee);
        }

        //edit employee record
        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id, Employee employee)
        {
            var employee1 = employees.FirstOrDefault(x => x.Id == id);
            if (employee1 == null)
            {
                return NotFound();
            }

            employee1.LastName = employee.LastName;
            return Ok(employee);
        }

        [HttpGet("Dept/{dept}")]
        public IActionResult GetEmployeeByDept(string dept)
        {
            var result = employees.Where(s => s.Dept.Equals(dept, StringComparison.OrdinalIgnoreCase)).ToList();

                if(!result.Any())
            {
                return NotFound("Not employee found under this dept");
            }
            return Ok(result);
        }

        // Get employees by location
        [HttpGet("Location/{location}")]
        public IActionResult GetEmployeeByLocation(string location)
        {
            var result = employees.Where(e => e.Location.Equals(location, StringComparison.OrdinalIgnoreCase)).ToList();
            if (!result.Any())
            {
                return NotFound("No employees found at this location.");
            }
            return Ok(result);
        }

        // Get employees by profile
        [HttpGet("Profile/{profile}")]
        public IActionResult GetEmployeeByProfile(string profile)
        {
            var result = employees.Where(e => e.Profile.Equals(profile, StringComparison.OrdinalIgnoreCase)).ToList();
            if (!result.Any())
            {
                return NotFound("No employees found with this profile.");
            }
            return Ok(result);
        }

    }
}
