using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bug_Ticketing_System_DAL
{
    public class BugAssignment
    {
        public Guid BugId { get; set; }
        public Bug Bug { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
