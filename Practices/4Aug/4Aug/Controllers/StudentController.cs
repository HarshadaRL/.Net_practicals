using _4_Aug.Models;
using _4_Aug.Repository;
using Microsoft.AspNetCore.Mvc;

namespace _4_Aug.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var students = _studentService.GetAll();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            var student = _studentService.GetStudent(id);

            if (student == null)
            {
                return NotFound("Student not found.");
            }

            return Ok(student);
        }

        [HttpPost]
        public IActionResult AddStudent(Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _studentService.AddStudent(student);

            return Ok(new
            {
                Message = "Student added successfully."
            });
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, Student student)
        {
            if (id != student.Id)
            {
                return BadRequest("Student Id mismatch.");
            }

            var existingStudent = _studentService.GetStudent(id);

            if (existingStudent == null)
            {
                return NotFound("Student not found.");
            }

            _studentService.UpdateStudent(student);

            return Ok(new
            {
                Message = "Student updated successfully."
            });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var student = _studentService.GetStudent(id);

            if (student == null)
            {
                return NotFound("Student not found.");
            }

            _studentService.DeleteStudent(id);

            return Ok(new
            {
                Message = "Student deleted successfully."
            });
        }
    }
}