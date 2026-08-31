using ejmabunda_web_api.Dtos;
using ejmabunda_web_api.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ejmabunda_web_api.Repositories;

public class SkillRepository : ISkillRepository
{
    private readonly PortfolioContext _context;
    private readonly ILogger<SkillRepository> _logger;

    public SkillRepository(ILogger<SkillRepository> logger, PortfolioContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<List<Skill>> GetAllSkillsAsync()
    {
        return await _context.Skills.ToListAsync();
    }

    public async Task<Skill> AddSkillAsync(SkillAddDto skillDto)
    {
        var skill = new Skill()
        {
            Name = skillDto.Name,
            SkillCategory = skillDto.SkillCategory
        };

        try
        {
            await _context.Skills.AddAsync(skill);
            await _context.SaveChangesAsync();

            return skill;
        }
        catch (DbUpdateException e) when (e.InnerException is SqlException)
        {
            _logger.LogError(e, "Something went wrong when adding a skill.");
            throw;
        }
    }

    public async Task<Skill?> GetSkillByIdAsync(Guid id)
    {
        return await _context.Skills.FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task<Skill?> UpdateSkillAsync(SkillUpdateDto skillDto, Skill skill)
    {
        skill.Name = skillDto.Name ?? skill.Name;
        skill.SkillCategory = skillDto.SkillCategory ?? skill.SkillCategory;

        try
        {
            await _context.SaveChangesAsync();
            return skill;
        }
        catch (DbUpdateException e) when (e.InnerException is SqlException)
        {
            _logger.LogError(e, "An error occurred during a DB skill update operation.");
            throw;
        }
    }

    public async Task<Skill?> DeleteSkillAsync(Skill skill)
    {
        try
        {
            _context.Skills.Remove(skill);
            await _context.SaveChangesAsync();

            return skill;
        }
        catch (DbUpdateException e) when (e.InnerException is SqlException)
        {
            _logger.LogError(e, "An error occurred during a DB delete operation.");
            throw;
        }
    }
}