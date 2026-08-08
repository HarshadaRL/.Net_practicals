namespace ShopEaseConsoleApp.Models
{
    public class Customer : User
    {
        public bool IsLoggedIn { get; set; }

        public Customer()
        {
            IsLoggedIn = false;
        }
    }
}