namespace EmployeeManagementMVC.Models
{
    public class DashboardViewModel
    {
        public int TotalEmployees { get; set; }
        public int ActiveEmployees { get; set; }
        public int InactiveEmployees { get; set; }
        public int TotalDepartments { get; set; }
        public int TotalDesignations { get; set; }
        public decimal AverageSalary { get; set; }
        public decimal TotalPayroll { get; set; }

        public List<Employee> RecentEmployees { get; set; } = new List<Employee>();
    }
}