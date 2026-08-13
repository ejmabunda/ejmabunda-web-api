namespace ejmabunda_web_api.Models;

public class Project
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Url { get; set; }
}

public class ProjectSkill
{
    public Guid Id { get; set; }
    public Guid ProjectId { get; set; }
    public Guid SkillId { get; set; }
    public Project Project { get; set; } = null!;
    public Skill Skill { get; set; } = null!;
}