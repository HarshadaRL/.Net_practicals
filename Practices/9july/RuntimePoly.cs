using System;

class RuntimePoly 
{
    public void checkout(PaymentGateway paymentGateway, double amount)
    {
        paymentGateway.pay(amount);
    }
}