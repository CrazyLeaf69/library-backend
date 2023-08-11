namespace backend.Controllers;

using Microsoft.AspNetCore.Mvc;
using backend.Models.Auth;
using backend.Models.Response;
using backend.Services;
using Microsoft.AspNetCore.Authorization;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public Response Register(RegisterRequest model)
    {
        return _authService.Register(model);
    }

    [HttpPost("login")]
    public Response Login(LoginRequest model)
    {
        return _authService.Login(model);
    }

    [HttpGet("verify")]
    public Response Verify([FromHeader] string authorization)
    {
        return _authService.Verify(authorization);
    }

    [HttpPost("refresh")]
    public Response RefreshAccessToken(RefreshAccessTokenRequest model)
    {
        return _authService.RefreshAccessToken(model.RefreshToken);
    }
}