using ejmabunda_web_api.Models;
using Microsoft.EntityFrameworkCore;

namespace ejmabunda_web_api.Repositories;

public class AuthRepository : IAuthRepository
{
    private readonly PortfolioContext _context;
    private readonly ILogger<AuthRepository> _logger;

    public AuthRepository(PortfolioContext context, ILogger<AuthRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<Session?> AddSessionAsync(Session session)
    {
        try
        {
            await _context.Sessions.AddAsync(session);
            await _context.SaveChangesAsync();

            return session;
        }
        catch (DbUpdateException e)
        {
            _logger.LogError(e, "Something went wrong during a database operation.");
            return null;
        }
    }

    public async Task<Session?> GetSessionAsync(string refreshTokenHash)
    {
        var session = await _context.Sessions
            .FirstOrDefaultAsync(s => s.RefreshTokenHash == refreshTokenHash);

        return session;
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task<Session?> UpdateSessionAsync(SessionDto sessionDto, Session session)
    {
        session.RefreshTokenHash = 
            sessionDto.RefreshTokenHash ?? session.RefreshTokenHash;
        session.ExpiresAt = sessionDto.ExpiresAt ?? session.ExpiresAt;
        
        await _context.SaveChangesAsync();

        return session;
    }

    public async Task<List<Session>> GetAllSessionsAsync()
    {
        return await _context.Sessions.ToListAsync();
    }
}