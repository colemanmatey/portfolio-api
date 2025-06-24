using Portfolio.Domain.Interfaces;
using Portfolio.Domain.ValueObjects;

namespace Portfolio.Domain.Entities.Technologies
{
    public class TechnologyVersion : IHasId
    {
        public int Id { get; set; }
        public SemanticVersion Version {  get; set; }

        // Navigation property
        public int TechnologyId { get; set; }
        public Technology Technology { get; set; }

        public override string ToString()
        {
            return $"Technology ID:{TechnologyId} {Version.ToString()}";
        }
    }
}
