using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bug_Ticketing_System_BL.DTOs;
using Bug_Ticketing_system_DAL.UnitOfWork;
using Bug_Ticketing_System_DAL;
using Microsoft.EntityFrameworkCore.Query;

namespace Bug_Ticketing_System_BL.Managers.Project
{
    public class ProjectManager : IProjectManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProjectManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddProjectAsync(ProjectDto projectDto)
        {
            var project = new Bug_Ticketing_System_DAL.Project
            {
                Name = projectDto.Name,

            };

            await _unitOfWork.ProjectRepo.AddAsync(project);
            await _unitOfWork.CompleteAsync();


            projectDto.Id = project.Id;
        }


        public async Task<List<ProjectDto>> GetAllProjectsAsync()
        {
            var projects = await _unitOfWork.ProjectRepo.GetAllAsyncByBugs();
            var projectDtos = projects.Select(p => new ProjectDto
            {
                Id = p.Id,
                Name = p.Name,
                Bugs = p.Bugs.Select(b => new BugDto
                {
                    Id = b.id,
                    Title = b.Title,
                    Description = b.Description,
                    ProjectId = b.ProjectId
                }).ToList()
            }).ToList();
            return projectDtos;
        }


        public async Task<ProjectDto> GetProjectByIdAsync(Guid id)
        {
            var project = await _unitOfWork.ProjectRepo.GetProjectByIdByBugs(id);
            if (project == null)
            {
                return null;
            }

            var projectDto = new ProjectDto
            {
                Id = project.Id,
                Name = project.Name,
                Bugs = project.Bugs.Select(b => new BugDto
                {
                    Id = b.id,
                    Title = b.Title,
                    Description = b.Description,
                    ProjectId = b.ProjectId
                }).ToList()
            };

            return projectDto;
        }

    }
}
