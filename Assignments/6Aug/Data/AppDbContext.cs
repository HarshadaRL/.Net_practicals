using _06Aug_2026.Models;
using Microsoft.EntityFrameworkCore;

namespace _06Aug_2026.Data
{
    //manages the application database connection
    public class AppDbContext : DbContext
    {
        //constructor accept configuration options & passes them to base class
        //ensure proper db provider & connection string setup
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        //maps Product entity class to a corresponding db table
        //query, save data
        public DbSet<Product> products { get; set; }

        public DbSet<Order> orders { get; set; }
    }
}
