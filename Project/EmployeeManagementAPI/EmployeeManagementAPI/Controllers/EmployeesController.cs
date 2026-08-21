using EmployeeManagementAPI.Data;
using EmployeeManagementAPI.DTOs;
using EmployeeManagementAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // =========================================================================
        // GET: api/employees?searchTerm=...&departmentId=...&designationId=...&status=...
        // =========================================================================
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeReadDto>>> GetEmployees(
            [FromQuery] string? searchTerm,
            [FromQuery] int? departmentId,
            [FromQuery] int? designationId,
            [FromQuery] string? status)
        {
            // Start with base IQueryable including related Department & Designation
            var query = _context.Employees
                .Include(e => e.Department)
                .Include(e => e.Designation)
                .AsQueryable();

            // 1. Keyword Search across Name, Email, and Phone
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                var term = searchTerm.Trim().ToLower();
                query = query.Where(e =>
                    e.Name.ToLower().Contains(term) ||
                    e.Email.ToLower().Contains(term) ||
                    e.Phone.Contains(term));
            }

            // 2. Filter by Department
            if (departmentId.HasValue && departmentId.Value > 0)
            {
                query = query.Where(e => e.DepartmentId == departmentId.Value);
            }

            // 3. Filter by Designation
            if (designationId.HasValue && designationId.Value > 0)
            {
                query = query.Where(e => e.DesignationId == designationId.Value);
            }

            // 4. Filter by Status (Active / Inactive)
            if (!string.IsNullOrWhiteSpace(status) && !status.Equals("All", StringComparison.OrdinalIgnoreCase))
            {
                query = query.Where(e => e.Status == status);
            }

            // Project to DTO and order newest first
            var employees = await query
                .OrderByDescending(e => e.Id)
                .Select(e => new EmployeeReadDto
                {
                    Id = e.Id,
                    Name = e.Name,
                    Email = e.Email,
                    Phone = e.Phone,
                    Salary = e.Salary,
                    Status = e.Status,
                    JoiningDate = e.JoiningDate,
                    DepartmentId = e.DepartmentId,
                    DepartmentName = e.Department != null ? e.Department.Name : "Unassigned",
                    DesignationId = e.DesignationId,
                    DesignationName = e.Designation != null ? e.Designation.Name : "Unassigned"
                })
                .ToListAsync();

            return Ok(employees);
        }

        // GET: api/employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeReadDto>> GetEmployee(int id)
        {
            var e = await _context.Employees
                .Include(e => e.Department)
                .Include(e => e.Designation)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (e == null) return NotFound($"Employee with ID {id} not found.");

            var dto = new EmployeeReadDto
            {
                Id = e.Id,
                Name = e.Name,
                Email = e.Email,
                Phone = e.Phone,
                Salary = e.Salary,
                Status = e.Status,
                JoiningDate = e.JoiningDate,
                DepartmentId = e.DepartmentId,
                DepartmentName = e.Department != null ? e.Department.Name : "Unassigned",
                DesignationId = e.DesignationId,
                DesignationName = e.Designation != null ? e.Designation.Name : "Unassigned"
            };

            return Ok(dto);
        }

        // POST: api/employees (Admin Only)
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<EmployeeReadDto>> AddEmployee(EmployeeCreateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var employee = new Employee
            {
                Name = dto.Name,
                Email = dto.Email,
                Phone = dto.Phone,
                Salary = dto.Salary,
                Status = dto.Status,
                JoiningDate = dto.JoiningDate,
                DepartmentId = dto.DepartmentId,
                DesignationId = dto.DesignationId
            };

            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            var department = employee.DepartmentId.HasValue ? await _context.Departments.FindAsync(employee.DepartmentId.Value) : null;
            var designation = employee.DesignationId.HasValue ? await _context.Designations.FindAsync(employee.DesignationId.Value) : null;

            var readDto = new EmployeeReadDto
            {
                Id = employee.Id,
                Name = employee.Name,
                Email = employee.Email,
                Phone = employee.Phone,
                Salary = employee.Salary,
                Status = employee.Status,
                JoiningDate = employee.JoiningDate,
                DepartmentId = employee.DepartmentId,
                DepartmentName = department != null ? department.Name : "Unassigned",
                DesignationId = employee.DesignationId,
                DesignationName = designation != null ? designation.Name : "Unassigned"
            };

            return CreatedAtAction(nameof(GetEmployee), new { id = readDto.Id }, readDto);
        }

        // PUT: api/employees/5 (Admin Only)
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateEmployee(int id, EmployeeUpdateDto dto)
        {
            if (id != dto.Id) return BadRequest("ID mismatch.");
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var existingEmployee = await _context.Employees.FindAsync(id);
            if (existingEmployee == null) return NotFound();

            existingEmployee.Name = dto.Name;
            existingEmployee.Email = dto.Email;
            existingEmployee.Phone = dto.Phone;
            existingEmployee.Salary = dto.Salary;
            existingEmployee.Status = dto.Status;
            existingEmployee.JoiningDate = dto.JoiningDate;
            existingEmployee.DepartmentId = dto.DepartmentId;
            existingEmployee.DesignationId = dto.DesignationId;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/employees/5 (Admin Only)
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null) return NotFound();

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}