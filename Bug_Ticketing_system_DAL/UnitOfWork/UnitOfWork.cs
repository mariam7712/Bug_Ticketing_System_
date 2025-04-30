using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bug_Ticketing_System.DAL.Repositories.AttachmentRepo;
using Bug_Ticketing_System.DAL.Repositories.Bug_UserRepo;
using Bug_Ticketing_System.DAL.Repositories.BugRepo;
using Bug_Ticketing_system_DAL.Repositories.ProjectRepo;
using Bug_Ticketing_System_DAL;

namespace Bug_Ticketing_system_DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private BugDbContext _context;



        public IProjectRepo ProjectRepo { get; }

        public IBugRepo BugRepo { get; }
        public IBug_UserRepo Bug_User { get; }

        public IAttachmentRepo Attachment { get; }

        public UnitOfWork(BugDbContext context)
        {
            _context = context;

            ProjectRepo = new ProjectRepo(_context);
            BugRepo = new BugRepo(_context);
            Bug_User = new Bug_UserRepo(_context);
        }

        public async Task<int> CompleteAsync() => await _context.SaveChangesAsync();


        public void Dispose() => _context.Dispose();
    }
}
