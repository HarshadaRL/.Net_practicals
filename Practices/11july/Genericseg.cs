using System;

class Genericseg
{
    void Print(int number)
    {
        Console.WriteLine(number);
    }

    void Print1(string namee)
    {
        Console.WriteLine(namee);
    }
}

// Generics - write one class or method that works with different data types

public class Genericseg<T>
{
    public void Print(T value)
    {
        Console.WriteLine(value);
    }
}

