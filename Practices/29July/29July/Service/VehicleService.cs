using _29July.Models;

namespace _29July.Service
{
    public class VehicleService : IVehicleService   
    {
        private static List<Vehicle> vehicles= new List<Vehicle>() { 
            new Vehicle {Id= 1, Name="Maruti suzuki",Type="Bike", Brand="Mahidra", Price=50000},
            new Vehicle {Id= 1, Name="Maruti suzuki",Type="Bike", Brand="Mahidra", Price=50000},
            new Vehicle {Id= 1, Name="Maruti suzuki",Type="Bike", Brand="Mahidra", Price=50000},
            new Vehicle {Id= 1, Name="Maruti suzuki",Type="Bike", Brand="Mahidra", Price=50000},
        };

        public List<Vehicle> GetVehicles()
        {
            return vehicles;
        }

        public Vehicle? GetVehicleByName(string name)
        {
            return vehicles.FirstOrDefault(e => e.Name == name);
        }

        public Vehicle? GetVehicleById(int id)
        {
            return vehicles.FirstOrDefault(e => e.Id == id);
        }

        public Vehicle? GetVehicleByType(string type)
        {
            return vehicles.FirstOrDefault(e => e.Type == type);
        }

        public Vehicle addVehicle(Vehicle vehicle)
        {
            vehicles.Add(vehicle);
            return vehicle;
        }


    }
}
