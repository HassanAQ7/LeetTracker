using LeetTracker.DTOs;
using LeetTracker.Models;
using LeetTracker.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LeetTracker.Controllers
{
    [Route("api/problems")]
    [ApiController]
    public class ProblemController(ProblemService problemService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<ProblemResponse>>> GetAllProblem()
        {
            return Ok(await problemService.GetAllProblems());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProblemResponse>> GetProblemById(int id)
        {
            var problem = await problemService.GetProblemById(id);
            return problem is null ? NotFound("Could not find the problem") : Ok(problem);
        }

        [HttpPost]
        public async Task<ActionResult<ProblemResponse>> AddProblem(CreateProblemDto problem)
        {
            var created = await problemService.AddProblem(problem);
            return CreatedAtAction(nameof(GetProblemById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProblemResponse>> UpdateProblem(int id, UpdateProblemDto problem)
        {
            var updatedProblem = await problemService.UpdateProblemById(id, problem);
            return updatedProblem is null ? NotFound("Could not find problem to update") : Ok(updatedProblem);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProblemResponse>> DeleteProblem(int id)
        {
            var isDeleted = await problemService.DeleteProblem(id);
            return isDeleted ? NoContent() : NotFound("Couldn't find problem to delete");
        }
    }
}
