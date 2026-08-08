using System;

Func<int, int> square = x => x * x;
Console.WriteLine(square(5));

Func<int, int, int> add = (a, b) => a + b;
Console.WriteLine(add(3, 4));

void sub(int a, int b)
{
    Console.WriteLine(a - b);
}

sub(10, 5);