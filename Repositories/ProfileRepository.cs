namespace ejmabunda_web_api.Repositories;

using ejmabunda_web_api.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

/// <inheritdoc cref="IProfileRepository"/>
public class ProfileRepository : IProfileRepository
{
    private readonly PortfolioContext _context;
    private readonly ILogger<ProfileRepository> _logger;

    public ProfileRepository(PortfolioContext context, ILogger<ProfileRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    /// <inheritdoc/>
    public async Task<Profile?> GetProfileAsync()
    {
        return await _context.Profiles.FirstOrDefaultAsync();
    }

    /// <inheritdoc/>
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
            // 2627 = SQL Server unique/primary key violation — a profile already exists.
            _logger.LogInformation(e, e.InnerException.Message);
            return null;
        }
        catch (DbUpdateException e)
        {
            _logger.LogError(e, "Something went wrong during a database operation.");
            throw;
        }

        return profile;
    }

    /// <inheritdoc/>
    public async Task<Profile> UpdateProfileAsync(Profile profile, ProfilePutDto profileDto)
    {
        profile.Title = profileDto.Title ?? profile.Title;
        profile.Headline = profileDto.Headline ?? profile.Headline;
        profile.Subtitle = profileDto.Subtitle ?? profile.Subtitle;

        await _context.SaveChangesAsync();
        return profile;
    }

    public async Task<Profile?> DeleteProfileAsync(Profile profile)
    {
        try
        {
            _context.Profiles.Remove(profile);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException e) when (e.InnerException is SqlException)
        {
            _logger.LogError(e, e.InnerException.Message);
            return null;
        }

        return profile;
    }
}