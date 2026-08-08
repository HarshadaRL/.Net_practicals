using System;

using System.Linq;

class Linqeg
{
    static void Main()
    {
        int[] numbers = { 8, 6, 4, 8, 8 };
        var even = numbers.Where(x => x % 2 == 0);
        foreach (var num in even)
        {
            Console.WriteLine(num);
        }
    }
}