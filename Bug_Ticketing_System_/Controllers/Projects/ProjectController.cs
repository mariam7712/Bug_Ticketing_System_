using Bug_Ticketing_System_BL.DTOs;
using Bug_Ticketing_System_BL.Managers.Project;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bug_Ticketing_System_.Controllers.Projects
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectManager _projectManager;

        public ProjectController(IProjectManager projectManager)
        {
            _projectManager = projectManager;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProjects()
        {
            var projects = await _projectManager.GetAllProjectsAsync();
            return Ok(projects);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProjectById(Guid id)
        {
            var project = await _projectManager.GetProjectByIdAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            return Ok(project);
        }
        [HttpPost]
        public async Task<IActionResult> AddProject([FromBody] ProjectDto projectDto)
        {
            if (projectDto == null)
            {
                return BadRequest("Project data is null");
            }
            if (projectDto.Bugs != null && projectDto.Bugs.Any())
            {
                return BadRequest("Bugs cannot be added when creating a project");
            }
            await _projectManager.AddProjectAsync(projectDto);
            return CreatedAtAction(nameof(GetProjectById), new { id = projectDto.Id }, projectDto);
        }
    }
}
