using EmployeeManagementAPI.Data;
using EmployeeManagementAPI.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] // Requires login
    public class DashboardController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ==========================================
        // GET: api/dashboard/stats
        // ==========================================
        [HttpGet("stats")]
        public async Task<ActionResult<DashboardStatsDto>> GetStats()
        {
            var totalEmployees = await _context.Employees.CountAsync();
            var activeEmployees = await _context.Employees.CountAsync(e => e.Status == "Active");
            var inactiveEmployees = await _context.Employees.CountAsync(e => e.Status == "Inactive");
            var totalDepartments = await _context.Departments.CountAsync();
            var totalDesignations = await _context.Designations.CountAsync();

            decimal totalPayroll = 0;
            decimal avgSalary = 0;

            if (totalEmployees > 0)
            {
                totalPayroll = await _context.Employees.SumAsync(e => e.Salary);
                avgSalary = await _context.Employees.AverageAsync(e => e.Salary);
            }

            // Fetch 5 most recent employees
            var recentEmployees = await _context.Employees
                .Include(e => e.Department)
                .Include(e => e.Designation)
                .OrderByDescending(e => e.JoiningDate)
                .Take(5)
                .Select(e => new EmployeeReadDto
                {
                    Id = e.Id,
                    Name = e.Name,
                    Email = e.Email,
                    Phone = e.Phone,
                    Salary = e.Salary,
                    Status = e.Status,
                    JoiningDate = e.JoiningDate,
                    DepartmentName = e.Department != null ? e.Department.Name : "Unassigned",
                    DesignationName = e.Designation != null ? e.Designation.Name : "Unassigned"
                })
                .ToListAsync();

            var stats = new DashboardStatsDto
            {
                TotalEmployees = totalEmployees,
                ActiveEmployees = activeEmployees,
                InactiveEmployees = inactiveEmployees,
                TotalDepartments = totalDepartments,
                TotalDesignations = totalDesignations,
                AverageSalary = Math.Round(avgSalary, 2),
                TotalPayroll = Math.Round(totalPayroll, 2),
                RecentEmployees = recentEmployees
            };

            return Ok(stats);
        }
    }
}