using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bug_Ticketing_System_DAL;

namespace Bug_Ticketing_System_BL.DTOs
{
    public class ProjectDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }


        public ICollection<BugDto>? Bugs { get; set; } = new List<BugDto>();
    }
}

