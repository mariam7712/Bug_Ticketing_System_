using Bug_Ticketing_system_DAL.Repositories.Generic;
using Bug_Ticketing_System_DAL;

namespace Bug_Ticketing_System.DAL.Repositories.AttachmentRepo
{
    public class AttachmentRepo : GenericRepository<Attachment>, IAttachmentRepo
    {
        public AttachmentRepo(BugDbContext context) : base(context)
        {
        }

        public void DeleteAsync(Attachment attachmentToRemove)
        {
            throw new NotImplementedException();
        }
    }
}
