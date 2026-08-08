using Microsoft.AspNetCore.Mvc;
using CollegeApi.Models;
using CollegeApi.Services;

namespace CollegeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Course>> GetAll()
        {
            return Ok(_courseService.GetAllCourses());
        }

        
        [HttpGet("{id}")]
        public ActionResult<Course> GetById(int id)
        {
            var course = _courseService.GetCourseById(id);
            if (course == null)
            {
                return NotFound($"Course with Id {id} not found.");
            }
            return Ok(course);
        }

        
        [HttpPost]
        public ActionResult<Course> RegisterCourse([FromBody] Course course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdCourse = _courseService.RegisterCourse(course);
            return CreatedAtAction(nameof(GetById), new { id = createdCourse.Id }, createdCourse);
        }

       
        [HttpPatch("{id}/duration")]
        public ActionResult<Course> UpdateDuration(int id, [FromBody] int newDuration)
        {
            if (newDuration <= 0)
            {
                return BadRequest("Duration must be a positive integer.");
            }

            var updatedCourse = _courseService.UpdateCourseDuration(id, newDuration);
            if (updatedCourse == null)
            {
                return NotFound($"Course with Id {id} not found.");
            }

            return Ok(updatedCourse);
        }

        [HttpDelete("{id}")]
        public IActionResult CancelCourse(int id)
        {
            var isCancelled = _courseService.CancelCourse(id);
            if (!isCancelled)
            {
                return NotFound($"Course with Id {id} not found.");
            }

            return NoContent(); 
        }
    }
}