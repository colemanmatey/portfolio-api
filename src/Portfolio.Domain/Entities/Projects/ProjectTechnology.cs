using Portfolio.Domain.Entities.Technologies;

namespace Portfolio.Domain.Entities.Projects
{
    public class ProjectTechnology
    {
        public int ProjectId { get; }
        public required Project Project { get; set; }

        public int TechnologyId { get; set; }
        public required Technology Technology { get; set; }
    }
}
