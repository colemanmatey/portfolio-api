using Portfolio.Application.Common.Interfaces;
using Portfolio.Domain.Entities.Projects;
using System.Collections.Immutable;

namespace Portfolio.Application.Features.Projects
{
    public interface IProjectService : IVersionService<ProjectVersion>
    {
        ImmutableList<ProjectDto> GetAllProjects();
        ProjectDto GetProjectById(int id);
        ProjectDto CreateProject(ProjectDto dto);
        ProjectDto UpdateProject(int id, ProjectDto dto);
        void DeleteProject(int id); // No return needed if deletion succeeds
    }
}
