using Bug_Ticketing_System_BL.DTOs;
using Bug_Ticketing_System_BL.Managers.Bug;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bug_Ticketing_System_.Controllers.Bugs
{
    [Route("api/[controller]")]
    [ApiController]
    public class BugController : ControllerBase
    {
        private readonly IBugManager _bugManager;

        public BugController(IBugManager bugManager)
        {
            _bugManager = bugManager;

        }
        [HttpGet]
        public async Task<IActionResult> GetAllBugs()
        {
            var bugs = await _bugManager.GetAllBugsAsync();
            return Ok(bugs);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBugById(Guid id)
        {
            var bug = await _bugManager.GetBugByIdAsync(id);
            if (bug == null)
            {
                return NotFound();
            }
            return Ok(bug);
        }
        [HttpPost]
        public async Task<IActionResult> AddBug([FromBody] BugDto bugDto)
        {
            if (bugDto == null)
            {
                return BadRequest("Bug data is null");
            }
            await _bugManager.AddBugAsync(bugDto);
            return CreatedAtAction(nameof(GetBugById), new { id = bugDto.Id }, bugDto);
        }
    }
}
