using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bug_Ticketing_System_DAL;

namespace Bug_Ticketing_System_DAL
{
    public class Project
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }

        public ICollection<Bug>? Bugs { get; set; } = new HashSet<Bug>();
    }
}
