using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ejmabunda_web_api.Models;
using Microsoft.AspNetCore.Authorization;
using ejmabunda_web_api.Services;
using ejmabunda_web_api.Repositories;

namespace ejmabunda_web_api.Controllers
{
    /// <summary>
    /// CRUD API for the site owner's <see cref="Profile"/>. The profile is a singleton
    /// (see <see cref="Profile.Id"/>) — there is always zero or one row, so these actions
    /// operate on "the" profile rather than one identified by an id in the route.
    /// Reads are public; writes require a JWT bearer token except profile creation.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileRepository _repository;
        private readonly IProfileService _service;

        public ProfileController(
            IProfileRepository repository,
            IProfileService service)
        {
            _repository = repository;
            _service = service;
        }

        /// <summary>Gets the profile.</summary>
        /// <response code="200">The profile.</response>
        /// <response code="404">No profile has been created yet.</response>
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<Profile>> GetProfile()
        {
            var profile = await _repository.GetProfileAsync();

            if (profile == null) return NotFound();
            return Ok(profile);
        }

        /// <summary>Updates the profile. Fields omitted from the request body are left unchanged.</summary>
        /// <response code="200">The updated profile.</response>
        /// <response code="404">No profile exists to update.</response>
        // PUT: api/Profile
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutProfileAsync([FromBody] ProfilePutDto profileDto)
        {
            Profile? profile;
            try
            {
                profile = await _service.UpdateProfileAsync(profileDto);
                if (profile == null) return NotFound();

                return Ok(profile);
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
        }

        /// <summary>Creates the profile. Fails if one already exists, since the profile is a singleton.</summary>
        /// <response code="201">The created profile.</response>
        /// <response code="409">A profile already exists.</response>
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

        /// <summary>Deletes the profile.</summary>
        /// <response code="204">The profile was deleted.</response>
        /// <response code="404">No profile exists to delete.</response>
        // DELETE: api/Profile
        [HttpDelete]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteProfileAsync()
        {
            var profile = await _service.DeleteProfileAsync();
            
            if (profile == null) return NotFound();
            return NoContent();
        }

        private async Task<bool> ProfileExists()
        {
            return await _repository.GetProfileAsync() != null;
        }
    }
}
