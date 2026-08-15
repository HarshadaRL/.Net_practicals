using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using _12Aug.Data;
using _12Aug.Models;
using _12Aug.Repository;

namespace _12Aug.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext context;
        private readonly IAuthService authService;

        public AuthController(
            AppDbContext context,
            IAuthService authService)
        {
            this.context = context;
            this.authService = authService;
        }

        // POST: api/Auth/register
        [HttpPost("register")]
        [AllowAnonymous]
        public IActionResult Register(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Don't allow user to register as Admin
            customer.Role = "Customer";

            var existingCustomer = context.Customers
                .FirstOrDefault(c => c.Email == customer.Email);

            if (existingCustomer != null)
            {
                return BadRequest(
                    "Email is already registered");
            }

            context.Customers.Add(customer);
            context.SaveChanges();

            return Ok(new
            {
                message = "Customer registered successfully",
                customer.Id,
                customer.Name,
                customer.Email,
                customer.Role
            });
        }

        // POST: api/Auth/login
        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Login(
            string email,
            string password)
        {
            var token = authService.Login(
                email,
                password);

            if (token == null)
            {
                return Unauthorized(
                    "Invalid email or password");
            }

            return Ok(new
            {
                message = "Login successful",
                token = token
            });
        }
    }
}