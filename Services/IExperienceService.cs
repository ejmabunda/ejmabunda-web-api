using ejmabunda_web_api.Dtos;
using ejmabunda_web_api.Models;

namespace ejmabunda_web_api.Services;

public interface IExperienceService
{
    Task<List<Experience>> GetAllExperiencesAsync();
    Task<Experience> AddExperienceAsync(ExperienceDto experienceDto);
}