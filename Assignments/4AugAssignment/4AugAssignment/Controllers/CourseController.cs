using _4AugAssignment.Models;
using _4AugAssignment.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _4AugAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _service;

        public CourseController(ICourseService service)
        {
            this._service = service;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.GetCourses());
        }

        [HttpGet("{id}")]
        public IActionResult GetId(int id)
        {
            var course = _service.GetCourse(id);
            if (course== null)
                return NotFound("Course not found");

            return Ok(course);

        }

        [HttpPost]
        public IActionResult Add(Course course)
        {
            _service.AddCourse(course);
            return Ok(course);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Course course)
        {
            if (id != course.Id)
                return BadRequest();

            var existing = _service.GetCourse(id);

            if (existing == null)
                return NotFound();

            _service.UpdateCourse(course);
            return Ok(course);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var batch = _service.GetCourse(id);

            if (batch == null)
                return NotFound();
            _service.DeleteCourse(id);

            return Ok(batch);
        }
    }
}
