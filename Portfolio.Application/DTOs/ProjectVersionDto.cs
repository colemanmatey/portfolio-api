using Portfolio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Application.DTOs
{
    public class ProjectVersionDto
    {
        public string Name { get; set; }
        public string Version { get; set; }

        public ProjectVersionDto(ProjectVersion pv)
        {
            Name = pv.Project.Title;
            Version = pv.Version.ToString();
        }
    }
}
