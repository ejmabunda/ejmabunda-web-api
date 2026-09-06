using ejmabunda_web_api.Dtos;
using ejmabunda_web_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace ejmabunda_web_api.Services;

public interface IExperienceService
{
    Task<ExperienceDto?> GetExperienceByIdAsync(Guid id);
    Task<List<ExperienceDto>> GetAllExperiencesAsync();
    Task<ExperienceDto> AddExperienceAsync(ExperienceAddDto experienceDto);
    Task<ExperienceDto?> UpdateExperienceAsync(Guid id, ExperienceUpdateDto experienceUpdateDto);
    Task<bool> DeleteExperienceAsync(Guid id);
}