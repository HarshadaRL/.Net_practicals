using System;
using System.Collections.Generic;

public class Student
{
    public int StudentId { get; set; }
    public string StudentName { get; set; } = "";
    public string Department { get; set; } = "";

    public List<Course> EnrolledCourses { get; set; }

    public Student(int id, string name, string dept)
    {
        StudentId = id;
        StudentName = name;
        Department = dept;
        EnrolledCourses = new List<Course>();
    }

    public virtual double CalculateFee()
    {
        return 0;
    }

    public void DisplayStudent()
    {
        Console.WriteLine("Student ID : " + StudentId);
        Console.WriteLine("Student Name : " + StudentName);
        Console.WriteLine("Department : " + Department);
    }
}
