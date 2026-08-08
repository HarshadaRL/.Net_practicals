using System;

interface IMessage
{
    void Send();
}

class Email : IMessage
{
    public void Send()
    {
        Console.WriteLine("Email Sent");
    }
}

class Notification
{
    private IMessage message;

    public Notification(IMessage message)
    {
        this.message = message;
    }

    public void Notify()
    {
        message.Send();
    }
}

class Program
{
    static void Main()
    {
        IMessage msg = new Email();
        Notification n = new Notification(msg);
        n.Notify();
    }
}