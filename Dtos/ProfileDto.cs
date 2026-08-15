public class ProfileAddDto
{
    public required string Title { get; set; }
    public required string Headline { get; set; }
    public required string Subtitle { get; set; }
}

public class ProfilePutDto
{
    public string? Title { get; set; }
    public string? Headline { get; set; }
    public string? Subtitle { get; set; }
}
