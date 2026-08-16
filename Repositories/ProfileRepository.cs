namespace ejmabunda_web_api.Repositories;

using ejmabunda_web_api.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

public class ProfileRepository : IProfileRepository
{
    private readonly PortfolioContext _context;
    private readonly ILogger<Profile> _logger;

    public ProfileRepository(PortfolioContext context, ILogger<Profile> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<Profile?> GetProfileAsync()
    {
        return await _context.Profiles.FirstOrDefaultAsync();
    }

    public async Task<Profile?> AddProfileAsync(ProfileAddDto profileDto)
    {
        var profile = new Profile()
        {
            Title = profileDto.Title,
            Headline = profileDto.Headline,
            Subtitle = profileDto.Subtitle,
        };

        try
        {
            await _context.Profiles.AddAsync(profile);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException e) when (e.InnerException is SqlException { Number: 2627 })
        {
            _logger.LogInformation(e, e.InnerException.Message);
            return null;
        }
        catch (DbUpdateException e)
        {
            _logger.LogError(e.InnerException, "Something went wrong during a database operation.");
            throw;
        }

        return profile;
    }
}