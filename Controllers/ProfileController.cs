using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ejmabunda_web_api.Models;

namespace ejmabunda_web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly PortfolioContext _context;

        public ProfileController(PortfolioContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<Profile>> GetProfile()
        {
            var profile = await _context.Profiles.FirstOrDefaultAsync();

            if (profile == null)
            {
                return NotFound();
            }

            return Ok(profile);
        }

        // PUT: api/Profile
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutProfile([FromBody] ProfilePutDto profileDto)
        {
            var profile = await _context.Profiles.FirstOrDefaultAsync();
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
        public async Task<ActionResult<Profile>> PostProfile([FromBody] ProfileAddDto profileDto)
        {
            if (await ProfileExists()) return Conflict(new { error = "Profile already exists." });

            var profile = new Profile()
            {
                Id = Guid.NewGuid(),
                Title = profileDto.Title,
                Headline = profileDto.Headline,
                Subtitle = profileDto.Subtitle
            };
            _context.Profiles.Add(profile);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProfile", new { id = profile.Id }, profile);
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
            return await _context.Profiles.AnyAsync();
        }
    }
}
