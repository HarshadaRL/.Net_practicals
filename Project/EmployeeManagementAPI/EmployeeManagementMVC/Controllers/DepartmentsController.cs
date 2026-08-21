using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using EmployeeManagementMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementMVC.Controllers
{
    [Authorize(Roles = "Admin")] // ADMIN ONLY ACCESS
    public class DepartmentsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _departmentsApiUrl;

        public DepartmentsController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            var baseApi = configuration["ApiBaseUrl"] ?? "https://localhost:7245/api/employees";
            _departmentsApiUrl = baseApi.Replace("employees", "departments", StringComparison.OrdinalIgnoreCase);
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

        public async Task<IActionResult> Index()
        {
            var client = CreateAuthorizedClient();
            var response = await client.GetAsync(_departmentsApiUrl);
            var list = new List<Department>();

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                list = JsonSerializer.Deserialize<List<Department>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<Department>();
            }

            return View(list);
        }

        public IActionResult Create() => View();

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Department dept)
        {
            if (!ModelState.IsValid) return View(dept);
            var client = CreateAuthorizedClient();
            var response = await client.PostAsJsonAsync(_departmentsApiUrl, dept);

            if (response.IsSuccessStatusCode) return RedirectToAction(nameof(Index));
            return View(dept);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var client = CreateAuthorizedClient();
            var response = await client.GetAsync($"{_departmentsApiUrl}/{id}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var dept = JsonSerializer.Deserialize<Department>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                if (dept != null) return View(dept);
            }
            return NotFound();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Department dept)
        {
            if (id != dept.Id || !ModelState.IsValid) return View(dept);
            var client = CreateAuthorizedClient();
            var response = await client.PutAsJsonAsync($"{_departmentsApiUrl}/{id}", dept);

            if (response.IsSuccessStatusCode) return RedirectToAction(nameof(Index));
            return View(dept);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var client = CreateAuthorizedClient();
            var response = await client.GetAsync($"{_departmentsApiUrl}/{id}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var dept = JsonSerializer.Deserialize<Department>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                if (dept != null) return View(dept);
            }
            return NotFound();
        }

        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var client = CreateAuthorizedClient();
            await client.DeleteAsync($"{_departmentsApiUrl}/{id}");
            return RedirectToAction(nameof(Index));
        }
    }
}