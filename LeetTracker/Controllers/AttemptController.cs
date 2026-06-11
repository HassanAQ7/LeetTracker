using LeetTracker.DTOs;
using LeetTracker.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LeetTracker.Controllers
{
    [Route("api/attempts")]
    [ApiController]
    public class AttemptController(AttemptService attemptService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<AttemptResponse>>> GetAllAttempts()
        {
            return Ok(await attemptService.GetAllAttempts());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AttemptResponse>> GetAttemptById(int id)
        {
            var attempt = await attemptService.GetAttemptById(id);
            return attempt is null ? NotFound("No such attempt found") : Ok(attempt);
        }

        [HttpPost]
        public async Task<ActionResult<AttemptResponse>> AddAttempt(CreateAttemptDto attempt)
        {
            var newAttempt = await attemptService.AddAttempt(attempt);
            return CreatedAtAction(nameof(GetAttemptById), new { id = newAttempt.Id }, newAttempt);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<AttemptResponse>> UpdateAttemptById(int id, UpdateAttemptDto attempt)
        {
            var updatedAttempt = await attemptService.UpdateAttemptById(id, attempt);
            return attempt is null ? NotFound("Could not find attempt to update") : Ok(updatedAttempt);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAttempt(int id)
        {
            var deleted = await attemptService.DeleteAttempt(id);
            return deleted ? NoContent() : NotFound("Could not find attempt to delete");
        }
    }
}
