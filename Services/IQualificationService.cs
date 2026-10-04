using ejmabunda_web_api.Dtos;
using ejmabunda_web_api.Exceptions;
using ejmabunda_web_api.Models;

namespace ejmabunda_web_api.Services;

/// <summary>
/// Business logic for <see cref="Qualification"/> entries: maps between DTOs and entities,
/// validates linked skill ids, and reconciles the qualification-to-skill join rows.
/// </summary>
public interface IQualificationService
{
    Task<QualificationDto?> GetQualificationByIdAsync(Guid id);
    Task<List<QualificationDto>> GetAllQualificationsAsync();

    /// <summary>Creates a qualification. Throws <see cref="InvalidSkillIdsException"/> if any skill id is unknown.</summary>
    Task<QualificationDto> AddQualificationAsync(QualificationAddDto qualificationAddDto);

    /// <summary>
    /// Updates a qualification. Returns <see langword="null"/> if no qualification has that id.
    /// Throws <see cref="InvalidSkillIdsException"/> if any supplied skill id is unknown.
    /// See <see cref="QualificationUpdateDto.SkillIds"/> for link-reconciliation semantics.
    /// </summary>
    Task<QualificationDto?> UpdateQualificationAsync(Guid id, QualificationUpdateDto qualificationUpdateDto);

    /// <summary>Deletes a qualification. Returns <see langword="false"/> if no qualification has that id.</summary>
    Task<bool> DeleteQualificationAsync(Guid id);
}
