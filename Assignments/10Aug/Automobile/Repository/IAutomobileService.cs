using Automobile.Models;

namespace Automobile.Repository
{
    public interface IAutomobileService
    {
        Vehicle CreateVehicle(Vehicle vehicle);

        List<Vehicle> GetVehicles();

        Vehicle? GetVehicleById(int id);
    }
}