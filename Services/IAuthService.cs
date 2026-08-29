using ejmabunda_web_api.Models;

namespace ejmabunda_web_api.Services;

public interface IAuthService
{
    Token CreateAccessToken(User user);
    Task<string?> AddSessionAsync(User user);
    Task<Session?> GetSessionAsync(string refreshToken);
    Task<Session> RevokeSession(Session session);
    Task<string?> RefreshToken(string refreshToken);
}