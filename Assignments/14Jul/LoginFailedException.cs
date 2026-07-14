using System;

public class LoginFailedException : Exception
{
    public LoginFailedException(string message) : base(message)
    {
    }
}
