class Bird
{
    public virtual void Fly()
    {
        Console.WriteLine("Flyingg");

    }

    class Penguine : Bird
    {
        public override void Fly()
        {
            throw new Exception("CANT fly");

        }
    }
}