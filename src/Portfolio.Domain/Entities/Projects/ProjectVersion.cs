using Portfolio.Domain.Entities.Technologies;
using Portfolio.Domain.Interfaces;
using Portfolio.Domain.ValueObjects;

namespace Portfolio.Domain.Entities.Projects
{
    public class ProjectVersion : IHasId
    {
        public int Id { get; set; }
        public SemanticVersion Version { get; set; }

        // Navigational property
        public int ProjectId { get; set; }
        public Project Project { get; set; }

        // link to tech versions
        public ICollection<TechnologyVersion> TechnologyVersions { get; set; }
            = new List<TechnologyVersion>();

        public override string ToString()
        {
            return $"Project ID:{ProjectId} {Version.ToString()}";
        }
    }
}
