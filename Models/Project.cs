using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectsDbAPI.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string ProjNumber { get; set; }
        public string ProjName { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateStarted { get; set; }
        public DateTime DateFinished { get; set; }
        public bool IsFinished { get; set; }
        public string Description { get; set; }

        public virtual Department Department { get; set; }
        public virtual List<Designer> Designers { get; set; }

    }
}
