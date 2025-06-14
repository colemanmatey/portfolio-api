using Portfolio.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Domain.Entities
{
    public class ProjectVersion
    {
        public int Id { get; set; }
        public required SemanticVersion Version { get; set; }

        // Navigational property
        public int ProjectId { get; set; }
        public required Project Project { get; set; }

        public override string ToString()
        {
            return $"Project ID:{ProjectId} {Version.ToString()}";
        }
    }
}
