using _3Aug.Models;
using Microsoft.AspNetCore.Authentication.OAuth.Claims;
namespace _3Aug.Repository
{
    public interface ICourseService
    {
        List<Course> GetAll();
        void AddCourse(Course course);
        Course GetCourse(int id);
        void DeleteCourse(int id);

    }
}
