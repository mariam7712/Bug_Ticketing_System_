using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bug_Ticketing_System_DAL;

namespace Bug_Ticketing_System_DAL
{
    public class Bug
    {
        public Guid id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public Guid ProjectId { get; set; }
        public Project Project { get; set; }

        public ICollection<BugAssignment> BugAssignments { get; set; } = new HashSet<BugAssignment>();

        public ICollection<Attachment> Attachements { get; set; } = new HashSet<Attachment>();

    }
}
