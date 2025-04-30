using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bug_Ticketing_system_DAL.Repositories.Generic;
using Bug_Ticketing_System_DAL;

namespace Bug_Ticketing_system_DAL.Repositories.ProjectRepo
{
    public interface IProjectRepo : IGenericRepository<Project>
    {
        Task<List<Project>> GetAllAsyncByBugs();

        Task<Project> GetProjectByIdByBugs(Guid id);

    }
}
