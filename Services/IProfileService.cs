using ejmabunda_web_api.Models;

namespace ejmabunda_web_api.Services;

public interface IProfileService
{
    Task<Profile?> AddProfileAsync(ProfileAddDto profileDto);
}