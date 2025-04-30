using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bug_Ticketing_System.DAL.Repositories.AttachmentRepo;
using Bug_Ticketing_System.DAL.Repositories.BugRepo;
using Bug_Ticketing_system_DAL.Repositories.ProjectRepo;

namespace Bug_Ticketing_system_DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IProjectRepo ProjectRepo { get; }
        IBugRepo BugRepo { get; }


        IAttachmentRepo Attachment { get; }
        Task<int> CompleteAsync();
    }
}
