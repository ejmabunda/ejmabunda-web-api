using ejmabunda_web_api.Dtos;
using ejmabunda_web_api.Models;

namespace ejmabunda_web_api.Repositories;

/// <summary>Data access for <see cref="Skill"/> rows.</summary>
public interface ISkillRepository
{
    Task<List<Skill>> GetAllSkillsAsync();
    Task<Skill> AddSkillAsync(SkillAddDto skillDto);
    Task<Skill?> GetSkillByIdAsync(Guid id);

    /// <summary>Applies the non-null fields of <paramref name="skillDto"/> to <paramref name="skill"/> and saves.</summary>
    Task<Skill?> UpdateSkillAsync(SkillUpdateDto skillDto, Skill skill);

    /// <summary>Removes the given skill row.</summary>
    Task<Skill?> DeleteSkillAsync(Skill skill);
}