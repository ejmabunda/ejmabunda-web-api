using ejmabunda_web_api.Models;

public class UserDto
{
    public string? PasswordHash { get; set; }
    public List<Session>? Sessions { get; set; }
}