namespace ejmabunda_web_api.Models;

/// <summary>
/// The single owner profile shown on the portfolio site (name/headline copy).
/// Modeled as a singleton: <see cref="Id"/> always defaults to and is pinned at 1
/// via <see cref="PortfolioContext.OnModelCreating"/>, so only one row ever exists.
/// </summary>
public class Profile
{
    public int Id { get; set; } = 1;

    /// <summary>Professional title, e.g. "Software Engineer".</summary>
    public required string Title { get; set; }

    /// <summary>Short tagline shown alongside the title.</summary>
    public required string Headline { get; set; }

    /// <summary>Supporting text shown under the headline.</summary>
    public required string Subtitle { get; set; }
}
