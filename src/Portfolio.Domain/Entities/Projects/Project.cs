using Portfolio.Domain.Entities;
using Portfolio.Domain.Entities.Technologies;
using Portfolio.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Domain.Entities.Projects
{
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public SoftwareCategory Category { get; set; }
        public ProjectStatus Status { get; set; }
        
        // Navigational properties
        public List<ProjectVersion> Versions { get; set; }
        public List<Technology> Technologies { get; set; }

        private Project() 
        {
            Title = string.Empty;
            Category = SoftwareCategory.Unassigned;
            Status = ProjectStatus.New;
            Versions = new List<ProjectVersion>();
            Technologies = new List<Technology>();
        }

        public Project(string title, string? description)
        {
            Title = title;
            Description = description;
            Category = SoftwareCategory.Unassigned;
            Status = ProjectStatus.New;
            Versions = new List<ProjectVersion>();
            Technologies = new List<Technology>();
        }

        public Project(int id, string title, string? description, string softwareCategory, string projectStatus)
        {
            Id = id;
            Title = title;
            Description = description;
            Category = ToSoftwareCategoryEnum(softwareCategory);
            Status = ToProjectStatusEnum(projectStatus);
            Versions = new List<ProjectVersion>();
            Technologies = new List<Technology>();
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
