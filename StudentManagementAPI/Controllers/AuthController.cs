using Microsoft.AspNetCore.Mvc;
using StudentManagementAPI.Models;
using StudentManagementAPI.Services;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public IActionResult Login(LoginModel model)
    {
        if (!_authService.ValidateUser(model.Username, model.Password))
            return Unauthorized("Invalid credentials");

        var token = _authService.GenerateToken(model.Username);

        return Ok(new { Token = token });
    }
}