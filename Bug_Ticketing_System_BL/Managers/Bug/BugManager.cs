using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bug_Ticketing_System_BL.DTOs;
using Bug_Ticketing_system_DAL.UnitOfWork;

namespace Bug_Ticketing_System_BL.Managers.Bug
{
    public class BugManager : IBugManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public BugManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddBugAsync(BugDto bugDto)
        {
            var bug = new Bug_Ticketing_System_DAL.Bug
            {
                Title = bugDto.Title,
                Description = bugDto.Description,
                ProjectId = bugDto.ProjectId,
            };
            await _unitOfWork.BugRepo.AddAsync(bug);
            await _unitOfWork.CompleteAsync();
            bugDto.Id = bug.id;
        }

        public async Task<List<BugDto>> GetAllBugsAsync()
        {
            var bugs = await _unitOfWork.BugRepo.GetAllAsync();
            var bugDtos = bugs.Select(b => new BugDto
            {
                Id = b.id,
                Title = b.Title,
                Description = b.Description,
                ProjectId = b.ProjectId,
            }).ToList();
            return bugDtos;
        }

        public async Task<BugDto> GetBugByIdAsync(Guid id)
        {
            var bug = await _unitOfWork.BugRepo.GetByIdAsync(id);
            if (bug == null)
            {
                return null;
            }
            var bugDto = new BugDto
            {
                Id = bug.id,
                Title = bug.Title,
                Description = bug.Description,
                ProjectId = bug.ProjectId,
            };
            return bugDto;
        }
    }

}
