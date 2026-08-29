using ejmabunda_web_api.Models;

namespace ejmabunda_web_api.Services;

public interface IUserService
{
    Task<User?> GetUserAsync();
    Task<User?> UpdateUserAsync(UserDto userDto, User user);
}