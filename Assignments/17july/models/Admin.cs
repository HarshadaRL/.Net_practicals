namespace ShopEaseConsoleApp.Models
{
    public class Admin : User
    {
        public Admin()
        {
            UserId = 1;
            FullName = "Administrator";
            Email = "admin@shopease.com";
            Mobile = "9999999999";
            Address = "Head Office";
            Username = "admin";
            Password = "admin123";
        }
    }
}