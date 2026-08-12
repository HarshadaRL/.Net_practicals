using Automobile.Models;
using AutomobileAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Automobile.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Vehicle> Vehicles => Set<Vehicle>();

        public DbSet<Customer> Customers => Set<Customer>();

        public DbSet<ServiceType> ServiceTypes => Set<ServiceType>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicle>()
                .HasOne(v => v.Customer)
                .WithMany()
                .HasForeignKey(v => v.CustomerId);

            modelBuilder.Entity<Vehicle>()
                .HasOne(v => v.ServiceType)
                .WithMany()
                .HasForeignKey(v => v.ServiceTypeId);

            modelBuilder.Entity<Vehicle>()
                .HasIndex(v => new
                {
                    v.VehicleNumber,
                    v.ServiceDate
                })
                .IsUnique();
        }
    }
}