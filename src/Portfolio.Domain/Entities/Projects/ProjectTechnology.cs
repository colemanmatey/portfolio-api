using Portfolio.Domain.Entities.Technologies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Domain.Entities.Projects
{
    public class ProjectTechnology
    {
        public int ProjectId { get; set; }
        public required Project Project { get; set; }

        public int TechnologyId { get; set; }
        public required Technology Technology { get; set; }
    }
}
