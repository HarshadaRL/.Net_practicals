using Automobile.Data;
using Automobile.Models;
using Automobile.Repository;

namespace Automobile.Services
{
    public class AutomobileService : IAutomobileService
    {
        private readonly AppDbContext context;

        public AutomobileService(AppDbContext context)
        {
            this.context = context;
        }

        public Vehicle CreateVehicle(Vehicle vehicle)
        {
            if (vehicle.ServiceDate.Date < DateTime.UtcNow.Date)
                throw new ArgumentException(
                    "Service date cannot be in the past");

            var customer = context.Customers
                .FirstOrDefault(c => c.Id == vehicle.CustomerId);

            if (customer == null)
                throw new ArgumentException("Invalid customer");

            var serviceType = context.ServiceTypes
                .FirstOrDefault(s => s.Id == vehicle.ServiceTypeId);

            if (serviceType == null)
                throw new ArgumentException("Invalid service type");

            var alreadyBooked = context.Vehicles.Any(v =>
                v.VehicleNumber == vehicle.VehicleNumber &&
                v.ServiceDate.Date == vehicle.ServiceDate.Date);

            if (alreadyBooked)
                throw new ArgumentException(
                    "This vehicle already has a service booking for this date");

            context.Vehicles.Add(vehicle);
            context.SaveChanges();

            return vehicle;
        }

        public Vehicle? GetVehicleById(int id)
        {
            return context.Vehicles.FirstOrDefault(v => v.Id == id);
        }

        public List<Vehicle> GetVehicles()
        {
            return context.Vehicles.ToList();
        }
    }
}