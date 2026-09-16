using ejmabunda_web_api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ejmabunda_web_api.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class QualificationController : ControllerBase
{
    private readonly IQualificationService _qualificationService;

    public QualificationController(IQualificationService qualificationService)
    {
        _qualificationService = qualificationService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllQualificationsAsync()
    {
        var qualifications = await _qualificationService.GetAllQualificationsAsync();
        return Ok(qualifications);
    }
}
