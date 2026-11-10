namespace ejmabunda_web_api.Models;

/// <summary>
/// The single owner profile shown on the portfolio site (name/headline copy).
/// Modeled as a singleton: <see cref="Id"/> defaults to 1 and
/// <see cref="PortfolioContext.OnModelCreating"/> stops the database generating it, so a
/// second insert hits the primary key and only one row ever exists.
/// </summary>
public class Profile
{
    public int Id { get; set; } = 1;

    /// <summary>Main heading of the profile; the seed data uses the owner's name.</summary>
    public required string Title { get; set; }

    /// <summary>Short tagline shown under the title, e.g. "Junior Software Developer, C# / .NET".</summary>
    public required string Headline { get; set; }

    /// <summary>Supporting text shown under the headline.</summary>
    public required string Subtitle { get; set; }
}
