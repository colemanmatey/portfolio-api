using Portfolio.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Domain.Entities
{
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public SoftwareCategory Category { get; set; }
        public ProjectStatus Status { get; set; }
        
        // Navigational properties
        public List<Technology> Technologies { get; set; }

        public Project(string title, string? description)
        {
            Title = title;
            Description = description;
            Category = SoftwareCategory.Unassigned;
            Status = ProjectStatus.New;
            Technologies = new List<Technology>();
        }

        public Project(int id, string title, string? description, string softwareCategory, string projectStatus)
        {
            Id = id;
            Title = title;
            Description = description;
            Category = ConvertToSoftwareCategoryEnum(softwareCategory);
            Status = ConvertToProjectStatusEnum(projectStatus);
            Technologies = new List<Technology>();
        }

        public SoftwareCategory ConvertToSoftwareCategoryEnum(string? input)
        {
            return Enum.TryParse<SoftwareCategory>(input, true, out var category) 
                    ? category 
                    : SoftwareCategory.Unassigned;
        }

        public ProjectStatus ConvertToProjectStatusEnum(string? input)
        {
            return Enum.TryParse<ProjectStatus>(input, true, out var status)
                    ? status
                    : ProjectStatus.New;
        }
    }
}
