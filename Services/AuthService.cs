using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using ejmabunda_web_api.Models;
using ejmabunda_web_api.Repositories;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace ejmabunda_web_api.Services;

/// <inheritdoc cref="IAuthService"/>
public class AuthService : IAuthService
{
    private readonly SecurityKey _privateKey;
    private readonly ApiSettings _apiSettings;
    private readonly IAuthRepository _authRepository;

    public AuthService(
        [FromKeyedServices("private")] RsaSecurityKey privateKey,
        IOptions<ApiSettings> options,
        IAuthRepository authRepository)
    {
        _privateKey = privateKey;
        _apiSettings = options.Value;
        _authRepository = authRepository;
    }

    public Token CreateAccessToken(User user)
    {
        var signingCreds = new SigningCredentials(_privateKey,
            SecurityAlgorithms.RsaSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Username)
        };

        var jwt = new JwtSecurityToken(
            issuer: _apiSettings.ApiUrl,
            audience: _apiSettings.ApiUrl,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_apiSettings.AccessTokenLifetimeInMinutes),
            signingCredentials: signingCreds);

        return new Token
        {
            AccessToken = new JwtSecurityTokenHandler().WriteToken(jwt),
            ExpiresIn = _apiSettings.AccessTokenLifetimeInMinutes * 60
        };
    }

    public async Task<string?> AddSessionAsync(User user)
    {
        var randomToken = GenerateSecureRandomToken();
        var randomHashedToken = HashToken(randomToken);
        var session = new Session()
        {
            RefreshTokenHash = randomHashedToken,
            User = user,
            ExpiresAt = DateTime.UtcNow.AddDays(7)
        };

        session = await _authRepository.AddSessionAsync(session);
        if (session == null) return null;

        user.Sessions.Add(session);

        return randomToken;
    }

    /// <summary>
    /// Computes the HMAC-SHA256 hash (hex) of a raw token using the configured key.
    /// This hash is what gets stored and compared; the raw token is never persisted.
    /// </summary>
    public string HashToken(string rawToken)
    {
        if (string.IsNullOrWhiteSpace(rawToken))
            throw new ArgumentException("Token cannot be null or empty.");

        using var hmac = new HMACSHA256(
            Convert.FromBase64String(_apiSettings.RefreshTokenHashKey));
        byte[] tokenBytes = Encoding.UTF8.GetBytes(rawToken);
        byte[] hashBytes = hmac.ComputeHash(tokenBytes);

        return Convert.ToHexString(hashBytes);
    }

    /// <summary>Generates a 64-byte cryptographically-random token, Base64-encoded.</summary>
    private string GenerateSecureRandomToken()
    {
        return Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
    }

    public async Task<Session?> GetSessionAsync(string refreshToken)
    {
        var refreshTokenHash = HashToken(refreshToken);
        return await _authRepository.GetSessionAsync(refreshTokenHash);
    }

    /// <summary>
    /// Finds a session whose already-rotated ("previous") token hashes contain this
    /// token — i.e. a replayed refresh token. Used to detect reuse and revoke the session.
    /// </summary>
    public async Task<Session?> GetAffectedSession(string refreshToken)
    {
        var sessions = await _authRepository.GetAllSessionsAsync();
        
        var session = sessions
            .FirstOrDefault(s => s.PreviousRefreshTokenHashes
                .Select(pt => pt.RefreshTokenHash)
                    .Contains(HashToken(refreshToken)));

        return session;
    }

    public async Task<Session> RevokeSession(Session session)
    {
        session.RevokedAt = DateTime.UtcNow;
        await _authRepository.SaveChangesAsync();

        return session;
    }

    public async Task<string?> RefreshToken(string refreshToken)
    {
        var session = await GetSessionAsync(refreshToken);
        if (session == null)
        {
            session = await GetAffectedSession(refreshToken);
            if (session == null) return null;

            await RevokeSession(session);
            return null;
        }

        if (!session.IsActive) return null;

        session.PreviousRefreshTokenHashes.Add(
            new RefreshToken
            {
                SessionId = session.Id,
                RefreshTokenHash = session.RefreshTokenHash,
                RotatedAt = DateTime.UtcNow
            });
        session.RotatedAt = DateTime.UtcNow;

        var newRefreshToken = GenerateSecureRandomToken();
        var hashedToken = HashToken(newRefreshToken);

        await _authRepository.UpdateSessionAsync(
            new SessionDto
            {
                RefreshTokenHash = hashedToken,
                ExpiresAt = DateTime.UtcNow.AddDays(7)
            }, session);

        return newRefreshToken;
    }
}