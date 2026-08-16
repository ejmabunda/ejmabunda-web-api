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
}