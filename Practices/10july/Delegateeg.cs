using System;

//Func<int, int, int> add = (a, b) => a + b;

delegate void MessageDelegate(string message);

class Delegateeg
{
    static MessageDelegate messageDelegate;
    static void Display1(String message)
    {
        Console.WriteLine("Method 1:"+message);
    }
    static void Display2(String message)
    {
        Console.WriteLine("Method 2:" + message);
    }

    static void Display3(String message)
    {
        Console.WriteLine("Method 3:" + message);
    }


    static void Main()
    {
        
        messageDelegate = Display1;
        messageDelegate += Display2;
        messageDelegate += Display3;

        messageDelegate("Hello World");

        Button button = new Button();
        button.click += () => Console.WriteLine("Button clicked!");
        button.Press();
    }
}