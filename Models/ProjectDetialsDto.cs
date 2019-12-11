using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectsDbAPI.Models
{
    public class ProjectDetialsDto
    {
        [Required]
        public string ProjNumber { get; set; }
        [Required]
        public string ProjName { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime? DateStarted { get; set; }
        public DateTime? DateFinished { get; set; }
        public bool IsFinished { get; set; }
        public string? Description { get; set; }

        [Required]
        public string DeptName { get; set; }
        public string? DeptShortName { get; set; }
    }
}
