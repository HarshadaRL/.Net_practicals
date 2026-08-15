using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using _12Aug.Data;
using _12Aug.Repository;

namespace _12Aug.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext context;
        private readonly IConfiguration configuration;

        public AuthService(
            AppDbContext context,
            IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }

        public string? Login(string email, string password)
        {
            var customer = context.Customers
                .FirstOrDefault(c =>
                    c.Email == email &&
                    c.Password == password);

            if (customer == null)
            {
                return null;
            }

            var claims = new[]
            {
                new Claim(
                    ClaimTypes.NameIdentifier,
                    customer.Id.ToString()
                ),

                new Claim(
                    ClaimTypes.Name,
                    customer.Email
                ),

                new Claim(
                    ClaimTypes.Role,
                    customer.Role
                )
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(
                    configuration["Jwt:Key"]!
                )
            );

            var credentials = new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256
            );

            var token = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler()
                .WriteToken(token);
        }
    }
}