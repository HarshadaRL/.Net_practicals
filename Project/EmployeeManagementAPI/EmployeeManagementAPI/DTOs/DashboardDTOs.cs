namespace EmployeeManagementAPI.DTOs
{
    public class DashboardStatsDto
    {
        public int TotalEmployees { get; set; }
        public int ActiveEmployees { get; set; }
        public int InactiveEmployees { get; set; }
        public int TotalDepartments { get; set; }
        public int TotalDesignations { get; set; }
        public decimal AverageSalary { get; set; }
        public decimal TotalPayroll { get; set; }

        // Top 5 most recently joined employees
        public List<EmployeeReadDto> RecentEmployees { get; set; } = new List<EmployeeReadDto>();
    }
}