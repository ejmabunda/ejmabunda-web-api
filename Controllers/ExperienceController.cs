using ejmabunda_web_api.Dtos;
using ejmabunda_web_api.Filters;
using ejmabunda_web_api.Models;
using ejmabunda_web_api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ejmabunda_web_api.Controllers;

/// <summary>
/// CRUD API for <see cref="Experience"/> (work-history) entries, including the set of
/// <see cref="Skill"/> ids linked to each role. Reads are public; writes require a JWT
/// bearer token. A request referencing unknown skill ids is rejected with 400 by
/// <see cref="InvalidSkillIdsExceptionFilterAttribute"/>.
/// </summary>
[ApiController]
[Authorize]
[Route("api/[controller]")]
[InvalidSkillIdsExceptionFilter]
public class ExperienceController : ControllerBase
{
    private readonly IExperienceService _experienceService;

    public ExperienceController(IExperienceService experienceService)
    {
        _experienceService = experienceService;
    }

    /// <summary>Gets one experience by id, with its linked skills.</summary>
    /// <response code="200">The experience.</response>
    /// <response code="404">No experience has that id.</response>
    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetExperienceByIdAsync([FromRoute] Guid id)
    {
        var experience = await _experienceService.GetExperienceByIdAsync(id);
        if (experience == null) return NotFound();
        return Ok(experience);
    }

    /// <summary>Lists all experiences (newest first by start date), each with its linked skills.</summary>
    /// <response code="200">The experiences (an empty array when there are none).</response>
    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetAllExperiencesAsync()
    {
        var experiences = await _experienceService.GetAllExperiencesAsync();
        return Ok(experiences);
    }

    /// <summary>Creates an experience and links it to the given skill ids.</summary>
    /// <response code="201">The created experience, with a <c>Location</c> header.</response>
    /// <response code="400">One or more skill ids do not exist.</response>
    [HttpPost]
    public async Task<IActionResult> AddExperienceAsync(
        [FromBody] ExperienceAddDto experienceAddDto)
    {
        var experience = await _experienceService.AddExperienceAsync(experienceAddDto);

        return CreatedAtAction("GetExperienceById", new { Id = experience.Id }, experience);
    }

    /// <summary>
    /// Updates an experience. Scalar fields omitted from the body are left unchanged;
    /// see <see cref="ExperienceUpdateDto.SkillIds"/> for how skill links are reconciled.
    /// </summary>
    /// <response code="200">The updated experience.</response>
    /// <response code="400">The id is empty, or one or more skill ids do not exist.</response>
    /// <response code="404">No experience has that id.</response>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateExperienceAsync(
        [FromRoute] Guid id, [FromBody] ExperienceUpdateDto experienceUpdateDto)
    {
        if (id == Guid.Empty) return BadRequest("Please provide a valid experience Id.");

        var experienceDto = await _experienceService
            .UpdateExperienceAsync(id, experienceUpdateDto);
        if (experienceDto == null) return NotFound("Experience does not exist on DB.");

        return Ok(experienceDto);
    }

    /// <summary>Deletes an experience by id.</summary>
    /// <response code="204">The experience was deleted.</response>
    /// <response code="400">The id is empty.</response>
    /// <response code="404">No experience has that id.</response>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteExperienceAsync([FromRoute] Guid id)
    {
        if (id == Guid.Empty) return BadRequest("Please provide a valid experience Id.");
        var experienceDto = await _experienceService.DeleteExperienceAsync(id);
        if (!experienceDto) return NotFound("Could not find an experience with the provided id.");
        return NoContent();
    }
}