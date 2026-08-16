/// <summary>Request body for creating the profile (all fields required).</summary>
public class ProfileAddDto
{
    public required string Title { get; set; }
    public required string Headline { get; set; }
    public required string Subtitle { get; set; }
}

/// <summary>Request body for updating the profile. Omitted/null fields leave the existing value unchanged.</summary>
public class ProfilePutDto
{
    public string? Title { get; set; }
    public string? Headline { get; set; }
    public string? Subtitle { get; set; }
}
