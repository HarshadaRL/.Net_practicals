using System.Net.Http.Json;
using System.Security.Claims;
using System.Text.Json;
using EmployeeManagementMVC.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _authApiUrl;

        public AccountController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            var baseApi = configuration["ApiBaseUrl"] ?? "https://localhost:7245/api/employees";
            _authApiUrl = baseApi.Replace("employees", "auth", StringComparison.OrdinalIgnoreCase);
        }

        // GET: /Account/Login
        [HttpGet]
        public IActionResult Login(string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string? returnUrl = null)
        {
            if (!ModelState.IsValid) return View(model);

            try
            {
                var client = _httpClientFactory.CreateClient();
                var response = await client.PostAsJsonAsync($"{_authApiUrl}/login", model);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var result = JsonSerializer.Deserialize<AuthApiResponse>(json, options);

                    if (result != null && result.Success)
                    {
                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, result.Username),
                            new Claim(ClaimTypes.Role, result.Role),
                            new Claim("JwtToken", result.Token)
                        };

                        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var principal = new ClaimsPrincipal(identity);

                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                        HttpContext.Session.SetString("JWToken", result.Token);
                        HttpContext.Session.SetString("UserRole", result.Role);
                        HttpContext.Session.SetString("UserName", result.Username);

                        if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                            return Redirect(returnUrl);

                        return RedirectToAction("Index", "Dashboard");
                    }
                }

                ModelState.AddModelError(string.Empty, "Invalid username or password.");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Cannot connect to Web API: {ex.Message}");
            }

            return View(model);
        }

        // GET: /Account/Register
        [HttpGet]
        public IActionResult Register() => View();

        // POST: /Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            try
            {
                var client = _httpClientFactory.CreateClient();
                var response = await client.PostAsJsonAsync($"{_authApiUrl}/register", new
                {
                    Username = model.Username,
                    Password = model.Password,
                    Role = model.Role
                });

                var json = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                if (response.IsSuccessStatusCode)
                {
                    TempData["SuccessMessage"] = "Registration successful! You can now log in.";
                    return RedirectToAction(nameof(Login));
                }

                // Try to read API message
                try
                {
                    var result = JsonSerializer.Deserialize<AuthApiResponse>(json, options);
                    ModelState.AddModelError(string.Empty, result?.Message ?? "Registration failed.");
                }
                catch
                {
                    ModelState.AddModelError(string.Empty, "Registration failed on server.");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Cannot connect to Web API: {ex.Message}");
            }

            return View(model);
        }

        // POST: /Account/Logout
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.Clear();
            return RedirectToAction(nameof(Login));
        }

        [HttpGet]
        public IActionResult AccessDenied() => View();
    }
}