using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using ejmabunda_web_api.Models;
using ejmabunda_web_api.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace ejmabunda_web_api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    private readonly RsaSecurityKey _privateKey;
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher<User> _passwordHasher;
    private readonly ApiSettings _apiSettings;

    public LoginController(
        [FromKeyedServices("private")] RsaSecurityKey privateKey,
        IUserRepository userRepository,
        IPasswordHasher<User> passwordHasher,
        IOptions<ApiSettings> options)
    {
        _privateKey = privateKey;
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _apiSettings = options.Value;
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var user = await _userRepository.GetUserAsync();
        if (user == null) return NotFound("Admin user not configured.");

        var verificationResult = _passwordHasher
            .VerifyHashedPassword(user, user.PasswordHash, request.Password);

        if (verificationResult == PasswordVerificationResult.Success)
            return Ok(new { Token = CreateToken(user) });
        else if (verificationResult == PasswordVerificationResult.SuccessRehashNeeded)
        {
            var rehashedPassword = _passwordHasher.HashPassword(user, request.Password);

            await _userRepository.UpdateUserAsync(
                new UserDto { PasswordHash = rehashedPassword}, user);

            return Ok(new { Token = CreateToken(user) });
        }
        return Unauthorized();
    }

    public Token CreateToken(User user)
    {
        var signingCreds = new SigningCredentials(_privateKey,
            SecurityAlgorithms.RsaSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Username)
        };

        const int tokenLifetimeMinutes = 10;

        var jwt = new JwtSecurityToken(
            issuer: _apiSettings.ApiUrl,
            audience: _apiSettings.ApiUrl,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(tokenLifetimeMinutes),
            signingCredentials: signingCreds);

        return new Token
        {
            AccessToken = new JwtSecurityTokenHandler().WriteToken(jwt),
            ExpiresIn = tokenLifetimeMinutes * 60
        };
    }
}