using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using EmployeeManagementMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeeManagementMVC.Controllers
{
    [Authorize]
    public class EmployeesController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _apiBaseUrl;
        private readonly string _departmentsApiUrl;
        private readonly string _designationsApiUrl;

        public EmployeesController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _apiBaseUrl = configuration["ApiBaseUrl"] ?? "https://localhost:7245/api/employees";
            _departmentsApiUrl = _apiBaseUrl.Replace("employees", "departments", StringComparison.OrdinalIgnoreCase);
            _designationsApiUrl = _apiBaseUrl.Replace("employees", "designations", StringComparison.OrdinalIgnoreCase);
        }

        private HttpClient CreateAuthorizedClient()
        {
            var client = _httpClientFactory.CreateClient();
            var token = HttpContext.Session.GetString("JWToken") ?? User.Claims.FirstOrDefault(c => c.Type == "JwtToken")?.Value;
            if (!string.IsNullOrEmpty(token))
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
            return client;
        }

        private async Task LoadDropdownsAsync(int? selectedDeptId = null, int? selectedDesigId = null)
        {
            var client = CreateAuthorizedClient();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            var deptResponse = await client.GetAsync(_departmentsApiUrl);
            var departments = new List<Department>();
            if (deptResponse.IsSuccessStatusCode)
            {
                var json = await deptResponse.Content.ReadAsStringAsync();
                departments = JsonSerializer.Deserialize<List<Department>>(json, options) ?? new List<Department>();
            }
            ViewBag.DepartmentList = new SelectList(departments, "Id", "Name", selectedDeptId);

            var desigResponse = await client.GetAsync(_designationsApiUrl);
            var designations = new List<Designation>();
            if (desigResponse.IsSuccessStatusCode)
            {
                var json = await desigResponse.Content.ReadAsStringAsync();
                designations = JsonSerializer.Deserialize<List<Designation>>(json, options) ?? new List<Designation>();
            }
            ViewBag.DesignationList = new SelectList(designations, "Id", "Name", selectedDesigId);
        }

        // ==========================================
        // 1. GET: /Employees (With Search & Multi-Criteria Filtering)
        // ==========================================
        [HttpGet]
        public async Task<IActionResult> Index(string? searchTerm, int? departmentId, int? designationId, string? status)
        {
            var client = CreateAuthorizedClient();

            // Build dynamic query parameters for Web API
            var queryParams = new List<string>();
            if (!string.IsNullOrWhiteSpace(searchTerm)) queryParams.Add($"searchTerm={Uri.EscapeDataString(searchTerm.Trim())}");
            if (departmentId.HasValue && departmentId.Value > 0) queryParams.Add($"departmentId={departmentId.Value}");
            if (designationId.HasValue && designationId.Value > 0) queryParams.Add($"designationId={designationId.Value}");
            if (!string.IsNullOrWhiteSpace(status) && !status.Equals("All", StringComparison.OrdinalIgnoreCase)) queryParams.Add($"status={status}");

            var queryString = queryParams.Any() ? "?" + string.Join("&", queryParams) : string.Empty;
            var response = await client.GetAsync($"{_apiBaseUrl}{queryString}");

            var employees = new List<Employee>();
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                employees = JsonSerializer.Deserialize<List<Employee>>(jsonString, options) ?? new List<Employee>();
            }
            else
            {
                ViewBag.ErrorMessage = "Failed to load employees from Web API.";
            }

            await LoadDropdownsAsync(departmentId, designationId);

            var viewModel = new EmployeeFilterViewModel
            {
                SearchTerm = searchTerm,
                DepartmentId = departmentId,
                DesignationId = designationId,
                Status = status ?? "All",
                Employees = employees
            };

            return View(viewModel);
        }

        // GET: /Employees/Create (Admin Only)
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            await LoadDropdownsAsync();
            return View(new Employee { JoiningDate = DateTime.Today, Status = "Active" });
        }

        // POST: /Employees/Create (Admin Only)
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                await LoadDropdownsAsync(employee.DepartmentId, employee.DesignationId);
                return View(employee);
            }

            var client = CreateAuthorizedClient();
            var response = await client.PostAsJsonAsync(_apiBaseUrl, employee);

            if (response.IsSuccessStatusCode)
            {
                TempData["SuccessMessage"] = "Employee created successfully!";
                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError(string.Empty, "Unable to save employee.");
            await LoadDropdownsAsync(employee.DepartmentId, employee.DesignationId);
            return View(employee);
        }

        // GET: /Employees/Edit/5 (Admin Only)
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id)
        {
            var client = CreateAuthorizedClient();
            var response = await client.GetAsync($"{_apiBaseUrl}/{id}");

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var employee = JsonSerializer.Deserialize<Employee>(jsonString, options);

                if (employee != null)
                {
                    await LoadDropdownsAsync(employee.DepartmentId, employee.DesignationId);
                    return View(employee);
                }
            }

            return NotFound();
        }

        // POST: /Employees/Edit/5 (Admin Only)
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Employee employee)
        {
            if (id != employee.Id) return BadRequest();

            if (!ModelState.IsValid)
            {
                await LoadDropdownsAsync(employee.DepartmentId, employee.DesignationId);
                return View(employee);
            }

            var client = CreateAuthorizedClient();
            var response = await client.PutAsJsonAsync($"{_apiBaseUrl}/{id}", employee);

            if (response.IsSuccessStatusCode)
            {
                TempData["SuccessMessage"] = "Employee updated successfully!";
                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError(string.Empty, "Unable to update employee.");
            await LoadDropdownsAsync(employee.DepartmentId, employee.DesignationId);
            return View(employee);
        }

        // GET: /Employees/Delete/5 (Admin Only)
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var client = CreateAuthorizedClient();
            var response = await client.GetAsync($"{_apiBaseUrl}/{id}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var employee = JsonSerializer.Deserialize<Employee>(json, options);
                if (employee != null) return View(employee);
            }

            return NotFound();
        }

        // POST: /Employees/Delete/5 (Admin Only)
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var client = CreateAuthorizedClient();
            var response = await client.DeleteAsync($"{_apiBaseUrl}/{id}");

            if (response.IsSuccessStatusCode)
            {
                TempData["SuccessMessage"] = "Employee deleted successfully!";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}