using _30JulyAssignment.Models;
using _30JulyAssignment.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _30JulyAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        // GET: api/department
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_departmentService.GetDepartments());
        }

        // GET: api/department/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var department = _departmentService.GetDeptByDeptId(id);

            if (department == null)
                return NotFound("Department not found.");

            return Ok(department);
        }

        // POST: api/department
        [HttpPost]
        public IActionResult Create(Department department)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = _departmentService.AddDepartment(department);

            if (result.Contains("exists"))
                return BadRequest(result);

            return Ok(result);
        }

        // PUT: api/department/1
        [HttpPut("{id}")]
        public IActionResult Update(int id, Department department)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = _departmentService.UpdateDept(id, department);

            if (result == "Department not found.")
                return NotFound(result);

            if (result.Contains("exists"))
                return BadRequest(result);

            return Ok(result);
        }

        // DELETE: api/department/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _departmentService.DeleteDept(id);

            if (result == "Department not found.")
                return NotFound(result);

            if (result.Contains("cannot"))
                return BadRequest(result);

            return Ok(result);
        }
        }
}
