using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectsDbAPI.Models
{
    public class Designer
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime HireDate { get; set; }

        public virtual Project Project { get; set; }
        public int ProjectId { get; set; }
    }
}
