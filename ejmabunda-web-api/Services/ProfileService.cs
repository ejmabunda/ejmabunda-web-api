using ejmabunda_web_api.Models;
using ejmabunda_web_api.Repositories;

namespace ejmabunda_web_api.Services;

/// <inheritdoc cref="IProfileService"/>
public class ProfileService : IProfileService
{
    private readonly IProfileRepository _repository;

    public ProfileService(IProfileRepository repository)
    {
        _repository = repository;
    }

    /// <inheritdoc/>
    public async Task<Profile?> AddProfileAsync(ProfileAddDto profileDto)
    {
        return await _repository.AddProfileAsync(profileDto);
    }

    public async Task<Profile?> UpdateProfileAsync(ProfilePutDto profileDto)
    {
        var profile = await _repository.GetProfileAsync();
        if (profile == null) return null;

        profile = await _repository.UpdateProfileAsync(profile, profileDto);
        return profile;
    }

    public async Task<Profile?> DeleteProfileAsync()
    {
        Profile? profile;
        profile = await _repository.GetProfileAsync();

        if (profile == null) return null;
        return await _repository.DeleteProfileAsync(profile);
    }
}
