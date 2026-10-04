using ejmabunda_web_api.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ejmabunda_web_api.Repositories;

/// <inheritdoc cref="IQualificationRepository"/>
public class QualificationRepository : IQualificationRepository
{
    private readonly PortfolioContext _context;
    private readonly ILogger<QualificationRepository> _logger;

    public QualificationRepository(PortfolioContext context, ILogger<QualificationRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<Qualification> AddQualificationAsync(Qualification qualification)
    {
        try
        {
            await _context.Qualifications.AddAsync(qualification);
            await _context.SaveChangesAsync();

            return qualification;
        }
        catch (DbUpdateException e) when (e.InnerException is SqlException)
        {
            _logger.LogError(e, "An error occurred during a DB qualification add operation.");
            throw;
        }
    }

    public async Task<List<Qualification>> GetAllQualificationsAsync()
    {
        return await _context.Qualifications
            .Include(q => q.Skills).ThenInclude(qs => qs.Skill)
            .OrderByDescending(q => q.StartDate)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Qualification?> GetQualificationByIdAsync(Guid id, bool asNoTracking = true)
    {
        var query = _context.Qualifications
            .Include(q => q.Skills)
            .ThenInclude(qs => qs.Skill)
            .AsQueryable();

        if (asNoTracking) query = query.AsNoTracking();

        return await query.FirstOrDefaultAsync(q => q.Id == id);
    }

    public async Task<Qualification> UpdateQualificationAsync(Qualification qualification)
    {
        try
        {
            await _context.SaveChangesAsync();

            return qualification;
        }
        catch (DbUpdateException e) when (e.InnerException is SqlException)
        {
            _logger.LogError(e, "An error occurred during a DB qualification update operation.");
            throw;
        }
    }

    public async Task<Qualification?> DeleteQualificationAsync(Guid id)
    {
        var qualification = await _context.Qualifications
            .FirstOrDefaultAsync(q => q.Id == id);

        try
        {
            if (qualification == null) return null;
            _context.Qualifications.Remove(qualification);
            await _context.SaveChangesAsync();

            return qualification;
        }
        catch (DbUpdateException e) when (e.InnerException is SqlException)
        {
            _logger.LogError(e, "An error occurred during a DB remove qualification operation.");
            throw;
        }
    }
}
