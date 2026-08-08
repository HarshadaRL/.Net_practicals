
using _29July.Models;
namespace _29July.Service
{
    public interface IVehicleService
    {
        List<Vehicle> GetVehicles();

        Vehicle GetVehicleByName(string name);

        Vehicle GetVehicleById(int id);

        Vehicle GetVehicleByType(string type);

        Vehicle addVehicle(Vehicle vehicle);
    }
}
