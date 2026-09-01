using ejmabunda_web_api.Dtos;
using ejmabunda_web_api.Models;
using ejmabunda_web_api.Repositories;

namespace ejmabunda_web_api.Services;

public class ExperienceService : IExperienceService
{
    private readonly IExperienceRepository _experienceRepository;
    private readonly ISkillRepository _skillRepository;

    public ExperienceService(IExperienceRepository experienceRepository,
        ISkillRepository skillRepository)
    {
        _experienceRepository = experienceRepository;
        _skillRepository = skillRepository;
    }

    public async Task<Experience> AddExperienceAsync(ExperienceDto experienceDto)
    {
        var allSkills = await _skillRepository.GetAllSkillsAsync();

        var experience = new Experience()
        {
            JobTitle = experienceDto.JobTitle,
            Employer = experienceDto.Employer,
            StartDate = experienceDto.StartDate,
            EndDate = experienceDto.EndDate,
            Description = experienceDto.Description,
            ExperienceSkills = [.. experienceDto.SkillIds.Select(id => new ExperienceSkill { SkillId = id })]
        };

        experience = await _experienceRepository.AddExperienceAsync(experience);
        return experience;
    }

    public async Task<List<Experience>> GetAllExperiencesAsync()
    {
        var experienceDtos = await _experienceRepository.GetAllExperiencesAsync();
        return experienceDtos;
    }
}