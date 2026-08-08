
using _3Aug.Models;
namespace _3Aug.Repository
{
    public interface IStudentService
    {
        List<Student> GetAll();
        Student GetStudent(int id);
        void AddStudent(Student student);
        void UpdateStudent(Student student);
        void DeleteStudent(int id);
    }
}
