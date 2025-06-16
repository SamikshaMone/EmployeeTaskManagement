using EmployeeTaskManagementSystem.Models;
using EmployeeTaskManagementSystem.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace EmployeeTaskManagementSystem.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;

        public AuthService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResponse<string>> RegisterAsync(UserRegisterModel model)
        {
            if (await _context.Users.AnyAsync(u => u.Email == model.Email))
                return ApiResponse<string>.Fail("User already exists");

            var user = new UserModel
            {
                FullName = model.FullName,
                Email = model.Email,
                PasswordHash = HashPassword(model.Password),
                Role = model.Role
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return ApiResponse<string>.Success("Success", "User registered successfully");
        }

        public async Task<string> LoginAsync(UserLoginModel model)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
            if (user == null || user.PasswordHash != HashPassword(model.Password))
                return string.Empty;

            // For demo purposes, returning token as role; in real use JWT
            return user.Role;
        }

        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }
    }
}
