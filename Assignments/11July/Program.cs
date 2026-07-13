using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Student> students = new List<Student>();
        List<Course> courses = new List<Course>();

        while (true)
        {
            Console.WriteLine("===== Student Management System =====");
            Console.WriteLine("1. Register Student");
            Console.WriteLine("2. Add Course");
            Console.WriteLine("3. Register Course");
            Console.WriteLine("4. View Student Details");
            Console.WriteLine("5. Exit");

            Console.Write("Enter Choice : ");

            try
            {
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        case 1:

    Console.Write("Enter Student ID : ");
    int id = Convert.ToInt32(Console.ReadLine());

    bool exists = false;

    foreach (Student s in students)
    {
        if (s.StudentId == id)
        {
            exists = true;
            break;
        }
    }

    if (exists)
    {
        Console.WriteLine("Student ID already exists");
        break;
    }

    Console.Write("Enter Student Name : ");
    string name = Console.ReadLine();

    Console.Write("Enter Department : ");
    string dept = Console.ReadLine();

    Student student = new Student(id, name, dept);

    students.Add(student);

    Console.WriteLine("Student Registered Successfully");

    break;
                        break;

                    case 2:
                        case 2:

    Console.Write("Enter Course ID : ");
    int courseId = Convert.ToInt32(Console.ReadLine());

    bool courseExists = false;

    foreach (Course c in courses)
    {
        if (c.CourseId == courseId)
        {
            courseExists = true;
            break;
        }
    }

    if (courseExists)
    {
        Console.WriteLine("Course ID already exists");
        break;
    }

    Console.Write("Enter Course Name : ");
    string courseName = Console.ReadLine();

    Console.Write("Enter Credits : ");
    int credits = Convert.ToInt32(Console.ReadLine());

    Course course = new Course(courseId, courseName, credits);

    courses.Add(course);

    Console.WriteLine("Course Added Successfully");

    Console.WriteLine("\nAvailable Courses");

    foreach (Course c in courses)
    {
        c.DisplayCourse();
    }

    break;
                        break;

                    case 3:
                        case 3:

    Console.Write("Enter Student ID : ");
    int studentId = Convert.ToInt32(Console.ReadLine());

    Student student = null;

    foreach (Student s in students)
    {
        if (s.StudentId == studentId)
        {
            student = s;
            break;
        }
    }

    if (student == null)
    {
        Console.WriteLine("Student Not Found");
        break;
    }

    Console.Write("Enter Course ID : ");
    int courseId = Convert.ToInt32(Console.ReadLine());

    Course course = null;

    foreach (Course c in courses)
    {
        if (c.CourseId == courseId)
        {
            course = c;
            break;
        }
    }

    if (course == null)
    {
        Console.WriteLine("Course Not Found");
        break;
    }

    if (student.EnrolledCourses.Count >= 5)
    {
        Console.WriteLine("Maximum 5 courses allowed");
        break;
    }

    bool alreadyRegistered = false;

    foreach (Course c in student.EnrolledCourses)
    {
        if (c.CourseId == courseId)
        {
            alreadyRegistered = true;
            break;
        }
    }

    if (alreadyRegistered)
    {
        Console.WriteLine("Course already registered");
        break;
    }

    student.EnrolledCourses.Add(course);

    Console.WriteLine("Course Registered Successfully");

    break;
                        break;

                    case 4:
                        case 3:

    Console.Write("Enter Student ID : ");
    int studentId = Convert.ToInt32(Console.ReadLine());

    Student student = null;

    foreach (Student s in students)
    {
        if (s.StudentId == studentId)
        {
            student = s;
            break;
        }
    }

    if (student == null)
    {
        Console.WriteLine("Student Not Found");
        break;
    }

    Console.Write("Enter Course ID : ");
    int courseId = Convert.ToInt32(Console.ReadLine());

    Course course = null;

    foreach (Course c in courses)
    {
        if (c.CourseId == courseId)
        {
            course = c;
            break;
        }
    }

    if (course == null)
    {
        Console.WriteLine("Course Not Found");
        break;
    }

    if (student.EnrolledCourses.Count >= 5)
    {
        Console.WriteLine("Maximum 5 courses allowed");
        break;
    }

    bool alreadyRegistered = false;

    foreach (Course c in student.EnrolledCourses)
    {
        if (c.CourseId == courseId)
        {
            alreadyRegistered = true;
            break;
        }
    }

    if (alreadyRegistered)
    {
        Console.WriteLine("Course already registered");
        break;
    }

    student.EnrolledCourses.Add(course);

    Console.WriteLine("Course Registered Successfully");

    break;
                        break;

                    case 5:
                        return;

                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter numbers only.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
