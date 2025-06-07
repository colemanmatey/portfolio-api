using Portfolio.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Domain.Entities
{
    public class Technology
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public TechnologyType Category { get; set; }

        // Navigational properties
        public required List<SemanticVersion> Versions { get; set; }
        public required List<Project> Projects { get; set; }
    }
}
