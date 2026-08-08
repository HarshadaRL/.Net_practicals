using _30JulyAssignment.Models;
using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;
using System.Xml.Linq;
using _30JulyAssignment.Service;

namespace _30JulyAssignment.Service
{
    public class EmployeeService : IEmployeeService
    {
        private static List<Employee> employees = new List<Employee>()
        {
          new Employee{ EmployeeId=1, FirstName="John", LastName="J", Email="John@gmail.com",Phone= 7779991111 , DOB="11/01/2002" , Gender="Male ", Salary=50000 ,DateOfJoining= "11/09/2024", Department="HR ", Designation=" Associate Manager", Status="Active "},
          new Employee{ EmployeeId=2, FirstName="Ron", LastName="P", Email="Ron@gmail.com",Phone= 9999555534 , DOB="09/05/2001", Gender="Male ", Salary=60000 ,DateOfJoining= "13/02/2025", Department=" Sales", Designation="Manager ", Status=" Active"},
          new Employee{ EmployeeId=3, FirstName="Aliza", LastName="C", Email="Aliza@gmail.com",Phone=7654896577  , DOB="17/11/2002", Gender="Female ", Salary= 70000,DateOfJoining= "16/07/2026", Department="Finance ", Designation="System Engineer ", Status=" Inactive"},
          new Employee{ EmployeeId=4, FirstName="Sam", LastName="K", Email="Sam@gmail.com",Phone=5675678976, DOB="04/10/2003", Gender="Female ", Salary=40000 ,DateOfJoining="26/09/2025", Department="IT ", Designation=" Team Head", Status=" Active"},

        };

        private readonly IDepartmentService _departmentService;

        public EmployeeService(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }


        public List<Employee> GetAllEmployees()
        {
            return employees;
        }

        public Employee GetEmployeeById(int id)
        {
            return employees.FirstOrDefault(x => x.EmployeeId == id);
        }
        public string AddEmployee(Employee employee)
        {
            if (employees.Any(e => e.Email.Equals(employee.Email,
                StringComparison.OrdinalIgnoreCase)))
            {
                return "Email already exists.";
            }

            
            var dept = _departmentService.GetDeptByDeptId(employee.DepartmentID);

            if (dept == null)
            {
                return "Department not found.";
            }

         
            if (dept.DeptStatus != "Active")
            {
                return "Employees cannot be assigned to an inactive department.";
            }

            employees.Add(employee);

            return "Employee added successfully.";
        }

        public string UpdateEmployee(int id, Employee employee)
        {

            var existing = employees.FirstOrDefault(e => e.EmployeeId == id);

            if (existing == null)
            {
                return "Employee not found.";
            }

            if (employees.Any(e => e.Email == employee.Email &&
                                   e.EmployeeId != id))
            {
                return "Email already exists.";
            }

            var dept = _departmentService.GetDeptByDeptId(employee.DepartmentID);

            if (dept == null)
            {
                return "Department not found.";
            }

            if (dept.DeptStatus != "Active")
            {
                return "Employees cannot be assigned to an inactive department.";
            }

            existing.FirstName = employee.FirstName;
            existing.LastName = employee.LastName;
            existing.Email = employee.Email;
            existing.Phone = employee.Phone;
            existing.DOB = employee.DOB;
            existing.Gender = employee.Gender;
            existing.Salary = employee.Salary;
            existing.DateOfJoining = employee.DateOfJoining;
            existing.Department = employee.Department;
            existing.Status = employee.Status;


            return "Employee updated successfully.";
        }

        public string DeleteEmployee(int id)
        {
            var employee1 = employees.FirstOrDefault(p => p.EmployeeId == id);
            if (employee1 == null)
                return "Employee does not exists";

            employees.Remove(employee1);
            return "Employee deleted successfully";
        }

        public List<Employee> SearchEmployee(string? FirstName, string? Email, int? DepartmentId, string? status, int? employeeId)
        {
            var result = employees.AsEnumerable();

            if (!string.IsNullOrWhiteSpace(FirstName))
            {
                result = result.Where(e =>
                    (e.FirstName + " " + e.LastName)
                    .Contains(FirstName, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrWhiteSpace(Email))
            {
                result = result.Where(e =>
                    e.Email.Contains(Email, StringComparison.OrdinalIgnoreCase));
            }

            if (DepartmentId.HasValue)
            {
                result = result.Where(e => e.DepartmentID == DepartmentId);
            }

            if (employeeId.HasValue)
            {
                result = result.Where(e => e.EmployeeId == employeeId);
            }

            if (!string.IsNullOrWhiteSpace(status))
            {
                result = result.Where(e =>
                    e.Status.Equals(status,
                    StringComparison.OrdinalIgnoreCase));
            }

            return result.ToList();
        }
        public List<Employee> GetEmployeeByDeptId(int deptId)
        {
            return employees
                 .Where(e => e.DepartmentID == deptId)
                 .ToList();
        }
    

    }
    
}
