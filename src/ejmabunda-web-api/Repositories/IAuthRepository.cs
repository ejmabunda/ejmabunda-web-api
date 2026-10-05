using ejmabunda_web_api.Models;

namespace ejmabunda_web_api.Repositories;

/// <summary>Data access for <see cref="Session"/> rows and their rotated <see cref="RefreshToken"/> hashes.</summary>
public interface IAuthRepository
{
    /// <summary>Persists a new session. Returns <see langword="null"/> if the insert failed.</summary>
    Task<Session?> AddSessionAsync(Session session);

    /// <summary>Finds a session by its current refresh-token hash, or <see langword="null"/>.</summary>
    Task<Session?> GetSessionAsync(string refreshToken);

    /// <summary>Returns every session (used to scan previous-token hashes for reuse detection).</summary>
    Task<List<Session>> GetAllSessionsAsync();

    /// <summary>Applies the non-null fields of <paramref name="sessionDto"/> to <paramref name="session"/> and saves.</summary>
    Task<Session?> UpdateSessionAsync(SessionDto sessionDto, Session session);

    /// <summary>Persists pending changes tracked on the context.</summary>
    Task SaveChangesAsync();
}