using System.Net.Quic;
using ejmabunda_web_api.Models;
using Microsoft.EntityFrameworkCore;

namespace ejmabunda_web_api.Repositories;

public class QualificationRepository : IQualificationRepository
{
    private readonly PortfolioContext _context;

    public QualificationRepository(PortfolioContext context)
    {
        _context = context;
    }

    public async Task<List<Qualification>> GetAllQualificationsAsync()
    {
        return await _context.Qualifications
            .Include(q => q.Skills).ThenInclude(qs => qs.Skill)
            .OrderByDescending(q => q.StartDate)
            .AsNoTracking()
            .ToListAsync();
    }
}