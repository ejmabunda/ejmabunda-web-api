using ejmabunda_web_api.Models;

/// <summary>Fields that can be updated on the admin <see cref="User"/>; null values are ignored.</summary>
public class UserDto
{
    public string? PasswordHash { get; set; }
    public List<Session>? Sessions { get; set; }
}