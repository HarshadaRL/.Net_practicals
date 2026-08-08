using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagementAPI.Data;
using StudentManagementAPI.Models;

namespace StudentManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CoursesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/courses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetCourses()
        {
            return await _context.Courses
                .Include(c => c.Teacher)
                .ToListAsync();
        }

        // POST: api/courses
        [HttpPost]
        public async Task<ActionResult<Course>> PostCourse(
            Course course)
        {
            var teacherExists = await _context.Teachers
                .AnyAsync(t => t.TeacherId == course.TeacherId);

            if (!teacherExists)
                return BadRequest("Invalid TeacherId.");

            _context.Courses.Add(course);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetCourses),
                new { id = course.CourseId },
                course
            );
        }

        // PUT: api/courses/1
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourse(
            int id,
            Course course)
        {
            if (id != course.CourseId)
                return BadRequest();

            var teacherExists = await _context.Teachers
                .AnyAsync(t => t.TeacherId == course.TeacherId);

            if (!teacherExists)
                return BadRequest("Invalid TeacherId.");

            _context.Entry(course).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseExists(id))
                    return NotFound();

                throw;
            }

            return NoContent();
        }

        // DELETE: api/courses/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var course = await _context.Courses.FindAsync(id);

            if (course == null)
                return NotFound();

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CourseExists(int id)
        {
            return _context.Courses.Any(e => e.CourseId == id);
        }
    }
}