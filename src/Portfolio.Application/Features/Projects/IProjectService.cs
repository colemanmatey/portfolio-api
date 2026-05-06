using Portfolio.Application.Common.Interfaces;
using Portfolio.Domain.Entities.Projects;
using System.Collections.Immutable;

namespace Portfolio.Application.Features.Projects
{
    public interface IProjectService : IVersionService<ProjectVersion>
    {
        IEnumerable<ProjectDto> GetProjects(string? category, string? status);
        ProjectDto GetProjectById(int id);
        ProjectDto CreateProject(ProjectDto dto);
        ProjectDto UpdateProject(int id, ProjectDto dto);
        void DeleteProject(int id);
    }
}
