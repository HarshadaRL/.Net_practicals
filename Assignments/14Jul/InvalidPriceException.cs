using System;

public class InvalidPriceException : Exception
{
    public InvalidPriceException(string message) : base(message)
    {
    }
}
