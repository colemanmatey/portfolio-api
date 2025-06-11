using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Application.DTOs.Projects
{
    public class ProjectDto
    {
        public required string Title { get; set; }
        public string? Description { get; set; }
        public string? Category {  get; set; }
        public string? Status { get; set; }
    }
}
