using ejmabunda_web_api.Models;

namespace ejmabunda_web_api.Dtos;

public class ExperienceDto
{
    public Guid Id { get; set; }
    public required string JobTitle { get; set; }
    public required string Employer { get; set; }
    public required DateTime StartDate { get; set; }

    /// <summary>Null while the role is ongoing.</summary>
    public DateTime? EndDate { get; set; }
    public required string Description { get; set; }
    public required List<Guid> SkillIds { get; set; }
}