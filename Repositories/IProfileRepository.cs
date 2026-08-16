namespace ejmabunda_web_api.Repositories;
using ejmabunda_web_api.Models;

public interface IProfileRepository
{
    Task<Profile?> GetProfileAsync();
    Task<Profile?> AddProfileAsync(ProfileAddDto profileDto);
}