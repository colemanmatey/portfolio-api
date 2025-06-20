using Portfolio.Application.Common.Interfaces;
using Portfolio.Application.DTOs;
using Portfolio.Domain.Entities.Projects;
using System.Collections.Immutable;

namespace Portfolio.Application.Features.Projects
{
    public class ProjectService : IProjectService
    {
        private readonly IRepository<Project> _projectRepo;
        private readonly IRepository<ProjectVersion> _versionRepo;

        public ProjectService(IRepository<Project> projectRepo, IRepository<ProjectVersion> versionRepo)
        {
            _projectRepo = projectRepo;
            _versionRepo = versionRepo;
        }

        // Get all projects
        public ImmutableList<ProjectDto> GetAllProjects()
        {
            var projects = _projectRepo.GetAll();

            var projectDtos = projects.Select(project => new ProjectDto(
                project.Id,
                project.Title,
                project.Description,
                project.Category.ToString(),
                project.Status.ToString()
            ))
            .ToImmutableList();

            return projectDtos;
        }

        // Get project by ID
        public ProjectDto GetProjectById(int id)
        {
            var project = _projectRepo.GetById(id);

            if (project is null)
                throw new ProjectNotFoundException(id);

            return new ProjectDto(
                project.Id,
                project.Title,
                project.Description,
                project.Category.ToString(),
                project.Status.ToString()
            );
        }

        // Create Project
        public ProjectDto CreateProject(ProjectDto dto)
        {
            var project = new Project(dto.title, dto.description);
            project.Category = project.ToSoftwareCategoryEnum(dto.category);
            project.Status = project.ToProjectStatusEnum(dto.status);

            _projectRepo.Create(project);

            return new ProjectDto(
                project.Id,
                project.Title,
                project.Description,
                project.Category.ToString(),
                project.Status.ToString()
            );
        }

        // Update project
        public ProjectDto UpdateProject(int id, ProjectDto dto)
        {
            var project = _projectRepo.GetById(id);

            project.Title = dto.title;
            project.Description = dto.description;
            project.Category = project.ToSoftwareCategoryEnum(dto.category);
            project.Status = project.ToProjectStatusEnum(dto.status);

            _projectRepo.Update(id, project);

            return new ProjectDto(
                project.Id,
                project.Title,
                project.Description,
                project.Category.ToString(),
                project.Status.ToString()
            );
        }

        // Delete project
        public void DeleteProject(int id)
        {
            _projectRepo.Delete(id);
        }

        public ImmutableList<VersionDto> GetAllVersions()
        {
            var versions = _versionRepo.GetAll(pv => pv.Project);

            return versions.Select(
                pv => new VersionDto(
                    pv.Project.Title, 
                    pv.Version.ToString()
                )
            ).ToImmutableList();
        }

        public VersionDto GetVersionById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
