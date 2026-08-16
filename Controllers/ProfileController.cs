using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ejmabunda_web_api.Models;
using Microsoft.AspNetCore.Authorization;
using ejmabunda_web_api.Services;
using ejmabunda_web_api.Repositories;

namespace ejmabunda_web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProfileController : ControllerBase
    {
        private readonly PortfolioContext _context;
        private readonly IProfileRepository _repository;
        private readonly IProfileService _service;

        public ProfileController(
            PortfolioContext context,
            IProfileRepository repository,
            IProfileService service)
        {
            _context = context;
            _repository = repository;
            _service = service;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<Profile>> GetProfile()
        {
            var profile = await _repository.GetProfileAsync();

            if (profile == null) return NotFound();
            return Ok(profile);
        }

        // PUT: api/Profile
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutProfileAsync([FromBody] ProfilePutDto profileDto)
        {
            var profile = await _repository.GetProfileAsync();
            if (profile == null) return NotFound();

            profile.Title = profileDto.Title ?? profile.Title;
            profile.Headline = profileDto.Headline ?? profile.Headline;
            profile.Subtitle = profileDto.Subtitle ?? profile.Subtitle;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await ProfileExists())
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(profile);
        }

        // POST: api/Profile
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<Profile>> PostProfileAsync([FromBody] ProfileAddDto profileDto)
        {
            var profile = await _service.AddProfileAsync(profileDto);

            if (profile == null)
                return Conflict(new { error = "Profile already exists." });
            return CreatedAtAction("GetProfile", new { Id = profile.Id }, profile);
        }

        // DELETE: api/Profile
        [HttpDelete]
        public async Task<IActionResult> DeleteProfile()
        {
            var profile = await _context.Profiles.FirstOrDefaultAsync();
            if (profile == null)
            {
                return NotFound();
            }

            _context.Profiles.Remove(profile);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private async Task<bool> ProfileExists()
        {
            return await _repository.GetProfileAsync() != null;
        }
    }
}
