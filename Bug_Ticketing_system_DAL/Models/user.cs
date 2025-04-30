using Microsoft.AspNetCore.Identity;
namespace Bug_Ticketing_System_DAL
{
    public class User : IdentityUser
    {

        public ICollection<BugAssignment> BugAssignments { get; set; } = new HashSet<BugAssignment>();

    }
}
