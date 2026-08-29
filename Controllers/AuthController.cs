using ejmabunda_web_api.Models;
using ejmabunda_web_api.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ejmabunda_web_api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IPasswordHasher<User> _passwordHasher;
    private readonly IAuthService _authService;

    public AuthController(
        IUserService userService,
        IPasswordHasher<User> passwordHasher,
        IAuthService authService)
    {
        _userService = userService;
        _passwordHasher = passwordHasher;
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var user = await _userService.GetUserAsync();
        if (user == null) return NotFound("Admin user not configured.");

        var verificationResult = _passwordHasher
            .VerifyHashedPassword(user, user.PasswordHash, request.Password);

        if (verificationResult == PasswordVerificationResult.Failed)
            return Unauthorized();


        if (verificationResult == PasswordVerificationResult.SuccessRehashNeeded)
        {
            var rehashedPassword = _passwordHasher.HashPassword(user, request.Password);

            await _userService.UpdateUserAsync(
                new UserDto { PasswordHash = rehashedPassword }, user);
        }

        var randomToken = await _authService.AddSessionAsync(user);
        if (randomToken == null) return StatusCode(500);

        SetRefreshTokenCookie(randomToken);
        
        return Ok(new { Token = _authService.CreateAccessToken(user) });
    }

    [HttpPost("refresh")]
    public async Task<IActionResult> RefreshToken()
    {
        if (Request.Cookies.TryGetValue("X-Refresh-Token", out var refreshToken))
        {
            var newRefreshToken = await _authService.RefreshToken(refreshToken);
            if (newRefreshToken == null) return NotFound();

            SetRefreshTokenCookie(newRefreshToken);
        } else return Unauthorized("Refresh token is missing.");

        var user = await _userService.GetUserAsync();
        if (user == null) return NotFound();

        return Ok(new { Token = _authService.CreateAccessToken(user) });
    }

    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        if (Request.Cookies.TryGetValue("X-Refresh-Token", out var refreshToken))
        {
            var session = await _authService.GetSessionAsync(refreshToken);
            if (session != null)
                await _authService.RevokeSession(session);
        }

        Response.Cookies.Delete("X-Refresh-Token");
        return Ok("Logged out successfully");
    }

    public void SetRefreshTokenCookie(string refreshToken)
    {
        var cookieOptions = new CookieOptions()
        {
            HttpOnly = true,
            Secure = true,
            SameSite = SameSiteMode.None,
            Expires = DateTime.UtcNow.AddDays(7),
            IsEssential = true
        };

        Response.Cookies.Append("X-Refresh-Token", refreshToken, cookieOptions);
    }
}