namespace ejmabunda_web_api.Repositories;
using ejmabunda_web_api.Models;

/// <summary>Data access for the singleton <see cref="Profile"/> row.</summary>
public interface IProfileRepository
{
    /// <summary>Returns the profile, or <see langword="null"/> if it hasn't been created yet.</summary>
    Task<Profile?> GetProfileAsync();

    /// <summary>
    /// Creates the profile. Returns <see langword="null"/> instead of throwing if a profile
    /// already exists (enforced by the database's unique/primary key constraint).
    /// </summary>
    Task<Profile?> AddProfileAsync(ProfileAddDto profileDto);

    /// <summary>Applies the non-null fields of <paramref name="profileDto"/> to <paramref name="profile"/> and saves.</summary>
    Task<Profile> UpdateProfileAsync(Profile profile, ProfilePutDto profileDto);

    /// <summary>Removes the given profile row.</summary>
    Task<Profile?> DeleteProfileAsync(Profile profile);
}
