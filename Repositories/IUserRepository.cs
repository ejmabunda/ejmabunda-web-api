using ejmabunda_web_api.Models;

namespace ejmabunda_web_api.Repositories;

public interface IUserRepository
{
    Task<User?> GetUserAsync();
    Task<User?> UpdateUserAsync(UserDto userDto, User user);
}