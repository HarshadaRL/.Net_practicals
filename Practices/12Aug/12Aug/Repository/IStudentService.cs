using _12Aug.Models;

namespace _12Aug.Repository
{
    public interface IStudentService
    {
        List<Student> GetAllStudents();

        Student? GetStudentById(int id);

        Student AddStudent(Student student);

        Student? UpdateStudent(int id, Student student);

        bool DeleteStudent(int id);
    }
} 