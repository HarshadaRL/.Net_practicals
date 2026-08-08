using Microsoft.EntityFrameworkCore;
using _4AugAssignment.Models;

namespace _4AugAssignment.Data
{
   
       
        public class AppDbContext : DbContext
        {
            public AppDbContext(DbContextOptions options) : base(options)
            {
            }

            public DbSet<Batch> Batches{ get; set; }
        public DbSet<Course> Courses { get; set; }
    }
    }


