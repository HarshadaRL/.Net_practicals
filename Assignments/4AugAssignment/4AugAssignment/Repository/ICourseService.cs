using _4AugAssignment.Models;

namespace _4AugAssignment.Repository
{
    public interface ICourseService
    {
        List<Course> GetCourses();
        Course GetCourse(int id);
        void AddCourse(Course course);
        void UpdateCourse(Course course);
        void DeleteCourse(int id);
    }
}
