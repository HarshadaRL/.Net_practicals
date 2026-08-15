using _03Aug2026_Ass.Models;

namespace _03Aug2026_Ass.Repository
{
    public class StudentService : IStudentService
    {
        private static List<Student> students = new List<Student>()
        {
            new Student
            {
                Id = 1,
                Name = "Divyansh",
                Age = 20,
                Course = "C#",
                Email = "divyansh@gmail.com"
            },

            new Student
            {
                Id = 2,
                Name = "Mayur",
                Age = 21,
                Course = "ASP.NET Core",
                Email = "mayur@gmail.com"
            },

            new Student
            {
                Id = 3,
                Name = "Devang",
                Age = 22,
                Course = "Java",
                Email = "devang@gmail.com"
            }
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
            return students.FirstOrDefault(s => s.Id == id);
        }

        public void UpdateStudent(Student student)
        {
            var existing = GetStudent(student.Id);

            if (existing == null)
                throw new Exception("Student not found");

            existing.Name = student.Name;
            existing.Age = student.Age;
            existing.Course = student.Course;
            existing.Email = student.Email;
        }
    }
}