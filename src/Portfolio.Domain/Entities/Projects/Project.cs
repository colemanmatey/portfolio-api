using Portfolio.Domain.Entities.Technologies;
using Portfolio.Domain.Enums;
using Portfolio.Domain.Interfaces;


namespace Portfolio.Domain.Entities.Projects
{
    public class Project : IHasId
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public SoftwareCategory Category { get; set; }
        public ProjectStatus Status { get; set; }
        
        // Navigational properties
        public ICollection<ProjectVersion> ProjectVersions { get; set; }

        private Project() 
        {
            Title = string.Empty;
            Category = SoftwareCategory.Unassigned;
            Status = ProjectStatus.New;
            ProjectVersions = new List<ProjectVersion>();
        }

        public Project(string title, string? description)
        {
            Title = title;
            Description = description;
            Category = SoftwareCategory.Unassigned;
            Status = ProjectStatus.New;
            ProjectVersions = new List<ProjectVersion>();
        }

        public Project(int id, string title, string? description, string softwareCategory, string projectStatus)
        {
            Id = id;
            Title = title;
            Description = description;
            Category = ToSoftwareCategoryEnum(softwareCategory);
            Status = ToProjectStatusEnum(projectStatus);
            ProjectVersions = new List<ProjectVersion>();
        }

        public SoftwareCategory ToSoftwareCategoryEnum(string? input)
        {
            return Enum.TryParse<SoftwareCategory>(input, true, out var category) 
                    ? category 
                    : SoftwareCategory.Unassigned;
        }

        public ProjectStatus ToProjectStatusEnum(string? input)
        {
            return Enum.TryParse<ProjectStatus>(input, true, out var status)
                    ? status
                    : ProjectStatus.New;
        }
    }
}
