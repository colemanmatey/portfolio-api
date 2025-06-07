using Portfolio.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Domain.Entities
{
    public class Project
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public SoftwareCategory Category { get; set; }
        public ProjectStatus Status { get; set; }

        // Navigational properties
        public required List<Technology> Technologies { get; set; }

    }
}
