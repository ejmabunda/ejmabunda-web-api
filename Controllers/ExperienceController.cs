using ejmabunda_web_api.Dtos;
using ejmabunda_web_api.Filters;
using ejmabunda_web_api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ejmabunda_web_api.Controllers;

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

    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetExperienceByIdAsync([FromRoute] Guid id)
    {
        var experience = await _experienceService.GetExperienceByIdAsync(id);
        if (experience == null) return NotFound();
        return Ok(experience);
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetAllExperiencesAsync()
    {
        var experiences = await _experienceService.GetAllExperiencesAsync();
        return Ok(experiences);
    }

    [HttpPost]
    public async Task<IActionResult> AddExperienceAsync(
        [FromBody] ExperienceAddDto experienceAddDto)
    {
        var experience = await _experienceService.AddExperienceAsync(experienceAddDto);

        return CreatedAtAction("GetExperienceById", new { Id = experience.Id }, experience);
    }

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

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteExperienceAsync([FromRoute] Guid id)
    {
        if (id == Guid.Empty) return BadRequest("Please provide a valid experience Id.");
        var experienceDto = await _experienceService.DeleteExperienceAsync(id);
        if (!experienceDto) return NotFound("Could not find an experience with the provided id.");
        return NoContent();
    }
}