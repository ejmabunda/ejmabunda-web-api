namespace ejmabunda_web_api.Models;

public class SessionDto
{
    public string? RefreshTokenHash { get; set; }
    public DateTime? ExpiresAt { get; set; }
    public DateTime? RevokedAt { get; set; }
}