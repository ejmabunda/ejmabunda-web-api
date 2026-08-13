namespace ejmabunda_web_api.Models;

public class Qualification
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Institution { get; set; }
    public required DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public required NqfLevel NqfLevel { get; set; }
}

public class QualificationSkill
{
    public Guid Id { get; set; }
    public Guid QualificationId { get; set; }
    public Guid SkillId { get; set; }
    public Qualification Qualification { get; set; } = null!;
    public Skill Skill { get; set; } = null!;
}