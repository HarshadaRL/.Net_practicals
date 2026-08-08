using System;

class Button
{
    public event Action click;

    public void Press()
    {
        Console.WriteLine("Button pressed.");
        click?.Invoke();
    }
}