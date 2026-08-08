
using _28JulyAssignment.Models;

namespace _28JulyAssignment.Services
{
    public interface ICourseService
    {
        List<Course> GetAll();

        Course RegisterCourse(Course course);

        Course? UpdateCourse(int id ,Course course);

        bool CancelCourse(int id);
    }
}
