using _30JulyAssignment.Models;
namespace _30JulyAssignment.Service
{
    public interface IEmployeeService
    {
        List<Employee> GetAllEmployees();
        Employee? GetEmployeeById(int id);

        string AddEmployee(Employee employee);

        string UpdateEmployee(int id,Employee employee);
       string DeleteEmployee(int id);

        List<Employee> SearchEmployee(string? FirstName, string? Email, int? DepartmentId, string? status, int? employeeId);
        List <Employee> GetEmployeeByDeptId(int deptId);




    }
}
