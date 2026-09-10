using ejmabunda_web_api.Dtos;
using ejmabunda_web_api.Exceptions;
using ejmabunda_web_api.Models;
using ejmabunda_web_api.Repositories;

namespace ejmabunda_web_api.Services;

/// <inheritdoc cref="IExperienceService"/>
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

    public async Task<ExperienceDto> AddExperienceAsync(ExperienceAddDto experienceAddDto)
    {
        experienceAddDto.SkillIds = [.. experienceAddDto.SkillIds.Distinct()];
        var allSkills = await _skillRepository.GetAllSkillsAsync();
        if (!SkillsAreValid(experienceAddDto.SkillIds, allSkills))
            throw new InvalidSkillIdsException("One or more skill ids do not exist.");

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
                .Contains(s.Id)).OrderBy(es => es.Name)
                .Select(s => new SkillDto { Id = s.Id, Name = s.Name, SkillCategory = s.SkillCategory.ToString() })]
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
                Skills = MapSkillDomainToDto(e)
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
            Skills = MapSkillDomainToDto(experience)
        };

        return experienceDto;
    }

    public async Task<ExperienceDto?> UpdateExperienceAsync(
        Guid id, ExperienceUpdateDto experienceUpdateDto)
    {
        var experience = await _experienceRepository.GetExperienceByIdAsync(id, false);
        if (experience == null) return null;

        experience.JobTitle = experienceUpdateDto.JobTitle ?? experience.JobTitle;
        experience.Employer = experienceUpdateDto.Employer ?? experience.Employer;
        experience.StartDate = experienceUpdateDto.StartDate ?? experience.StartDate;
        experience.EndDate = experienceUpdateDto.EndDate ?? experience.EndDate;
        experience.Description = experienceUpdateDto.Description ?? experience.Description;

        // SkillIds: null => leave links untouched; [] => clear all; populated => mirror it.
        if (experienceUpdateDto.SkillIds != null)
        {
            var targetSkillIds = experienceUpdateDto.SkillIds.Distinct().ToList();

            var allSkills = await _skillRepository.GetAllSkillsAsync();
            if (!SkillsAreValid(targetSkillIds, allSkills))
                throw new InvalidSkillIdsException("One or more skill ids do not exist.");

            var existingSkillIds = experience.ExperienceSkills
                .Select(es => es.SkillId).ToList();

            // Symmetric difference: an id on exactly one side needs to change.
            var changedSkillIds = existingSkillIds
                .Except(targetSkillIds)
                .Union(targetSkillIds.Except(existingSkillIds))
                .ToList();

            foreach (var skillId in changedSkillIds)
            {
                if (targetSkillIds.Contains(skillId))
                {
                    experience.ExperienceSkills.Add(new ExperienceSkill
                    {
                        ExperienceId = experience.Id,
                        SkillId = skillId,
                    });
                }
                else
                {
                    var toRemove = experience.ExperienceSkills
                        .First(es => es.SkillId == skillId);
                    experience.ExperienceSkills.Remove(toRemove);
                }
            }
        }

        await _experienceRepository.UpdateExperienceAsync(experience);

        // Re-read so newly linked skills come back with their Skill data populated,
        // rather than relying on EF navigation fix-up after SaveChanges.
        var saved = await _experienceRepository.GetExperienceByIdAsync(experience.Id);

        return new ExperienceDto()
        {
            Id = saved!.Id,
            JobTitle = saved.JobTitle,
            Employer = saved.Employer,
            StartDate = saved.StartDate,
            EndDate = saved.EndDate,
            Description = saved.Description,
            Skills = MapSkillDomainToDto(saved)
        };
    }

    private static bool SkillsAreValid(List<Guid> skillIds, List<Skill> skills)
    {
        var known = skills.Select(s => s.Id).ToHashSet();
        return skillIds.All(known.Contains);
    }

    private static List<SkillDto> MapSkillDomainToDto(Experience experience)
    {
        return [.. experience.ExperienceSkills
            .Select(es => new SkillDto {
                Id = es.Skill.Id,
                Name = es.Skill.Name,
                SkillCategory = es.Skill.SkillCategory.ToString()
            }).OrderBy(es => es.Name)];
    }

    public async Task<bool> DeleteExperienceAsync(Guid id)
    {
        var experience = await _experienceRepository.DeleteExperienceAsync(id);
        if (experience == null) return false;
        return true;
    }
}