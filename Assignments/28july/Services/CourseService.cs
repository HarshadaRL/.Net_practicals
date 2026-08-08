using CollegeApi.Models;

namespace CollegeApi.Services
{
    public class CourseService : ICourseService
    {
       
        private readonly List<Course> _courses = new()
        {
            new Course { Id = 1, Title = "Computer Science 101", Credits = 3, Duration = 12 },
            new Course { Id = 2, Title = "Data Structures & Algorithms", Credits = 4, Duration = 16 }
        };

        public List<Course> GetAllCourses()
        {
            return _courses;
        }

        public Course? GetCourseById(int id)
        {
            return _courses.FirstOrDefault(c => c.Id == id);
        }

        public Course RegisterCourse(Course course)
        {
         
            course.Id = _courses.Any() ? _courses.Max(c => c.Id) + 1 : 1;
            _courses.Add(course);
            return course;
        }

        public Course? UpdateCourseDuration(int id, int newDuration)
        {
            var course = _courses.FirstOrDefault(c => c.Id == id);
            if (course == null) return null;

            course.Duration = newDuration;
            return course;
        }

        public bool CancelCourse(int id)
        {
            var course = _courses.FirstOrDefault(c => c.Id == id);
            if (course == null) return false;

            _courses.Remove(course);
            return true;
        }
    }
}