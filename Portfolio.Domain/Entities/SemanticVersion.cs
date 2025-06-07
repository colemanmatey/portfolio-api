using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Domain.Entities
{
    public class SemanticVersion
    {
        public int Id { get; set; }
        public required int Major { get; set; }
        public required int Minor { get; set; }
        public required int Patch { get; set; }

        // Navigational property
        public int TechnologyId { get; set; }
        public required Technology Technology { get; set; }

        public override string ToString()
        {
            return $"{Major}.{Minor}.{Patch}";
        }
    }
}
