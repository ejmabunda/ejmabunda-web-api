using ejmabunda_web_api.Dtos;
using ejmabunda_web_api.Models;
using ejmabunda_web_api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Namotion.Reflection;

namespace ejmabunda_web_api.Controllers;

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

    [HttpPost]
    public async Task<IActionResult> AddSkillAsync([FromBody] SkillAddDto skillDto)
    {
        var skill = await _skillService.AddSkillAsync(skillDto);
        if (skill == null) return BadRequest("Invalid skill category.");

        return CreatedAtAction(
            "GetSkillByIdAsync",
            new { Id = skill.Id },
            new SkillDto
            {
                Id = skill.Id,
                Name = skill.Name,
                SkillCategory = skill.SkillCategory.ToString()
            });
    }

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

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSkillAsync([FromRoute] Guid id)
    {
        var skill = await _skillService.DeleteSkillAsync(id);
        if (skill == null) return NotFound();

        return NoContent();
    }
}