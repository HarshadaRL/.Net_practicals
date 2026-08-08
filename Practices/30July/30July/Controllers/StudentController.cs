using _30July.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using _30July.Models;

namespace _30July.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _service;

        public StudentController(IStudentService service)
        {
            _service = service;
        }

        [HttpGet]

        public IActionResult GetStudents()
        {
            return Ok(_service.GetStudents());

        }

        [HttpGet("{id}")]

        public IActionResult GetStudent(int id)
        {
            var student = _service.GetStudentByID(id);
            if (student == null)
                return NotFound("Student does not exist");
            return Ok(student);
        }

        [HttpPost]
        
        public IActionResult AddStudent(Student student)
        {
            _service.AddStudent(student);
            return Ok("Student Added");
        }


    }
}
