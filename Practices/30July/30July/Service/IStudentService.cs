using _30July.Models;
using _30July.Service;

namespace _30July.Service
{
    public interface IStudentService
    {
        List<Student> GetStudents();
        Student? GetStudentByID(int id);
        void AddStudent(Student student);
    }
}
