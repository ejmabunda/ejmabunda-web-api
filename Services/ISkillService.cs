using ejmabunda_web_api.Dtos;
using ejmabunda_web_api.Models;

namespace ejmabunda_web_api.Services;

public interface ISkillService
{
    Task<List<Skill>> GetAllSkillsAsync();
    Task<Skill?> GetSkillByIdAsync(Guid id);
    Task<Skill?> AddSkillAsync(SkillAddDto skillDto);
    Task<Skill?> UpdateSkillAsync(SkillUpdateDto skillDto);
    Task<Skill?> DeleteSkillAsync(Guid id);
}