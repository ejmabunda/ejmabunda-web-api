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

    public async Task<ExperienceDto?> AddExperienceAsync(ExperienceAddDto experienceAddDto)
    {
        experienceAddDto.SkillIds = [.. experienceAddDto.SkillIds.Distinct()];
        var allSkills = await _skillRepository.GetAllSkillsAsync();
        if (!ValidateSkillIds(experienceAddDto.SkillIds, allSkills))
            return null;

        var experience = new Experience()
        {
            JobTitle = experienceAddDto.JobTitle,
            Employer = experienceAddDto.Employer,
            StartDate = experienceAddDto.StartDate,
            EndDate = experienceAddDto.EndDate,
            Description = experienceAddDto.Description,
            ExperienceSkills = [.. experienceAddDto.SkillIds
                .Select(id => new ExperienceSkill { SkillId = id })]
        };

        experience = await _experienceRepository.AddExperienceAsync(experience);

        var experienceDto = new ExperienceDto()
        {
            Id = experience.Id,
            JobTitle = experience.JobTitle,
            Employer = experience.Employer,
            StartDate = experience.StartDate,
            EndDate = experience.EndDate,
            Description = experience.Description,
            Skills = [.. allSkills
                .Where(s => experienceAddDto.SkillIds
                .Contains(s.Id))
                .Select(s => new SkillDto { Id = s.Id, Name = s.Name, SkillCategory = s.SkillCategory.ToString() })
                .OrderBy(es => es.SkillCategory).OrderBy(es => es.Name)]
        };

        return experienceDto;
    }

    public async Task<List<ExperienceDto>> GetAllExperiencesAsync()
    {
        var experiences = await _experienceRepository.GetAllExperiencesAsync();

        return
        [.. experiences.Select(e => new ExperienceDto
            {
                Id = e.Id,
                JobTitle = e.JobTitle,
                Employer = e.Employer,
                StartDate = e.StartDate,
                EndDate = e.EndDate,
                Description = e.Description,
                Skills = [.. e.ExperienceSkills
                .Select(es => new SkillDto {
                    Id = es.Skill.Id,
                    Name = es.Skill.Name,
                    SkillCategory = es.Skill.SkillCategory.ToString()
                }).OrderBy(es => es.SkillCategory).OrderBy(es => es.Name)]
            })
        ];
    }

    public async Task<ExperienceDto?> GetExperienceByIdAsync(Guid id)
    {
        var experience = await _experienceRepository.GetExperienceByIdAsync(id);
        if (experience == null) return null;

        var experienceDto = new ExperienceDto()
        {
            Id = experience.Id,
            JobTitle = experience.JobTitle,
            Employer = experience.Employer,
            StartDate = experience.StartDate,
            EndDate = experience.EndDate,
            Description = experience.Description,
            Skills = [.. experience.ExperienceSkills
                .Select(es => new SkillDto {
                    Id = es.Skill.Id,
                    Name = es.Skill.Name,
                    SkillCategory = es.Skill.SkillCategory.ToString()
                }).OrderBy(es => es.SkillCategory).OrderBy(es => es.Name)]
        };

        return experienceDto;
    }

    private bool ValidateSkillIds(List<Guid> skillIds, List<Skill> skills)
    {
        var known = skills.Select(s => s.Id).ToHashSet();
        return skillIds
            .All(known.Contains);
    }
}