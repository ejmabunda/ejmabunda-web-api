using ejmabunda_web_api.Dtos;
using ejmabunda_web_api.Exceptions;
using ejmabunda_web_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace ejmabunda_web_api.Services;

/// <summary>
/// Business logic for <see cref="Experience"/> entries: maps between DTOs and entities,
/// validates linked skill ids, and reconciles the experience-to-skill join rows.
/// </summary>
public interface IExperienceService
{
    Task<ExperienceDto?> GetExperienceByIdAsync(Guid id);
    Task<List<ExperienceDto>> GetAllExperiencesAsync();

    /// <summary>Creates an experience. Throws <see cref="InvalidSkillIdsException"/> if any skill id is unknown.</summary>
    Task<ExperienceDto> AddExperienceAsync(ExperienceAddDto experienceDto);

    /// <summary>
    /// Updates an experience. Returns <see langword="null"/> if no experience has that id.
    /// Throws <see cref="InvalidSkillIdsException"/> if any supplied skill id is unknown.
    /// See <see cref="ExperienceUpdateDto.SkillIds"/> for link-reconciliation semantics.
    /// </summary>
    Task<ExperienceDto?> UpdateExperienceAsync(Guid id, ExperienceUpdateDto experienceUpdateDto);

    /// <summary>Deletes an experience. Returns <see langword="false"/> if no experience has that id.</summary>
    Task<bool> DeleteExperienceAsync(Guid id);
}