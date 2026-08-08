using _3Aug.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using _3Aug.Services;
using _3Aug.Models;

namespace _3Aug.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _service;

        public StudentController(IStudentService service)
        {
            this ._service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var student = _service.GetStudent(id);

            if (student == null)
                return NotFound("Student not found");
            return Ok(student);
        }
        [HttpPost]
        public IActionResult Post(Student student)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            _service.AddStudent(student);
            return Ok(student);
        }

        [HttpPut("{Id}")]
        
        public IActionResult Put(int id, Student student)
        {
            if (id != student.Id)
            {
                return BadRequest("Id mismatch");
            }

            _service.UpdateStudent(student);

            return Ok(student);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var student = _service.GetStudent(id);

            if (student == null)
            {
                return NotFound("Student not found");
            }

            _service.DeleteStudent(id);

            return Ok("Student deleted successfully");
        }
    }
}
