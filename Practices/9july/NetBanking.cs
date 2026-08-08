using System;

class NetBanking : PaymentGateway
{
    public void pay(double amount)
    {
        Console.WriteLine("Payment of " + amount + " made through NetBanking.");
    }
}