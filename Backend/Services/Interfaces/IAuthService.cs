using EmployeeTaskManagementSystem.Models;

namespace EmployeeTaskManagementSystem.Services.Interfaces
{
    public interface IAuthService
    {
        Task<ApiResponse<string>> RegisterAsync(UserRegisterModel model);
        Task<string> LoginAsync(UserLoginModel model);
    }
}
