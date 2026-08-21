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
    public class DesignationsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DesignationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DesignationReadDto>>> GetDesignations()
        {
            var designations = await _context.Designations
                .Select(d => new DesignationReadDto
                {
                    Id = d.Id,
                    Name = d.Name,
                    Description = d.Description,
                    TotalEmployees = d.Employees != null ? d.Employees.Count : 0
                })
                .ToListAsync();

            return Ok(designations);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DesignationReadDto>> GetDesignation(int id)
        {
            var d = await _context.Designations
                .Include(d => d.Employees)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (d == null) return NotFound();

            return Ok(new DesignationReadDto
            {
                Id = d.Id,
                Name = d.Name,
                Description = d.Description,
                TotalEmployees = d.Employees != null ? d.Employees.Count : 0
            });
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<DesignationReadDto>> AddDesignation(DesignationCreateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var desig = new Designation { Name = dto.Name, Description = dto.Description };
            _context.Designations.Add(desig);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDesignation), new { id = desig.Id }, new DesignationReadDto
            {
                Id = desig.Id,
                Name = desig.Name,
                Description = desig.Description,
                TotalEmployees = 0
            });
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateDesignation(int id, DesignationCreateDto dto)
        {
            var existing = await _context.Designations.FindAsync(id);
            if (existing == null) return NotFound();

            existing.Name = dto.Name;
            existing.Description = dto.Description;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteDesignation(int id)
        {
            var desig = await _context.Designations.FindAsync(id);
            if (desig == null) return NotFound();

            _context.Designations.Remove(desig);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}