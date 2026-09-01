using ejmabunda_web_api.Dtos;
using ejmabunda_web_api.Models;

namespace ejmabunda_web_api.Repositories;

public interface IExperienceRepository
{
    Task<List<Experience>> GetAllExperiencesAsync();
    Task<Experience> AddExperienceAsync(Experience experience);
    Task<Experience?> GetExperienceByIdAsync(Guid id);
}