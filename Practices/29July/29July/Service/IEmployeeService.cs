
using _29July.Models;
namespace _29July.Service
{
    public interface IEmployeeService
    {

        List<Employee> getEmployees();

        Employee getEmployee(int deptid);

        Employee getEmployeeName(string Name);

        Employee addEmployee(Employee employee);
    }
}
