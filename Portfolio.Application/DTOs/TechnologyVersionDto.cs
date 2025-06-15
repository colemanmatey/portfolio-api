using Portfolio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Application.DTOs
{
    public class TechnologyVersionDto
    {
        public string Name { get; set; }
        public string Version { get; set; }

        public TechnologyVersionDto(TechnologyVersion tv)
        {
            Name = tv.Technology.Name;
            Version = tv.Version.ToString();
        }
    }
}
