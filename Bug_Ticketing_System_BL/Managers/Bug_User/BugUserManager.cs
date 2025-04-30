
using Bug_Ticketing_System.DAL;
using Bug_Ticketing_system_DAL.UnitOfWork;
using Bug_Ticketing_System_DAL;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Bug_Ticketing_System.BL.Managers.Bug_User
{
    public class BugUserManager : IBugUserManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<User> _userManager;

        public BugUserManager(IUnitOfWork unitOfWork, UserManager<User> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public async Task<bool> AddUserToBugAsync(Guid bugId, string userId)
        {
            var bug = await _unitOfWork.BugRepo.GetByIdAsync(bugId);
            if (bug == null)
            {
                return false;
            }
            var user = await _userManager.Users.Where(u => u.Id == userId)
                .Include(u => u.BugAssignments)
                .FirstOrDefaultAsync();
            if (user == null)
            {
                return false;
            }
            var aleadyExists = user.BugAssignments
                .Any(bu => bu.BugId == bugId);
            if (aleadyExists)
            {
                return false;
            }
            var bug_user = new BugAssignment
            {
                BugId = bugId,
                UserId = user.Id,
            };
            bug.BugAssignments.Add(bug_user);
            await _unitOfWork.CompleteAsync();
            return true;
        }

        public async Task<bool> RemoveUserFromBugAsync(Guid bugId, string userId)
        {
            var bug = await _unitOfWork.BugRepo.GetByIdAsync(bugId);
            if (bug == null)
            {
                return false;
            }
            var user = await _userManager.Users.Where(u => u.Id == userId)
                .Include(u => u.BugAssignments)
                .FirstOrDefaultAsync();
            if (user == null)
            {
                return false;
            }

            var userToRemove = user.BugAssignments
                .FirstOrDefault(bu => bu.BugId == bugId);
            if (userToRemove == null)
            {
                return false;
            }
            bug.BugAssignments.Remove(userToRemove);
            await _unitOfWork.CompleteAsync();
            return true;
        }
    }
}
