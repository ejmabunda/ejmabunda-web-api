using ejmabunda_web_api.Dtos;
using ejmabunda_web_api.Models;
using ejmabunda_web_api.Repositories;

namespace ejmabunda_web_api.Services;

public class SkillService : ISkillService
{
    private readonly ISkillRepository _skillRepository;

    public SkillService(ISkillRepository skillRepository)
    {
        _skillRepository = skillRepository;
    }

    public async Task<List<Skill>> GetAllSkillsAsync()
    {
        return await _skillRepository.GetAllSkillsAsync();
    }

    public async Task<Skill?> AddSkillAsync(SkillAddDto skillDto)
    {
        if (!Enum.IsDefined(typeof(SkillCategory), skillDto.SkillCategory))
            return null;

        return await _skillRepository.AddSkillAsync(skillDto);
    }

    public async Task<Skill?> UpdateSkillAsync(SkillUpdateDto skillDto)
    {
        if (
            skillDto.SkillCategory != null &&
            !Enum.IsDefined(typeof(SkillCategory), skillDto.SkillCategory))
            return null;

        var skill = await _skillRepository.GetSkillByIdAsync(skillDto.Id);
        if (skill == null) return null;

        skill = await _skillRepository.UpdateSkillAsync(skillDto, skill);
        return skill;
    }

    public async Task<Skill?> DeleteSkillAsync(Guid id)
    {
        var skill = await _skillRepository.GetSkillByIdAsync(id);
        if (skill == null) return null;

        return await _skillRepository.DeleteSkillAsync(skill);
    }

    public async Task<Skill?> GetSkillByIdAsync(Guid id)
    {
        var skill = await _skillRepository.GetSkillByIdAsync(id);
        return skill;
    }
}
