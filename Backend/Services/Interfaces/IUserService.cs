using EmployeeTaskManagementSystem.Models;

namespace EmployeeTaskManagementSystem.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<UserModel>> GetAllUsersAsync();
        List<string> GetAvailableRoles();
    }
}
