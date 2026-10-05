using ejmabunda_web_api.Dtos;
using ejmabunda_web_api.Exceptions;
using ejmabunda_web_api.Models;
using ejmabunda_web_api.Repositories;

namespace ejmabunda_web_api.Services;

/// <inheritdoc cref="IQualificationService"/>
public class QualificationService : IQualificationService
{
    private readonly IQualificationRepository _qualificationRepository;
    private readonly ISkillRepository _skillRepository;

    public QualificationService(IQualificationRepository qualificationRepository,
        ISkillRepository skillRepository)
    {
        _qualificationRepository = qualificationRepository;
        _skillRepository = skillRepository;
    }

    public async Task<QualificationDto> AddQualificationAsync(QualificationAddDto qualificationAddDto)
    {
        qualificationAddDto.SkillIds = [.. qualificationAddDto.SkillIds.Distinct()];
        var allSkills = await _skillRepository.GetAllSkillsAsync();
        if (!SkillsAreValid(qualificationAddDto.SkillIds, allSkills))
            throw new InvalidSkillIdsException("One or more skill ids do not exist.");

        var qualification = new Qualification()
        {
            Name = qualificationAddDto.Name,
            Institution = qualificationAddDto.Institution,
            StartDate = qualificationAddDto.StartDate,
            EndDate = qualificationAddDto.EndDate,
            NqfLevel = qualificationAddDto.NqfLevel,
            Skills = [.. qualificationAddDto.SkillIds
                .Select(id => new QualificationSkill { SkillId = id })]
        };

        qualification = await _qualificationRepository.AddQualificationAsync(qualification);

        return new QualificationDto()
        {
            Id = qualification.Id,
            Name = qualification.Name,
            Institution = qualification.Institution,
            StartDate = qualification.StartDate,
            EndDate = qualification.EndDate,
            NqfLevel = qualification.NqfLevel.ToString(),
            Skills = [.. allSkills
                .Where(s => qualificationAddDto.SkillIds
                .Contains(s.Id)).OrderBy(s => s.Name)
                .Select(s => new SkillDto { Id = s.Id, Name = s.Name, SkillCategory = s.SkillCategory.ToString() })]
        };
    }

    public async Task<List<QualificationDto>> GetAllQualificationsAsync()
    {
        var qualifications = await _qualificationRepository.GetAllQualificationsAsync();

        return
        [.. qualifications.Select(q => new QualificationDto
            {
                Id = q.Id,
                Name = q.Name,
                Institution = q.Institution,
                StartDate = q.StartDate,
                EndDate = q.EndDate,
                NqfLevel = q.NqfLevel.ToString(),
                Skills = MapSkillDomainToDto(q)
            })
        ];
    }

    public async Task<QualificationDto?> GetQualificationByIdAsync(Guid id)
    {
        var qualification = await _qualificationRepository.GetQualificationByIdAsync(id);
        if (qualification == null) return null;

        return new QualificationDto()
        {
            Id = qualification.Id,
            Name = qualification.Name,
            Institution = qualification.Institution,
            StartDate = qualification.StartDate,
            EndDate = qualification.EndDate,
            NqfLevel = qualification.NqfLevel.ToString(),
            Skills = MapSkillDomainToDto(qualification)
        };
    }

    public async Task<QualificationDto?> UpdateQualificationAsync(
        Guid id, QualificationUpdateDto qualificationUpdateDto)
    {
        var qualification = await _qualificationRepository.GetQualificationByIdAsync(id, false);
        if (qualification == null) return null;

        qualification.Name = qualificationUpdateDto.Name ?? qualification.Name;
        qualification.Institution = qualificationUpdateDto.Institution ?? qualification.Institution;
        qualification.StartDate = qualificationUpdateDto.StartDate ?? qualification.StartDate;
        qualification.EndDate = qualificationUpdateDto.EndDate;
        qualification.NqfLevel = qualificationUpdateDto.NqfLevel ?? qualification.NqfLevel;

        // SkillIds: null => leave links untouched; [] => clear all; populated => mirror it.
        if (qualificationUpdateDto.SkillIds != null)
        {
            var targetSkillIds = qualificationUpdateDto.SkillIds.Distinct().ToList();

            var allSkills = await _skillRepository.GetAllSkillsAsync();
            if (!SkillsAreValid(targetSkillIds, allSkills))
                throw new InvalidSkillIdsException("One or more skill ids do not exist.");

            var existingSkillIds = qualification.Skills
                .Select(qs => qs.SkillId).ToList();

            // Symmetric difference: an id on exactly one side needs to change.
            var changedSkillIds = existingSkillIds
                .Except(targetSkillIds)
                .Union(targetSkillIds.Except(existingSkillIds))
                .ToList();

            foreach (var skillId in changedSkillIds)
            {
                if (targetSkillIds.Contains(skillId))
                {
                    qualification.Skills.Add(new QualificationSkill
                    {
                        QualificationId = qualification.Id,
                        SkillId = skillId,
                    });
                }
                else
                {
                    var toRemove = qualification.Skills
                        .First(qs => qs.SkillId == skillId);
                    qualification.Skills.Remove(toRemove);
                }
            }
        }

        await _qualificationRepository.UpdateQualificationAsync(qualification);

        // Re-read so newly linked skills come back with their Skill data populated,
        // rather than relying on EF navigation fix-up after SaveChanges.
        var saved = await _qualificationRepository.GetQualificationByIdAsync(qualification.Id);

        return new QualificationDto()
        {
            Id = saved!.Id,
            Name = saved.Name,
            Institution = saved.Institution,
            StartDate = saved.StartDate,
            EndDate = saved.EndDate,
            NqfLevel = saved.NqfLevel.ToString(),
            Skills = MapSkillDomainToDto(saved)
        };
    }

    public async Task<bool> DeleteQualificationAsync(Guid id)
    {
        var qualification = await _qualificationRepository.DeleteQualificationAsync(id);
        return qualification != null;
    }

    private static bool SkillsAreValid(List<Guid> skillIds, List<Skill> skills)
    {
        var known = skills.Select(s => s.Id).ToHashSet();
        return skillIds.All(known.Contains);
    }

    private static List<SkillDto> MapSkillDomainToDto(Qualification qualification)
    {
        return [.. qualification.Skills
            .Select(qs => new SkillDto {
                Id = qs.Skill.Id,
                Name = qs.Skill.Name,
                SkillCategory = qs.Skill.SkillCategory.ToString()
            }).OrderBy(s => s.Name)];
    }
}
