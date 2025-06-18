using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Application.Features.Projects
{
    public interface IProjectService
    {
        ImmutableList<ProjectDto> GetAllProjects();
        ProjectDto GetProjectById(int id);
        ProjectDto CreateProject(ProjectDto dto);
        ProjectDto UpdateProject(int id, ProjectDto dto);
        void DeleteProject(int id); // No return needed if deletion succeeds
    }
}
