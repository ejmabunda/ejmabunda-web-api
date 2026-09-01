namespace ejmabunda_web_api.Models;

public class Session
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string RefreshTokenHash { get; set; }
    public DateTime CreatedAt => DateTime.UtcNow;
    public DateTime ExpiresAt { get; set; }
    public bool IsExpired => DateTime.UtcNow >= ExpiresAt;
    public DateTime? RevokedAt { get; set; }
    public DateTime? RotatedAt { get; set; }
    public bool IsActive => !IsExpired && RevokedAt == null;
    public required User User { get; set; }
    public List<RefreshToken> PreviousRefreshTokenHashes { get; set; } = [];
}

public class RefreshToken
{
    public Guid Id { get; set; }
    public required Guid SessionId { get; set; }
    public required string RefreshTokenHash { get; set; }
    public required DateTime RotatedAt { get; set; }
}