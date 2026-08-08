using System;

class CostomException : Exception
{
    static void checkAge(int age)
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
            Console.WriteLine("Enter your age:");
            int age = Convert.ToInt32(Console.ReadLine());
            checkAge(age);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        catch (FormatException)
        {
            Console.WriteLine("Error: Invalid input. Please enter a valid integer.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
        finally
        {
            Console.WriteLine("Execution completed.");
        }
    }   
}