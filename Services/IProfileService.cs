using ejmabunda_web_api.Models;

namespace ejmabunda_web_api.Services;

/// <summary>Business logic for the profile, sitting between <see cref="Controllers.ProfileController"/> and the repository layer.</summary>
public interface IProfileService
{
    /// <summary>
    /// Creates the profile. Returns <see langword="null"/> if a profile already exists,
    /// since the profile is a singleton (see <see cref="Profile"/>).
    /// </summary>
    Task<Profile?> AddProfileAsync(ProfileAddDto profileDto);

    /// <summary>
    /// Updates the profile, leaving fields omitted from <paramref name="profileDto"/>
    /// unchanged. Returns <see langword="null"/> if no profile exists yet.
    /// </summary>
    Task<Profile?> UpdateProfileAsync(ProfilePutDto profileDto);

    /// <summary>Deletes the profile. Returns <see langword="null"/> if no profile exists.</summary>
    Task<Profile?> DeleteProfileAsync();
}
