using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using EmployeeManagementMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementMVC.Controllers
{
    [Authorize(Roles = "Admin")] // ADMIN ONLY ACCESS
    public class DesignationsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _designationsApiUrl;

        public DesignationsController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            var baseApi = configuration["ApiBaseUrl"] ?? "https://localhost:7245/api/employees";
            _designationsApiUrl = baseApi.Replace("employees", "designations", StringComparison.OrdinalIgnoreCase);
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
            var response = await client.GetAsync(_designationsApiUrl);
            var list = new List<Designation>();

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                list = JsonSerializer.Deserialize<List<Designation>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<Designation>();
            }

            return View(list);
        }

        public IActionResult Create() => View();

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Designation desig)
        {
            if (!ModelState.IsValid) return View(desig);
            var client = CreateAuthorizedClient();
            var response = await client.PostAsJsonAsync(_designationsApiUrl, desig);

            if (response.IsSuccessStatusCode) return RedirectToAction(nameof(Index));
            return View(desig);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var client = CreateAuthorizedClient();
            var response = await client.GetAsync($"{_designationsApiUrl}/{id}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var desig = JsonSerializer.Deserialize<Designation>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                if (desig != null) return View(desig);
            }
            return NotFound();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Designation desig)
        {
            if (id != desig.Id || !ModelState.IsValid) return View(desig);
            var client = CreateAuthorizedClient();
            var response = await client.PutAsJsonAsync($"{_designationsApiUrl}/{id}", desig);

            if (response.IsSuccessStatusCode) return RedirectToAction(nameof(Index));
            return View(desig);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var client = CreateAuthorizedClient();
            var response = await client.GetAsync($"{_designationsApiUrl}/{id}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var desig = JsonSerializer.Deserialize<Designation>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                if (desig != null) return View(desig);
            }
            return NotFound();
        }

        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var client = CreateAuthorizedClient();
            await client.DeleteAsync($"{_designationsApiUrl}/{id}");
            return RedirectToAction(nameof(Index));
        }
    }
}