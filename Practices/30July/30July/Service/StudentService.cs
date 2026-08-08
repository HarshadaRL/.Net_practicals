using _30July.Models;
using _30July.Service;

namespace _30July.Service
{
    public class StudentService : IStudentService
    {
        private static List<Student> students = new List<Student>
        {
            new Student{ Id=1, FirstName="Rani", LastName="Patil", Phone= 4444567, BatchId=1101},
             new Student{ Id=2, FirstName="Manisha", LastName="soundous", Phone= 4444567, BatchId=1101},
             new Student{ Id=3, FirstName="Poonam", LastName="Petekar", Phone= 4444567, BatchId=1101},
             new Student{ Id=4, FirstName="Rekha", LastName="Dhole", Phone= 4444567, BatchId=1101},
        }; 

        public List<Student> GetStudents()
        {
            return students;
        }

        public Student? GetStudentByID(int id)
        {
            return students.FirstOrDefault(x => x.Id == id);
        }
         public void AddStudent(Student student)
        {
            students.Add(student);
        }


    }
}
