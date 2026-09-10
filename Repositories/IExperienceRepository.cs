using ejmabunda_web_api.Dtos;
using ejmabunda_web_api.Models;

namespace ejmabunda_web_api.Repositories;

/// <summary>Data access for <see cref="Experience"/> rows and their <see cref="ExperienceSkill"/> join rows.</summary>
public interface IExperienceRepository
{
    /// <summary>Returns every experience (newest first), each with its skills loaded.</summary>
    Task<List<Experience>> GetAllExperiencesAsync();
    Task<Experience> AddExperienceAsync(Experience experience);

    /// <summary>
    /// Gets one experience with its skills. Pass <paramref name="asNoTracking"/> =
    /// <see langword="false"/> when the caller will modify the returned entity and save it.
    /// </summary>
    Task<Experience?> GetExperienceByIdAsync(Guid id, bool asNoTracking = true);

    /// <summary>Saves pending changes on a tracked experience (including added/removed skill links).</summary>
    Task<Experience> UpdateExperienceAsync(Experience experience);

    /// <summary>Removes the experience with the given id. Returns <see langword="null"/> if it doesn't exist.</summary>
    Task<Experience?> DeleteExperienceAsync(Guid id);
}