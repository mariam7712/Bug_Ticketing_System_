using Bug_Ticketing_system_DAL.Repositories.Generic;
using Bug_Ticketing_System_DAL;

namespace Bug_Ticketing_System.DAL.Repositories.AttachmentRepo
{
    public interface IAttachmentRepo : IGenericRepository<Attachment>
    {
        void DeleteAsync(Attachment attachmentToRemove);
    }
}
