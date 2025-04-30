using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bug_Ticketing_System_DAL
{
    public class Attachment
    {
        public Guid Id { get; set; }
        public string FilePath { get; set; }

        public Guid BugId { get; set; }
        public Bug Bug { get; set; }
    }
}
