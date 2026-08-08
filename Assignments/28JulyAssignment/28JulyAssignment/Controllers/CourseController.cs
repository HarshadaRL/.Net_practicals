using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using _28JulyAssignment.Models;
using _28JulyAssignment.Services;



namespace _28JulyAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _service;

        public CourseController(ICourseService service)
        {
            _service = service;
        }

        [HttpGet]

        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }
        [HttpPost]
        public IActionResult Create(Course course)
        {
            var created = _service.RegisterCourse(course);
            return Ok(created);
        }

        [HttpPut("{id}")]

        public IActionResult Update(int id, Course course)
        {
            var updated = _service.UpdateCourse(id, course);
            if (updated == null)
                return NotFound();
            return Ok(updated);
        }
        [HttpDelete("{id}")]
        public IActionResult CancelCourse(int id)
        {
            bool deleted = _service.CancelCourse(id);

            if (!deleted)
                return NotFound();
            return NoContent();
        }
    }
}
