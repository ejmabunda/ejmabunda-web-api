using ejmabunda_web_api.Models;
using ejmabunda_web_api.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ejmabunda_web_api.Controllers;

/// <summary>
/// Authentication endpoints for the single admin <see cref="User"/>. Login verifies a
/// password and issues a short-lived JWT access token plus an <c>httpOnly</c>
/// refresh-token cookie (<c>X-Refresh-Token</c>); refresh rotates both; logout revokes
/// the session. See <c>docs/decisions/ADR-001.md</c> and <c>ADR-002.md</c> for the design.
/// </summary>
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

    /// <summary>
    /// Verifies the submitted password against the admin user and starts a session.
    /// On success the JWT access token is returned in the body and the refresh-token
    /// cookie is set. The stored hash is upgraded transparently if its parameters are stale.
    /// </summary>
    /// <response code="200">Access token issued; refresh-token cookie set.</response>
    /// <response code="401">The password was incorrect.</response>
    /// <response code="404">No admin user has been configured.</response>
    /// <response code="500">The session could not be persisted.</response>
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

    /// <summary>
    /// Exchanges the <c>X-Refresh-Token</c> cookie for a new access token, rotating the
    /// refresh cookie. Replaying an already-rotated token revokes the whole session.
    /// </summary>
    /// <response code="200">New access token issued; refresh-token cookie rotated.</response>
    /// <response code="401">The refresh-token cookie is missing.</response>
    /// <response code="404">The token is unknown, expired, revoked, or was replayed.</response>
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

    /// <summary>Revokes the current session (if any) and clears the refresh-token cookie.</summary>
    /// <response code="200">Logged out. Also returned when no valid session was found.</response>
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

    /// <summary>
    /// Writes <paramref name="refreshToken"/> as the <c>X-Refresh-Token</c> cookie:
    /// <c>httpOnly</c>, <c>Secure</c>, <c>SameSite=None</c>, 7-day expiry.
    /// </summary>
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