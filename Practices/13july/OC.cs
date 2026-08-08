using System;

class OC
{
    public void Process(Paymentt p)
    {
        p.pay();
    }
    static void Main()
    {
        OC c = new OC();
        c.Process(new UPI());
    }
}