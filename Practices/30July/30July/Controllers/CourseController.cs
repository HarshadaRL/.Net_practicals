using _30July.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _30July.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        [HttpGet]
        public IActionResult Getcourses()
        {
            var courses = new List<Course>
            {
                new Course {Id= 101,Name="C#"},
                new Course {Id= 102, Name="F#"},


            };

            return Ok(courses);
        }

        [HttpGet("{id}")]
        public IActionResult Getcourses(int id) { return Ok(new Course { Id= id }); }

        
        

        
    }
}
