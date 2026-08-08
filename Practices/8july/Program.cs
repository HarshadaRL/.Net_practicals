using System;

class Program
{
    public static void Main(string[] args)
    {
        // Student student1 = new Student
        // {
        //     Name = "Gitesh",
        //     RollNumber = 49,
        //     Gender = 'M',
        //     DOB = "26032006",
        //     Height = 178,
        //     College = "SSGMCE"
        // };

        // student1.DisplayDetails();

        /////////////////////////////////////////////////
        /// 
        /// 
        List<Stud> studs = new List<Stud>
        {
            new Stud { Name = "Gitesh", id = 49 },
            new Stud { Name = "Ramesh", id = 50 },
            new Stud { Name = "Suresh", id = 51 }
        };

        List<Teacher> teachers = new List<Teacher>
        {
            new Teacher { tName = "Mr. Ravi", tid = 1 },
            new Teacher { tName = "Ms. Mamta", tid = 2 },
            new Teacher { tName = "Mr. Om", tid = 3 }
        };

        foreach (var stud in studs)
        {
            Console.WriteLine($"Student Name: {stud.Name}, ID: {stud.id}");
        }

        foreach (var teacher in teachers)
        {
            Console.WriteLine($"Teacher Name: {teacher.tName}, ID: {teacher.tid}");
        }
    }

}