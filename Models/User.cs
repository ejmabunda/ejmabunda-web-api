namespace ejmabunda_web_api.Models;

public class User
{
    public int Id { get; set; } = 1;
    public required string Username { get; set; }
    public required string PasswordHash { get; set; }
    public List<Session> Sessions { get; set; } = null!;
}