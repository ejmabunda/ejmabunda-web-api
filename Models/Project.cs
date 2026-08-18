namespace ejmabunda_web_api.Models;

/// <summary>A portfolio project (name and link to the live site/repo).</summary>
public class Project
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Url { get; set; }
}

/// <summary>Join entity linking a <see cref="Project"/> to a <see cref="Skill"/> used to build it.</summary>
public class ProjectSkill
{
    public Guid Id { get; set; }
    public Guid ProjectId { get; set; }
    public Guid SkillId { get; set; }
    public Project Project { get; set; } = null!;
    public Skill Skill { get; set; } = null!;
}
