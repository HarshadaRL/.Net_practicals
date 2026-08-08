using _3Aug.Models;
using _3Aug.Repository;
namespace _3Aug.Services
{
    public class StudentService: IStudentService
    {
        private static List<Student> students = new List<Student>()
        {
            new Student{Id=1, Name="Jaohn", Age=20, Course="Dotnet",Email="J@gmail.com" },
            new Student{Id=2, Name="Rekha", Age=20, Course="Java",Email="J@gmail.com" },
            new Student{Id=3, Name="Steve", Age=20, Course="Java",Email="J@gmail.com" },
            new Student{Id=4, Name="Bob", Age=20, Course="Dotnet",Email="J@gmail.com" },
        };

        public void AddStudent(Student student)
        {
            students.Add(student);
        }

        public void DeleteStudent(int id)
        {
            var existing = GetStudent(id);
            if (existing == null)
                throw new Exception("Student not found");
            students.Remove(existing);
        }

        public List<Student> GetAll()
        {
            return students;
        }
        public Student? GetStudent(int id)
        {
            return students.FirstOrDefault(x => x.Id == id);
        }

        public void UpdateStudent(Student student)
        {
            var existing = GetStudent(student.Id);
            if (existing == null)
                throw new Exception("Student not found");
            existing.Age= student.Age;

        }


    }
}
