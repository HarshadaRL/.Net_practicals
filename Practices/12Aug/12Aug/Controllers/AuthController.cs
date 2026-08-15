using Microsoft.AspNetCore.Mvc;
using _12Aug.Repository;

namespace _12Aug.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;

        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }

        // POST: api/Auth/login
        [HttpPost("login")]
        public IActionResult Login(
            string username,
            string password)
        {
            var token = authService.Login(username, password);

            if (token == null)
            {
                return Unauthorized("Invalid username or password");
            }

            return Ok(new
            {
                token = token
            });
        }
    }
}