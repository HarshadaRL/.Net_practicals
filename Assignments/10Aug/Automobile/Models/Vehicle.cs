using AutomobileAPI.Models;

namespace Automobile.Models
{
    public class Vehicle
    {
        public int Id { get; set; }

        public string VehicleNumber { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public int CustomerId { get; set; }

        public int ServiceTypeId { get; set; }

        public DateTime ServiceDate { get; set; }

        public Customer? Customer { get; set; }

        public ServiceType? ServiceType { get; set; }
    }
}