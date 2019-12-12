using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectsDbAPI.Models
{
    public class DesignerDto
    {
        [Required]
        public string FullName { get; set; }
        public DateTime? HireDate { get; set; }
    }
}
