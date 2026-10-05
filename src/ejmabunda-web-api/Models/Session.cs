namespace ejmabunda_web_api.Models;

/// <summary>
/// A login session backing one refresh-token family. The current token is stored only as
/// <see cref="RefreshTokenHash"/>; each rotation moves the old hash into
/// <see cref="PreviousRefreshTokenHashes"/> so a replayed (already-rotated) token can be
/// detected and the session revoked. See ADR-001 / ADR-002.
/// </summary>
public class Session
{
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>HMAC-SHA256 hash of the session's current refresh token.</summary>
    public required string RefreshTokenHash { get; set; }
    public DateTime CreatedAt => DateTime.UtcNow;
    public DateTime ExpiresAt { get; set; }
    public bool IsExpired => DateTime.UtcNow >= ExpiresAt;
    public DateTime? RevokedAt { get; set; }
    public DateTime? RotatedAt { get; set; }

    /// <summary><see langword="true"/> while the session is neither expired nor revoked.</summary>
    public bool IsActive => !IsExpired && RevokedAt == null;
    public required User User { get; set; }

    /// <summary>Hashes of refresh tokens previously issued to this session and since rotated out.</summary>
    public List<RefreshToken> PreviousRefreshTokenHashes { get; set; } = [];
}

/// <summary>A single superseded refresh-token hash, kept for reuse detection on its <see cref="Session"/>.</summary>
public class RefreshToken
{
    public Guid Id { get; set; }
    public required Guid SessionId { get; set; }
    public required string RefreshTokenHash { get; set; }
    public required DateTime RotatedAt { get; set; }
}