using _3Aug.Models;
using _3Aug.Repository;
using System.Xml.Linq;

namespace _3Aug.Services
{
    public class CourseService: ICourseService
    {
        private static List<Course> courses = new List<Course>()
        {
            new Course() {Id=1001, Name="Dotnet" },
            new Course() {Id=1002, Name="Python" },
            new Course() {Id=1003, Name="Java" },
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
            return courses.FirstOrDefault(x => x.Id == id);
        }
    }

       
}
