using ejmabunda_web_api.Models;

namespace ejmabunda_web_api.Services;

/// <summary>
/// Token and session logic behind <see cref="Controllers.AuthController"/>: issuing JWT
/// access tokens and managing rotating, hashed refresh tokens. See ADR-001 / ADR-002.
/// </summary>
public interface IAuthService
{
    /// <summary>Builds a signed JWT access token (RSA SHA-256) for the user.</summary>
    Token CreateAccessToken(User user);

    /// <summary>
    /// Starts a session for the user and returns the raw refresh token to hand to the
    /// client; only a hash of it is stored. Returns <see langword="null"/> if the session
    /// could not be persisted.
    /// </summary>
    Task<string?> AddSessionAsync(User user);

    /// <summary>Finds the session for a raw refresh token, or <see langword="null"/> if none matches.</summary>
    Task<Session?> GetSessionAsync(string refreshToken);

    /// <summary>Marks a session revoked so its refresh tokens stop working.</summary>
    Task<Session> RevokeSession(Session session);

    /// <summary>
    /// Rotates the refresh token for the session that <paramref name="refreshToken"/>
    /// identifies and returns the new raw token. Returns <see langword="null"/> when the
    /// token is unknown or the session is inactive; if the token is a replayed
    /// (already-rotated) one, the session is revoked as a reuse-detection measure.
    /// </summary>
    Task<string?> RefreshToken(string refreshToken);
}