using ejmabunda_web_api.Dtos;
using ejmabunda_web_api.Filters;
using ejmabunda_web_api.Models;
using ejmabunda_web_api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ejmabunda_web_api.Controllers;

/// <summary>
/// CRUD API for <see cref="Qualification"/> entries, including the set of
/// <see cref="Skill"/> ids linked to each one. Reads are public; writes require a JWT
/// bearer token. A request referencing unknown skill ids is rejected with 400 by
/// <see cref="InvalidSkillIdsExceptionFilterAttribute"/>.
/// </summary>
[ApiController]
[Authorize]
[Route("api/[controller]")]
[InvalidSkillIdsExceptionFilter]
public class QualificationController : ControllerBase
{
    private readonly IQualificationService _qualificationService;

    public QualificationController(IQualificationService qualificationService)
    {
        _qualificationService = qualificationService;
    }

    /// <summary>Gets one qualification by id, with its linked skills.</summary>
    /// <response code="200">The qualification.</response>
    /// <response code="404">No qualification has that id.</response>
    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetQualificationByIdAsync([FromRoute] Guid id)
    {
        var qualification = await _qualificationService.GetQualificationByIdAsync(id);
        if (qualification == null) return NotFound();
        return Ok(qualification);
    }

    /// <summary>Lists all qualifications (newest first by start date), each with its linked skills.</summary>
    /// <response code="200">The qualifications (an empty array when there are none).</response>
    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetAllQualificationsAsync()
    {
        var qualifications = await _qualificationService.GetAllQualificationsAsync();
        return Ok(qualifications);
    }

    /// <summary>Creates a qualification and links it to the given skill ids.</summary>
    /// <response code="201">The created qualification, with a <c>Location</c> header.</response>
    /// <response code="400">One or more skill ids do not exist.</response>
    [HttpPost]
    public async Task<IActionResult> AddQualificationAsync(
        [FromBody] QualificationAddDto qualificationAddDto)
    {
        var qualification = await _qualificationService.AddQualificationAsync(qualificationAddDto);

        return CreatedAtAction("GetQualificationById", new { Id = qualification.Id }, qualification);
    }

    /// <summary>
    /// Updates a qualification. Scalar fields omitted from the body are left unchanged;
    /// see <see cref="QualificationUpdateDto.SkillIds"/> for how skill links are reconciled.
    /// </summary>
    /// <response code="200">The updated qualification.</response>
    /// <response code="400">The id is empty, or one or more skill ids do not exist.</response>
    /// <response code="404">No qualification has that id.</response>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateQualificationAsync(
        [FromRoute] Guid id, [FromBody] QualificationUpdateDto qualificationUpdateDto)
    {
        if (id == Guid.Empty) return BadRequest("Please provide a valid qualification Id.");

        var qualificationDto = await _qualificationService
            .UpdateQualificationAsync(id, qualificationUpdateDto);
        if (qualificationDto == null) return NotFound("Qualification does not exist on DB.");

        return Ok(qualificationDto);
    }

    /// <summary>Deletes a qualification by id.</summary>
    /// <response code="204">The qualification was deleted.</response>
    /// <response code="400">The id is empty.</response>
    /// <response code="404">No qualification has that id.</response>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteQualificationAsync([FromRoute] Guid id)
    {
        if (id == Guid.Empty) return BadRequest("Please provide a valid qualification Id.");
        var deleted = await _qualificationService.DeleteQualificationAsync(id);
        if (!deleted) return NotFound("Could not find a qualification with the provided id.");
        return NoContent();
    }
}
