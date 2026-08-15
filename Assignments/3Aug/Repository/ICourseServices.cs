using _03Aug2026_Ass.Models;

namespace _03Aug2026_Ass.Repository
{
    public interface ICourseService
    {
        List<Course> GetAll();

        Course? GetCourse(int id);

        void AddCourse(Course course);

        void UpdateCourse(Course course);

        void DeleteCourse(int id);
    }
}