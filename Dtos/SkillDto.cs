using ejmabunda_web_api.Models;

namespace ejmabunda_web_api.Dtos;

public class SkillAddDto
{
    public required string Name { get; set; }
    public required SkillCategory SkillCategory { get; set; }
}

public class SkillUpdateDto
{
    public required Guid Id { get; set; }
    public string? Name { get; set; }
    public SkillCategory? SkillCategory { get; set; }
}

public class SkillDto
{
    public required Guid Id { get; set; }
    public string? Name { get; set; }
    public string? SkillCategory { get; set; }
}
