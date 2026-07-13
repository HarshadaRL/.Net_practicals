using System;

public class ScholarshipStudent : Student
{
    public ScholarshipStudent(int id, string name, string dept)
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

        return (totalCredits * 1000) * 0.5;
    }
}
