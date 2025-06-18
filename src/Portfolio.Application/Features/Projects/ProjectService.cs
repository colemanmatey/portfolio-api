using Portfolio.Application.Common.Interfaces;
using Portfolio.Domain.Entities.Projects;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Application.Features.Projects
{
    public class ProjectService : IProjectService
    {

        private readonly IRepository<Project> _repository;

        public ProjectService(IRepository<Project> repository)
        {
            _repository = repository;
        }

        // Get all projects
        public ImmutableList<ProjectDto> GetAllProjects()
        {
            var projects = _repository.GetAll();

            var projectDtos = projects.Select(result => new ProjectDto
            {
                Id = result.Id,
                Title = result.Title,
                Description = result.Description,
                Category = result.Category.ToString(),
                Status = result.Status.ToString()
            })
            .ToImmutableList();

            return projectDtos;
        }

        // Get project by ID
        public ProjectDto GetProjectById(int id)
        {
            var project = _repository.GetById(id);

            if (project is null)
                throw new ProjectNotFoundException(id);

            return new ProjectDto
            {
                Id = project.Id,
                Title = project.Title,
                Description = project.Description,
                Category = project.Category.ToString(),
                Status = project.Status.ToString()
            };
        }

        // Create Project
        public ProjectDto CreateProject(ProjectDto dto)
        {
            var project = new Project(dto.Title, dto.Description);
            project.Category = project.ToSoftwareCategoryEnum(dto.Category);
            project.Status = project.ToProjectStatusEnum(dto.Status);

            _repository.Create(project);

            return new ProjectDto()
            {
                Id = project.Id,
                Title = project.Title,
                Description = project.Description,
                Category = project.Category.ToString(),
                Status = project.Status.ToString()
            };
        }

        // Update project
        public ProjectDto UpdateProject(int id, ProjectDto dto)
        {
            var project = _repository.GetById(id);

            project.Title = dto.Title;
            project.Description = dto.Description;
            project.Category = project.ToSoftwareCategoryEnum(dto.Category);
            project.Status = project.ToProjectStatusEnum(dto.Status);
            
            _repository.Update(id, project);

            return new ProjectDto()
            {
                Id = project.Id,
                Title = project.Title,
                Description = project.Description,
                Category = project.Category.ToString(),
                Status = project.Status.ToString()
            };
        }

        // Delete project
        public void DeleteProject(int id)
        {
            _repository.Delete(id);
        }
    }
}
