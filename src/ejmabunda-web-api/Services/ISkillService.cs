using ejmabunda_web_api.Dtos;
using ejmabunda_web_api.Models;

namespace ejmabunda_web_api.Services;

/// <summary>Business logic for <see cref="Skill"/> entries, between the controller and the repository.</summary>
public interface ISkillService
{
    Task<List<Skill>> GetAllSkillsAsync();
    Task<Skill?> GetSkillByIdAsync(Guid id);

    /// <summary>Creates a skill. Returns <see langword="null"/> if <see cref="SkillAddDto.SkillCategory"/> is not a defined value.</summary>
    Task<Skill?> AddSkillAsync(SkillAddDto skillDto);

    /// <summary>Updates a skill. Returns <see langword="null"/> if no skill has that id, or the supplied category is not a defined value.</summary>
    Task<Skill?> UpdateSkillAsync(SkillUpdateDto skillDto);

    /// <summary>Deletes a skill. Returns <see langword="null"/> if no skill has that id.</summary>
    Task<Skill?> DeleteSkillAsync(Guid id);
}