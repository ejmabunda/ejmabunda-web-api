namespace ejmabunda_web_api.Models;

public class Profile
{
    public int Id { get; set; } = 1;
    public required string Title { get; set; }
    public required string Headline { get; set; }
    public required string Subtitle { get; set; }
}