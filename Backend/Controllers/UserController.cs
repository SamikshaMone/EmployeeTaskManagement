using Microsoft.AspNetCore.Mvc;
using EmployeeTaskManagementSystem.Services;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _userService.GetAllUsersAsync();
        return Ok(users);
    }

    [HttpGet("roles")]
    public IActionResult GetRoles()
    {
        var roles = _userService.GetAvailableRoles();
        return Ok(roles);
    }
}
