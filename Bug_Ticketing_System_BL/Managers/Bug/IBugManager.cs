using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bug_Ticketing_System_BL.DTOs;

namespace Bug_Ticketing_System_BL.Managers.Bug
{
    public interface IBugManager
    {
        Task<List<BugDto>> GetAllBugsAsync();

        Task<BugDto> GetBugByIdAsync(Guid id);

        Task AddBugAsync(BugDto bugDto);

    }
}
