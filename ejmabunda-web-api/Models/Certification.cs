namespace ejmabunda_web_api.Models;

/// <summary>A professional certification (name, issuer, and verification link).</summary>
public class Certification
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Url { get; set; }
    public required string IssuingOrganization { get; set; }
    public required DateTime IssueDate { get; set; }
}

/// <summary>Join entity linking a <see cref="Certification"/> to a <see cref="Skill"/> it covers.</summary>
public class CertificationSkill
{
    public Guid Id { get; set; }
    public Guid CertificationId { get; set; }
    public Guid SkillId { get; set; }
    public Certification Certification { get; set; } = null!;
    public Skill Skill { get; set; } = null!;
}
