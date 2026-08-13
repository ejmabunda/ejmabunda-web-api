namespace ejmabunda_web_api.Models;

public class Skill
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required SkillCategory SkillCategory { get; set; }
}
