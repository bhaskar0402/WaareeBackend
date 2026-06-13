using Microsoft.AspNetCore.Mvc;
using Waaree.Api.DTOs;
using Waaree.Api.Services;

namespace Waaree.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;

    // AuthService is injected here using Dependency Injection
    public AuthController(AuthService authService)
    {
        _authService = authService;
    }

    // POST: /api/auth/login
    // This API logs in user by mobile number
    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var user = _authService.LoginByMobile(request.Mobile);

        return Ok(new
        {
            message = "Login successful",
            user = user
        });
    }
}