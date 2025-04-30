using Bug_Ticketing_system_DAL.Repositories.Generic;
using Bug_Ticketing_System_DAL;

namespace Bug_Ticketing_System.DAL.Repositories.BugRepo
{
    public class BugRepo : GenericRepository<Bug>, IBugRepo
    {
        public BugRepo(BugDbContext context) : base(context)
        {
        }
    }
}
