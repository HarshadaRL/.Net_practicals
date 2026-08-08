using System;

class InvalidAgeException : Exception
{
    public InvalidAgeException(string message) : base(message)
    {
    }
}