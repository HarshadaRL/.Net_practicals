using _4_Aug.Models;
using Microsoft.EntityFrameworkCore;

namespace _4_Aug.Data
{
    public class AppDbContex : DbContext
    {
        public AppDbContex(DbContextOptions<AppDbContex> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}