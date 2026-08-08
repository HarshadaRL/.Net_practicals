using System.Security.Cryptography;

class SR
{
    public void Process(Paymentt p)
    {
        p.Pay();
    }
    static void Main()
    {
        SR c = new SR();
        c.Process(new Creditcard());
        c.Process(new UPI());
    }
}