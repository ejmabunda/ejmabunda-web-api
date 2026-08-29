using ejmabunda_web_api.Models;
using ejmabunda_web_api.Repositories;

namespace ejmabunda_web_api.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User?> GetUserAsync()
    {
        return await _userRepository.GetUserAsync();
    }

    public async Task<User?> UpdateUserAsync(UserDto userDto, User user)
    {
        return await _userRepository.UpdateUserAsync(userDto, user);
    }
}