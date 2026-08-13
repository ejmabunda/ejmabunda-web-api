namespace ejmabunda_web_api.Models;

public class Experience
{
    public Guid Id { get; set; }
    public required string JobTitle { get; set; }
    public required string Employer { get; set; }
    public required DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public required string Description { get; set; }
}

public class ExperienceSkill
{
    public Guid Id { get; set; }
    public Guid ExperienceId { get; set; }
    public Guid SkillId { get; set; }
    public Experience Experience { get; set; } = null!;
    public Skill Skill { get; set; } = null!;
}