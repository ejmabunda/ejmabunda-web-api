namespace ejmabunda_web_api.Models;

/// <summary>
/// The single admin user that can authenticate against the API. Modeled as a singleton
/// (<see cref="Id"/> fixed at 1 via <see cref="PortfolioContext.OnModelCreating"/>);
/// only the password hash is stored, and the row is seeded at migration time.
/// </summary>
public class User
{
    public int Id { get; set; } = 1;
    public required string Username { get; set; }

    /// <summary>ASP.NET Core Identity <c>PasswordHasher</c> output for the admin password.</summary>
    public required string PasswordHash { get; set; }

    /// <summary>Login sessions opened for this user.</summary>
    public List<Session> Sessions { get; set; } = null!;
}