using ejmabunda_web_api.Models;

namespace ejmabunda_web_api.Services;

/// <summary>Read/update access to the single admin <see cref="User"/>.</summary>
public interface IUserService
{
    /// <summary>Returns the admin user, or <see langword="null"/> if none is seeded.</summary>
    Task<User?> GetUserAsync();

    /// <summary>Applies the non-null fields of <paramref name="userDto"/> to <paramref name="user"/> and saves.</summary>
    Task<User?> UpdateUserAsync(UserDto userDto, User user);
}