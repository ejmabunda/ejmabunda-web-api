using ejmabunda_web_api.Dtos;
using ejmabunda_web_api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ejmabunda_web_api.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class ExperienceController : ControllerBase
{
    private readonly IExperienceService _experienceService;

    public ExperienceController(IExperienceService experienceService)
    {
        _experienceService = experienceService;        
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
        [FromBody] ExperienceDto experienceDto)
    {
        var experience = await _experienceService
            .AddExperienceAsync(experienceDto);

        return Ok(experience);
    }
}