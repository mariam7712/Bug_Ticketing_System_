using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bug_Ticketing_system_DAL.Repositories.Generic;
using Bug_Ticketing_System_DAL;
using Microsoft.EntityFrameworkCore;

namespace Bug_Ticketing_system_DAL.Repositories.ProjectRepo
{
    public class ProjectRepo : GenericRepository<Project>, IProjectRepo
    {
        private readonly BugDbContext DbContext;

        public ProjectRepo(BugDbContext context) : base(context) => DbContext = context;


        public async Task<List<Project>> GetAllAsyncByBugs()
        {
            return await DbContext.Projects
                    .Include(p => p.Bugs)
                    .ToListAsync();
        }

        public Task<Project> GetProjectByIdByBugs(Guid id)
        {
            return DbContext.Projects
                    .Include(p => p.Bugs)
                    .FirstOrDefaultAsync(p => p.Id == id);

        }


    }
}


