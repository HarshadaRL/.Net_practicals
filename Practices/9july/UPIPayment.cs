using System;

class UPIPayment : PaymentGateway
{
    public void pay(double amount)
    {
        Console.WriteLine("Payment of " + amount + " made through UPI.");
    }
}