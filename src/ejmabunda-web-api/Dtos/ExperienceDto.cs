using ejmabunda_web_api.Models;

namespace ejmabunda_web_api.Dtos;

/// <summary>API representation of an <see cref="Experience"/> with its linked skills.</summary>
public class ExperienceDto
{
    public Guid Id { get; set; }
    public required string JobTitle { get; set; }
    public required string Employer { get; set; }
    public required DateTime StartDate { get; set; }

    /// <summary>Null while the role is ongoing.</summary>
    public DateTime? EndDate { get; set; }
    public required string Description { get; set; }
    public required List<SkillDto> Skills { get; set; }
}

/// <summary>Request body for creating an <see cref="Experience"/>.</summary>
public class ExperienceAddDto
{
    public required string JobTitle { get; set; }
    public required string Employer { get; set; }
    public required DateTime StartDate { get; set; }

    /// <summary>Null while the role is ongoing.</summary>
    public DateTime? EndDate { get; set; }
    public required string Description { get; set; }
    public required List<Guid> SkillIds { get; set; }
}

/// <summary>Request body for updating an <see cref="Experience"/>. Null scalar fields are left unchanged.</summary>
public class ExperienceUpdateDto
{
    public string? JobTitle { get; set; }
    public string? Employer { get; set; }
    public DateTime? StartDate { get; set; }

    /// <summary>Null while the role is ongoing.</summary>
    public DateTime? EndDate { get; set; }
    public string? Description { get; set; }

    /// <summary>
    /// Skills linked to this experience. <c>null</c> (or omitted) leaves the existing
    /// links untouched; an empty list removes them all; a populated list mirrors it
    /// exactly (adds what's missing, removes what's not listed).
    /// </summary>
    public List<Guid>? SkillIds { get; set; }
}
