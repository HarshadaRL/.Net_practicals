using Microsoft.EntityFrameworkCore;
using _12Aug.Models;

namespace _12Aug.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students12 { get; set; }

        public DbSet<User> Users12 { get; set; }
    }
}