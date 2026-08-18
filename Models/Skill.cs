namespace ejmabunda_web_api.Models;

/// <summary>
/// A skill or technology that can be linked to <see cref="Experience"/>,
/// <see cref="Qualification"/>, <see cref="Project"/>, and <see cref="Certification"/> entries.
/// </summary>
public class Skill
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required SkillCategory SkillCategory { get; set; }
}

/// <summary>Grouping used to organize skills on the portfolio site.</summary>
public enum SkillCategory
{
    LanguagesAndBackend,
    SystemsAndData,
    Platform,
    TestingAndReliability,
    CloudAndDevOps,
}
