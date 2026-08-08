using System;

class Exceptiong
{
    static void CheackAge(int age)
    {
        if (age < 18)
        {
            throw new ArgumentException("Age must be 18 or older.");
        }
        else
        {
            Console.WriteLine("Age is valid.");
        }
    }
    static void Main()
    {
        try
        {
            int a = 10;
            int b = 0;
            int c = a / b;
            Console.WriteLine(c);
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine("Error: Division by zero is not allowed.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
        finally
        {
            Console.WriteLine("Execution completed.");
        }
        try
        {
            CheackAge(15);
        }
        catch(Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);  
        }
    }
}