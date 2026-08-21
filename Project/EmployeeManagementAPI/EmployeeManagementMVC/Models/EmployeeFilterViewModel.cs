namespace EmployeeManagementMVC.Models
{
    // ViewModel combining filter parameters with the returned Employee list
    public class EmployeeFilterViewModel
    {
        public string? SearchTerm { get; set; }
        public int? DepartmentId { get; set; }
        public int? DesignationId { get; set; }
        public string? Status { get; set; } = "All";

        public IEnumerable<Employee> Employees { get; set; } = new List<Employee>();
    }
}