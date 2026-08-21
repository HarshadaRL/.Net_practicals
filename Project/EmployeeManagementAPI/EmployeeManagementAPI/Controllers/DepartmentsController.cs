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
    [Authorize] // Requires login
    public class DepartmentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DepartmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepartmentReadDto>>> GetDepartments()
        {
            var departments = await _context.Departments
                .Select(d => new DepartmentReadDto
                {
                    Id = d.Id,
                    Name = d.Name,
                    Description = d.Description,
                    TotalEmployees = d.Employees != null ? d.Employees.Count : 0
                })
                .ToListAsync();

            return Ok(departments);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DepartmentReadDto>> GetDepartment(int id)
        {
            var d = await _context.Departments
                .Include(d => d.Employees)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (d == null) return NotFound();

            return Ok(new DepartmentReadDto
            {
                Id = d.Id,
                Name = d.Name,
                Description = d.Description,
                TotalEmployees = d.Employees != null ? d.Employees.Count : 0
            });
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<DepartmentReadDto>> AddDepartment(DepartmentCreateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var dept = new Department { Name = dto.Name, Description = dto.Description };
            _context.Departments.Add(dept);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDepartment), new { id = dept.Id }, new DepartmentReadDto
            {
                Id = dept.Id,
                Name = dept.Name,
                Description = dept.Description,
                TotalEmployees = 0
            });
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateDepartment(int id, DepartmentCreateDto dto)
        {
            var existing = await _context.Departments.FindAsync(id);
            if (existing == null) return NotFound();

            existing.Name = dto.Name;
            existing.Description = dto.Description;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var dept = await _context.Departments.FindAsync(id);
            if (dept == null) return NotFound();

            _context.Departments.Remove(dept);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}