using ejmabunda_web_api.Models;

namespace ejmabunda_web_api.Dtos;

/// <summary>Request body for creating a <see cref="Skill"/>.</summary>
public class SkillAddDto
{
    public required string Name { get; set; }
    public required SkillCategory SkillCategory { get; set; }
}

/// <summary>Request body for updating a <see cref="Skill"/>. <see cref="Id"/> is required; null fields are left unchanged.</summary>
public class SkillUpdateDto
{
    public required Guid Id { get; set; }
    public string? Name { get; set; }
    public SkillCategory? SkillCategory { get; set; }
}

/// <summary>API representation of a <see cref="Skill"/>. <see cref="SkillCategory"/> is the enum name (e.g. <c>"Platform"</c>).</summary>
public class SkillDto
{
    public required Guid Id { get; set; }
    public string? Name { get; set; }
    public string? SkillCategory { get; set; }
}
