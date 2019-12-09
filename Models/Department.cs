using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectsDbAPI.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string DeptName { get; set; }
        public string DeptShortName { get; set; }

        public virtual Project Project { get; set; }
        public int ProjectId { get; set; }
    }
}
