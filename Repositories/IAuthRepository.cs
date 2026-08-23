using ejmabunda_web_api.Models;

namespace ejmabunda_web_api.Repositories;

public interface IAuthRepository
{
    Task<Session?> AddSessionAsync(Session session);
    Task<Session?> GetSessionAsync(string refreshToken);
    Task<List<Session>> GetAllSessionsAsync();
    Task<Session?> UpdateSessionAsync(SessionDto sessionDto, Session session);
    Task SaveChangesAsync();
}