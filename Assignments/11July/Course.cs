using System;

public class Course
{
    public int CourseId { get; set; }
    public string CourseName { get; set; } = "";
    public int Credits { get; set; }

    public Course(int id, string name, int credits)
    {
        CourseId = id;
        CourseName = name;
        Credits = credits;
    }

    public void DisplayCourse()
    {
        Console.WriteLine("Course ID : " + CourseId);
        Console.WriteLine("Course Name : " + CourseName);
        Console.WriteLine("Credits : " + Credits);
    }
}
