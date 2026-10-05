using ejmabunda_web_api.Models;

namespace ejmabunda_web_api.Dtos;

/// <summary>API representation of a <see cref="Qualification"/> with its linked skills. <see cref="NqfLevel"/> is the enum name (e.g. <c>"Diploma"</c>).</summary>
public class QualificationDto
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Institution { get; set; }
    public required DateTime StartDate { get; set; }

    /// <summary>Null while the qualification is still in progress.</summary>
    public DateTime? EndDate { get; set; }
    public required string NqfLevel { get; set; }
    public required List<SkillDto> Skills { get; set; }
}

/// <summary>Request body for creating a <see cref="Qualification"/>.</summary>
public class QualificationAddDto
{
    public required string Name { get; set; }
    public required string Institution { get; set; }
    public required DateTime StartDate { get; set; }

    /// <summary>Null while the qualification is still in progress.</summary>
    public DateTime? EndDate { get; set; }
    public required NqfLevel NqfLevel { get; set; }
    public required List<Guid> SkillIds { get; set; }
}

/// <summary>Request body for updating a <see cref="Qualification"/>. Null scalar fields are left unchanged.</summary>
public class QualificationUpdateDto
{
    public string? Name { get; set; }
    public string? Institution { get; set; }
    public DateTime? StartDate { get; set; }

    /// <summary>Null while the qualification is still in progress.</summary>
    public DateTime? EndDate { get; set; }
    public NqfLevel? NqfLevel { get; set; }

    /// <summary>
    /// Skills linked to this qualification. <c>null</c> (or omitted) leaves the existing
    /// links untouched; an empty list removes them all; a populated list mirrors it
    /// exactly (adds what's missing, removes what's not listed).
    /// </summary>
    public List<Guid>? SkillIds { get; set; }
}
