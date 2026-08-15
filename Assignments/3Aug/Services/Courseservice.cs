using _03Aug2026_Ass.Models;

namespace _03Aug2026_Ass.Repository
{
    public class CourseService : ICourseService
    {
        private static List<Course> courses = new List<Course>()
        {
            new Course
            {
                CourseId = 1,
                StudentName = "Divyansh",
                CourseName = "C#"
            },

            new Course
            {
                CourseId = 2,
                StudentName = "Mayur",
                CourseName = "ASP.NET Core"
            }
        };

        public void AddCourse(Course course)
        {
            courses.Add(course);
        }

        public void DeleteCourse(int id)
        {
            var existing = GetCourse(id);

            if (existing == null)
                throw new Exception("Course not found");

            courses.Remove(existing);
        }

        public List<Course> GetAll()
        {
            return courses;
        }

        public Course? GetCourse(int id)
        {
            return courses.FirstOrDefault(c => c.CourseId == id);
        }

        public void UpdateCourse(Course course)
        {
            var existing = GetCourse(course.CourseId);

            if (existing == null)
                throw new Exception("Course not found");

            existing.StudentName = course.StudentName;
            existing.CourseName = course.CourseName;
        }
    }
}