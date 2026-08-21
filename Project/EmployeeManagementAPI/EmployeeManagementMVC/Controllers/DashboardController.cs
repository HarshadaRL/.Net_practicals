using System.Net.Http.Headers;
using System.Text.Json;
using EmployeeManagementMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementMVC.Controllers
{
    [Authorize] // Requires login
    public class DashboardController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _dashboardApiUrl;

        public DashboardController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            var baseApi = configuration["ApiBaseUrl"] ?? "https://localhost:7245/api/employees";
            _dashboardApiUrl = baseApi.Replace("employees", "dashboard/stats", StringComparison.OrdinalIgnoreCase);
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

        // GET: /Dashboard or /Dashboard/Index
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var stats = new DashboardViewModel();
            var client = CreateAuthorizedClient();
            var response = await client.GetAsync(_dashboardApiUrl);

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                stats = JsonSerializer.Deserialize<DashboardViewModel>(jsonString, options) ?? new DashboardViewModel();
            }
            else
            {
                ViewBag.ErrorMessage = "Unable to load dashboard metrics from Web API.";
            }

            return View(stats);
        }
    }
}