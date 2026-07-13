using System;

public class RegularStudent : Student
{
    public RegularStudent(int id, string name, string dept)
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

        return totalCredits * 1000;
    }
}
