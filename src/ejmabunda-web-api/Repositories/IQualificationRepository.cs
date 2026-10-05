using ejmabunda_web_api.Models;

namespace ejmabunda_web_api.Repositories;

/// <summary>Data access for <see cref="Qualification"/> rows and their <see cref="QualificationSkill"/> join rows.</summary>
public interface IQualificationRepository
{
    /// <summary>Returns every qualification (newest first), each with its skills loaded.</summary>
    Task<List<Qualification>> GetAllQualificationsAsync();
    Task<Qualification> AddQualificationAsync(Qualification qualification);

    /// <summary>
    /// Gets one qualification with its skills. Pass <paramref name="asNoTracking"/> =
    /// <see langword="false"/> when the caller will modify the returned entity and save it.
    /// </summary>
    Task<Qualification?> GetQualificationByIdAsync(Guid id, bool asNoTracking = true);

    /// <summary>Saves pending changes on a tracked qualification (including added/removed skill links).</summary>
    Task<Qualification> UpdateQualificationAsync(Qualification qualification);

    /// <summary>Removes the qualification with the given id. Returns <see langword="null"/> if it doesn't exist.</summary>
    Task<Qualification?> DeleteQualificationAsync(Guid id);
}
