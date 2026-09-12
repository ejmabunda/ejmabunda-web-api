namespace ejmabunda_web_api.Models;

/// <summary>Fields that can be updated on a <see cref="Session"/>; null values are ignored.</summary>
public class SessionDto
{
    public string? RefreshTokenHash { get; set; }
    public DateTime? ExpiresAt { get; set; }
    public DateTime? RevokedAt { get; set; }
}