namespace _12Aug.Repository
{
    public interface IAuthService
    {
        string? Login(string email, string password);
    }
}