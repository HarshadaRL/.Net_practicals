using _3Aug.Models;
using _3Aug.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using _3Aug.Services;

namespace _3Aug.Controllers
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

        

       
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var course1 = _service.GetCourse(id);

            if (course1 == null)
            {
                return NotFound("Course not found");
            }

            _service.DeleteCourse(id);

            return Ok("Course deleted successfully");
        }
    }
}
