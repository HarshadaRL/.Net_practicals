using _28JulyAssignment.Models;

namespace _28JulyAssignment.Services
{
    public class CourseService : ICourseService 
    {
        private static List<Course> courses = new List<Course>()
        {
            new Course {Id= 1, Title="Dotnet" , Credits= 3, duration= 2 },
            new Course {Id= 2, Title="Data Science" , Credits= 4, duration= 3 },
            new Course {Id= 3, Title="CyberSecurity" , Credits= 3, duration= 2 },
            new Course {Id= 4, Title="Python" , Credits= 4, duration= 1 },
            new Course {Id= 5, Title="Machine Learning" , Credits= 5, duration= 3 },

        };

        public List<Course> GetAll()
        {
            return courses;
        }

        public Course RegisterCourse(Course course)
        {
             courses.Add(course);
            return course;
        }

        public Course UpdateCourse(int id, Course course)
        {
            var existing = courses.FirstOrDefault(p => p.Id == id);
            if (existing == null)
                return null;
            existing.Credits = course.Credits;
            existing.duration = course.duration;

            return existing;
        }

        public bool CancelCourse(int id)
        {
            var course = courses.FirstOrDefault(p => p.Id == id);
            if (course == null)
                return false;

            courses.Remove(course);
            return true;
        }
    }
}
