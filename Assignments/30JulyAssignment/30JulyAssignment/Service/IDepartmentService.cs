using _30JulyAssignment.Models;
namespace _30JulyAssignment.Service
{
    public interface IDepartmentService
    {
        List<Department> GetDepartments();
        String AddDepartment(Department department);
        Department GetDeptByDeptId(int deptId);
        string UpdateDept(int deptId, Department department);

        string DeleteDept(int deptId);

    }
}
