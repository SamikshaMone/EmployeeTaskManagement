using EmployeeTaskManagementSystem.Models;
using EmployeeTaskManagementSystem.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmployeeTaskManagementSystem.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<UserModel>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public List<string> GetAvailableRoles()
        {
            return new List<string> { "Admin", "Manager", "Employee" };
        }
    }
}
