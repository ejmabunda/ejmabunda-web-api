using ejmabunda_web_api.Dtos;
using ejmabunda_web_api.Models;

namespace ejmabunda_web_api.Repositories;

public interface ISkillRepository
{
    Task<List<Skill>> GetAllSkillsAsync();
    Task<Skill> AddSkillAsync(SkillAddDto skillDto);
    Task<Skill?> GetSkillByIdAsync(Guid id);
    Task<Skill?> UpdateSkillAsync(SkillUpdateDto skillDto, Skill skill);
    Task<Skill?> DeleteSkillAsync(Skill skill);
}