using Bug_Ticketing_system_DAL.Repositories.Generic;
using Bug_Ticketing_System_DAL;

namespace Bug_Ticketing_System.DAL.Repositories.Bug_UserRepo
{
    public class Bug_UserRepo : GenericRepository<BugAssignment>, IBug_UserRepo
    {
        public Bug_UserRepo(BugDbContext context) : base(context)
        {
        }
    }
}
