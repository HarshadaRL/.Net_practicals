using CollegeApi.Models;

namespace CollegeApi.Services
{
    public interface ICourseService
    {
        List<Course> GetAllCourses();
        Course? GetCourseById(int id);
        Course RegisterCourse(Course course);
        Course? UpdateCourseDuration(int id, int newDuration);
        bool CancelCourse(int id);
    }
}