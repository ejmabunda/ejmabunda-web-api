namespace ejmabunda_web_api.Models;

/// <summary>A work history entry (job title, employer, and dates).</summary>
public class Experience
{
    public Guid Id { get; set; }
    public required string JobTitle { get; set; }
    public required string Employer { get; set; }
    public required DateTime StartDate { get; set; }

    /// <summary>Null while the role is ongoing.</summary>
    public DateTime? EndDate { get; set; }
    public required string Description { get; set; }
}

/// <summary>Join entity linking an <see cref="Experience"/> to a <see cref="Skill"/> used in that role.</summary>
public class ExperienceSkill
{
    public Guid Id { get; set; }
    public Guid ExperienceId { get; set; }
    public Guid SkillId { get; set; }
    public Experience Experience { get; set; } = null!;
    public Skill Skill { get; set; } = null!;
}
