using ejmabunda_web_api.Models;
using Microsoft.EntityFrameworkCore;

namespace ejmabunda_web_api.Repositories;

public class UserRepository : IUserRepository
{
    private readonly PortfolioContext _context;

    public UserRepository(PortfolioContext context)
    {
        _context = context;
    }

    public async Task<User?> GetUserAsync()
    {
        return await _context.Users.FirstOrDefaultAsync();
    }

    public async Task<User?> UpdateUserAsync(UserDto userDto, User user)
    {
        user.PasswordHash = userDto.PasswordHash ?? user.PasswordHash;
        await _context.SaveChangesAsync();

        return user;
    }
}