namespace _12Aug.Repository
{
    public interface IAuthService
    {
        string? Login(string username, string password);
    }
}