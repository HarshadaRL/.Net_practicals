
using _29July.Models;
namespace _29July.Service
{
    public class EmployeeService : IEmployeeService
    {

        private static List<Employee> employees = new List<Employee>() { 
        
            new Employee{ Id = 1 , Name="Rohan", PhoneN=66661342, Email="Rohan11@gmail.com", DeptId=101},
            new Employee{ Id = 2 , Name="Prathamesh", PhoneN=99991342, Email="Pra21@gmail.com", DeptId=102},
            new Employee{ Id = 3 , Name="Aman", PhoneN=888861342, Email="Aman5@gmail.com", DeptId=103},
            new Employee{ Id = 4 , Name="Atharv", PhoneN=66555342, Email="Atharv9@gmail.com", DeptId=104},
        };

        public List<Employee> getEmployees()
        {
            return employees;
        }

        public Employee? getEmployee(int deptid)
        {
            return employees.FirstOrDefault(e => e.DeptId == deptid);
        }

        public Employee? getEmployeeName(string name)
        {
            return employees.FirstOrDefault(e => e.Name == name);
        }

        public Employee addEmployee(Employee employee)
        {
            employees.Add(employee);
            return employee;
        }
    }
}
