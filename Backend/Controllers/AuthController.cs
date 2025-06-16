using Microsoft.AspNetCore.Mvc;
using EmployeeTaskManagementSystem.Models;
using EmployeeTaskManagementSystem.Services;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(UserRegisterModel model)
    {
        var result = await _authService.RegisterAsync(model);
        if (!result.IsSuccess)
            return BadRequest(result.Message);
        return Ok(result.Message);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(UserLoginModel model)
    {
        var token = await _authService.LoginAsync(model);
        if (string.IsNullOrEmpty(token))
            return Unauthorized("Invalid credentials");
        return Ok(new { Token = token });
    }
}
