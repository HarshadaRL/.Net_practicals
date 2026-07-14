using System;

public class InsufficientStockException : Exception
{
    public InsufficientStockException(string message) : base(message)
    {
    }
}
