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
        public required string Title { get; set; }
        public string? Description { get; set; }
        public SoftwareCategory Category { get; set; }
        public ProjectStatus Status { get; set; }
        
        // Navigational properties
        public List<Technology> Technologies { get; set; }

        public Project()
        {
            Technologies = new List<Technology>();
        }

        public static SoftwareCategory ConvertToSoftwareCategoryEnum(string? input)
        {
            return Enum.TryParse<SoftwareCategory>(input, true, out var category) 
                    ? category 
                    : SoftwareCategory.Unassigned;
        }

        public static ProjectStatus ConvertToProjectStatusEnum(string? input)
        {
            return Enum.TryParse<ProjectStatus>(input, true, out var status)
                    ? status
                    : ProjectStatus.New;
        }
    }
}
