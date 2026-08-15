using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using _12Aug.Models;
using _12Aug.Repository;

namespace _12Aug.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService studentService;

        public StudentController(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        // GET ALL
        [HttpGet]
        [Authorize]
        public IActionResult GetAllStudents()
        {
            var students = studentService.GetAllStudents();

            return Ok(students);
        }

        // GET BY ID
        [HttpGet("{id}")]
        [Authorize]
        public IActionResult GetStudentById(int id)
        {
            var student = studentService.GetStudentById(id);

            if (student == null)
            {
                return NotFound("Student not found");
            }

            return Ok(student);
        }

        // POST
        [HttpPost]
        [Authorize]
        public IActionResult AddStudent(Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = studentService.AddStudent(student);

            return Ok(result);
        }

        // PUT
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult UpdateStudent(
            int id,
            Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = studentService.UpdateStudent(id, student);

            if (result == null)
            {
                return NotFound("Student not found");
            }

            return Ok(result);
        }

        // DELETE
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteStudent(int id)
        {
            var result = studentService.DeleteStudent(id);

            if (!result)
            {
                return NotFound("Student not found");
            }

            return Ok("Student deleted successfully");
        }
    }
}