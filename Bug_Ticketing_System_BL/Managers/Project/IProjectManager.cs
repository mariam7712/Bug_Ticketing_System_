using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bug_Ticketing_System_BL.DTOs;

namespace Bug_Ticketing_System_BL.Managers.Project
{
    public interface IProjectManager
    {
        Task<List<ProjectDto>> GetAllProjectsAsync();
        Task<ProjectDto> GetProjectByIdAsync(Guid id);
        Task AddProjectAsync(ProjectDto projectDto);
    }
}
