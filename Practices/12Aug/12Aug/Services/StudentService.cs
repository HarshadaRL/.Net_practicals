using _12Aug.Data;
using _12Aug.Models;
using _12Aug.Repository;

namespace _12Aug.Services
{
    public class StudentService : IStudentService
    {
        private readonly AppDbContext context;

        public StudentService(AppDbContext context)
        {
            this.context = context;
        }

        public List<Student> GetAllStudents()
        {
            return context.Students12.ToList();
        }

        public Student? GetStudentById(int id)
        {
            return context.Students12.FirstOrDefault(s => s.Id == id);
        }

        public Student AddStudent(Student student)
        {
            context.Students12.Add(student);
            context.SaveChanges();

            return student;
        }

        public Student? UpdateStudent(int id, Student student)
        {
            var existingStudent = context.Students12
                .FirstOrDefault(s => s.Id == id);

            if (existingStudent == null)
            {
                return null;
            }

            existingStudent.Name = student.Name;
            existingStudent.Age = student.Age;
            existingStudent.Mail = student.Mail;
            existingStudent.Phone = student.Phone;
            existingStudent.Course = student.Course;

            context.SaveChanges();

            return existingStudent;
        }

        public bool DeleteStudent(int id)
        {
            var student = context.Students12
                .FirstOrDefault(s => s.Id == id);

            if (student == null)
            {
                return false;
            }

            context.Students12.Remove(student);
            context.SaveChanges();

            return true;
        }
    }
}