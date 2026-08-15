using _7_Aug.Models;
using Microsoft.EntityFrameworkCore;

namespace _7_Aug.Data
{
    public class AppDbContext:DbContext
    {
        
            // Constructor receives DB configuration through DI
            public AppDbContext(DbContextOptions options) : base(options)
            {
            }

       

        // Represents the Products table in DB
        public DbSet<Product> Products => Set<Product>();

        // Represents the Orders table in DB
        public DbSet<Orders> Orders => Set<Orders>();

        // Represents the OrderItems table in DB
        public DbSet<OrderItems> OrderItems => Set<OrderItems>();

        // Configure relationships between entities
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // One Product -> Many OrderItems
            modelBuilder.Entity<OrderItems>()
                .HasOne(o => o.Product)
                .WithMany(p => p.OrderItems)
                .HasForeignKey(o => o.ProductId);

            // One Order -> Many OrderItems
            modelBuilder.Entity<OrderItems>()
                .HasOne(o => o.Order)
                .WithMany(p => p.OrderItems)
                .HasForeignKey(o => o.OrderId);
        }
    }
    }

