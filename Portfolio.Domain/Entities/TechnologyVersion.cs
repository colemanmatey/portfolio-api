using Portfolio.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Domain.Entities
{
    public class TechnologyVersion
    {
        public int Id { get; set; }
        public required SemanticVersion Version {  get; set; }

        // Navigation property
        public int TechnologyId { get; set; }
        public required Technology Technology { get; set; }

        public override string ToString()
        {
            return $"Technology ID:{TechnologyId} {Version.ToString()}";
        }
    }
}
