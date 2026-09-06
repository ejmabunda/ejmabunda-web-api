using ejmabunda_web_api.Dtos;
using ejmabunda_web_api.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ejmabunda_web_api.Repositories;

public class ExperienceRepository : IExperienceRepository
{
    private readonly PortfolioContext _context;
    private readonly ILogger<ExperienceRepository> _logger;

    public ExperienceRepository(PortfolioContext context, ILogger<ExperienceRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<Experience> AddExperienceAsync(Experience experience)
    {
        try
        {
            await _context.Experiences.AddAsync(experience);
            await _context.SaveChangesAsync();

            return experience;
        }
        catch (DbUpdateException e) when (e.InnerException is SqlException)
        {
            _logger.LogError(e, "An error occurred during a DB experience add operation.");
            throw;
        }
    }

    public async Task<List<Experience>> GetAllExperiencesAsync()
    {
        return await _context.Experiences
            .Include(e => e.ExperienceSkills).ThenInclude(es => es.Skill)
            .OrderByDescending(e => e.StartDate)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Experience?> GetExperienceByIdAsync(Guid id, bool asNoTracking = true)
    {
        return asNoTracking ? 
            await _context.Experiences
                .Include(e => e.ExperienceSkills)
                .ThenInclude(es => es.Skill)
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id) : 
            await _context.Experiences
                .Include(e => e.ExperienceSkills)
                .ThenInclude(es => es.Skill)
                .FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<Experience> UpdateExperienceAsync(Experience experience)
    {
        try
        {
            await _context.SaveChangesAsync();

            return experience;
        } catch (DbUpdateException e) when (e.InnerException is SqlException)
        {
            _logger.LogError(e, "An error occurred during a DB experience update operation.");
            throw;
        }
    }

    public async Task<Experience?> DeleteExperienceAsync(Guid id)
    {
        var experience = await _context.Experiences
            .FirstOrDefaultAsync(e => e.Id == id);

        try
        {
            if (experience == null) return null;
            _context.Experiences.Remove(experience);
            await _context.SaveChangesAsync();

            return experience;
        } catch (DbUpdateException e) when (e.InnerException is SqlException)
        {
            _logger.LogError(e, "An error occurred during a DB remove experience operation.");
            throw;
        }
    }
}