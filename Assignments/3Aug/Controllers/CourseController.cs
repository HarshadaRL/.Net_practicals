using _03Aug2026_Ass.Models;
using _03Aug2026_Ass.Repository;
using Microsoft.AspNetCore.Mvc;

namespace _03Aug2026_Ass.Controllers
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
        public IActionResult Get()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var course = _service.GetCourse(id);

            if (course == null)
                return NotFound("Course not found");

            return Ok(course);
        }

        [HttpPost]
        public IActionResult Post(Course course)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _service.AddCourse(course);

            return Ok(course);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Course course)
        {
            if (id != course.CourseId)
                return BadRequest("Id mismatch");

            var existingCourse = _service.GetCourse(id);

            if (existingCourse == null)
                return NotFound("Course not found");

            _service.UpdateCourse(course);

            return Ok("Course Updated");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var course = _service.GetCourse(id);

            if (course == null)
                return NotFound("Course not found");

            _service.DeleteCourse(id);

            return Ok("Course Deleted");
        }
    }
}