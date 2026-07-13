using System;

public class PartTimeStudent : Student
{
    public PartTimeStudent(int id, string name, string dept)
        : base(id, name, dept)
    {
    }

    public override double CalculateFee()
    {
        int totalCredits = 0;

        foreach (Course c in EnrolledCourses)
        {
            totalCredits += c.Credits;
        }

        return totalCredits * 1200;
    }
}
