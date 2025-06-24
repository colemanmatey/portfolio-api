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

        public override string ToString()
        {
            return $"Project ID:{ProjectId} {Version.ToString()}";
        }
    }
}
