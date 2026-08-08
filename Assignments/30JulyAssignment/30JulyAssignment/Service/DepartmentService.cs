using _30JulyAssignment.Models;
using _30JulyAssignment.Service;

namespace _30JulyAssignment.Service
{
    public class DepartmentService: IDepartmentService
    {
        
        private static List<Department> departments = new List<Department>()
        {
            new Department{DeptName="HR", DeptId=101, DeptStatus="Active"},
            new Department{DeptName="IT", DeptId=102, DeptStatus="Active"},
            new Department{DeptName="Finance", DeptId=103, DeptStatus="Active"},
            new Department{DeptName="Sales", DeptId=104, DeptStatus="Active"},
            new Department{DeptName="Operations", DeptId=105, DeptStatus="Inactive"},
        };
        private static List<Employee> employees = new List<Employee>()
        {
          new Employee{ EmployeeId=1, FirstName="John", LastName="J", Email="John@gmail.com",Phone= 7779991111 , DOB="11/01/2002" , Gender="Male ", Salary=50000 ,DateOfJoining= "11/09/2024", Department="HR ", Designation=" Associate Manager", Status="Active "},
          new Employee{ EmployeeId=2, FirstName="Ron", LastName="P", Email="Ron@gmail.com",Phone= 9999555534 , DOB="09/05/2001", Gender="Male ", Salary=60000 ,DateOfJoining= "13/02/2025", Department=" Sales", Designation="Manager ", Status=" Active"},
          new Employee{ EmployeeId=3, FirstName="Aliza", LastName="C", Email="Aliza@gmail.com",Phone=7654896577  , DOB="17/11/2002", Gender="Female ", Salary= 70000,DateOfJoining= "16/07/2026", Department="Finance ", Designation="System Engineer ", Status=" Inactive"},
          new Employee{ EmployeeId=4, FirstName="Sam", LastName="K", Email="Sam@gmail.com",Phone=5675678976, DOB="04/10/2003", Gender="Female ", Salary=40000 ,DateOfJoining="26/09/2025", Department="IT ", Designation=" Team Head", Status=" Active"},

        };




        public List<Department> GetDepartments()
        {
            return departments;
        }

        public String AddDepartment(Department department)
        {
            if (departments.Any(d => d.DeptName.Equals(department.DeptName,
                StringComparison.OrdinalIgnoreCase)))
            {
                return "Department name already exists.";
            }
            departments.Add(department);
            return "Department added successfully";

        }
         
        public Department GetDeptByDeptId(int deptId)
        {
            return departments.FirstOrDefault(x => x.DeptId == deptId);
        }

        public String UpdateDept(int deptId, Department department)
        {
            var existing = departments.FirstOrDefault(d => d.DeptId == deptId);

            if (existing == null)
            {
                return "Department not found.";
            }

            if (departments.Any(d => d.DeptName.Equals(department.DeptName,
                StringComparison.OrdinalIgnoreCase) && d.DeptId != deptId))
            {
                return "Department name already exists.";
            }
            existing.DeptName = department.DeptName;
            
            existing.DeptStatus = department.DeptStatus;

            return "Department updated successfully.";
        }

        public string DeleteDept(int deptId)
        {
            var department = departments.FirstOrDefault(d => d.DeptId == deptId);

            if (department == null)
            {
                return "Department not found.";
            }

            bool hasEmployees = employees.Any(e => e.DepartmentID == deptId);

            if (hasEmployees)
            {
                return "Department cannot be deleted because employees are assigned.";
            }

            departments.Remove(department);

            return "Department deleted successfully.";
        }
    }
}
