using Portfolio.Application.DTOs.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Application.Interfaces
{
    public interface IProjectService
    {
        IEnumerable<ProjectReadDto> GetAllProjects();
        ProjectReadDto GetProjectById(int id);
        ProjectSummaryDto CreateProject(ProjectDto dto);
        ProjectSummaryDto UpdateProject(int id, ProjectDto dto);
        ProjectSummaryDto DeleteProject(int id);
    }
}
