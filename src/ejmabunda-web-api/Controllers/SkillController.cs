using ejmabunda_web_api.Dtos;
using ejmabunda_web_api.Models;
using ejmabunda_web_api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ejmabunda_web_api.Controllers;

/// <summary>
/// CRUD API for <see cref="Skill"/> entries. Reads are public; writes require a JWT
/// bearer token. <see cref="Skill.SkillCategory"/> binds from its backing integer on
/// input and serializes as its name on output.
/// </summary>
[ApiController]
[Route("api/[controller]")]
[Authorize]
public class SkillController : ControllerBase
{
    private readonly ISkillService _skillService;

    public SkillController(ISkillService skillService)
    {
        _skillService = skillService;
    }

    /// <summary>Lists all skills.</summary>
    /// <response code="200">The skills (an empty array when there are none).</response>
    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetAllSkillsAsync()
    {
        var skills = await _skillService.GetAllSkillsAsync();
        var skillsDto = skills
            .Select(s => new SkillDto
            {
                Id = s.Id,
                Name = s.Name,
                SkillCategory = s.SkillCategory.ToString()
            }
        );
        return Ok(skillsDto);
    }

    /// <summary>Gets one skill by id.</summary>
    /// <response code="200">The skill.</response>
    /// <response code="404">No skill has that id.</response>
    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetSkillByIdAsync([FromRoute] Guid id)
    {
        var skill = await _skillService.GetSkillByIdAsync(id);
        if (skill == null) return NotFound();

        return Ok(
            new SkillDto() { 
                Id = skill.Id, Name = skill.Name, SkillCategory = skill.SkillCategory.ToString() 
            }
        );
    }

    /// <summary>Creates a skill.</summary>
    /// <response code="201">The created skill, with a <c>Location</c> header.</response>
    /// <response code="400">The skill category is not a valid value.</response>
    [HttpPost]
    public async Task<IActionResult> AddSkillAsync([FromBody] SkillAddDto skillDto)
    {
        var skill = await _skillService.AddSkillAsync(skillDto);
        if (skill == null) return BadRequest("Invalid skill category.");

        return CreatedAtAction(
            "GetSkillById",
            new { skill.Id },
            new SkillDto
            {
                Id = skill.Id,
                Name = skill.Name,
                SkillCategory = skill.SkillCategory.ToString()
            });
    }

    /// <summary>Updates a skill (id in the body). Fields omitted from the body are left unchanged.</summary>
    /// <response code="200">The updated skill.</response>
    /// <response code="404">No skill has that id, or the supplied category is not a valid value.</response>
    [HttpPut]
    public async Task<IActionResult> UpdateSkillAsync([FromBody] SkillUpdateDto skillDto)
    {
        var skill = await _skillService.UpdateSkillAsync(skillDto);
        if (skill == null) return NotFound();

        return Ok(
           new SkillDto
           {
               Id = skill.Id,
               Name = skill.Name,
               SkillCategory = skill.SkillCategory.ToString()
           }
       );
    }

    /// <summary>Deletes a skill by id.</summary>
    /// <response code="204">The skill was deleted.</response>
    /// <response code="404">No skill has that id.</response>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSkillAsync([FromRoute] Guid id)
    {
        var skill = await _skillService.DeleteSkillAsync(id);
        if (skill == null) return NotFound();

        return NoContent();
    }
}