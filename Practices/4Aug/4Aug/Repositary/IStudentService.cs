using _4_Aug.Models;

namespace _4_Aug.Repository
{
    public interface IStudentService
    {
        List<Student> GetAll();

        Student? GetStudent(int id);

        void AddStudent(Student student);

        void UpdateStudent(Student student);

        void DeleteStudent(int id);
    }
}