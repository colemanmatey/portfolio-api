using Portfolio.Application.DTOs.Projects;
using Portfolio.Application.Interfaces;
using Portfolio.Domain.Entities;
using Portfolio.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Application.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IRepository<Project> _repository;
        public ProjectService(IRepository<Project> repository)
        {
            _repository = repository;
        }

        public ProjectSummaryDto CreateProject(ProjectDto dto)
        {
            var project = new Project()
            {
                Title = dto.Title,
                Description = dto.Description,
                Category = Project.ConvertToSoftwareCategoryEnum(dto.Category),
                Status = Project.ConvertToProjectStatusEnum(dto.Status),
            };

            _repository.Create(project);

            return new ProjectSummaryDto()
            {
                Id = project.Id,
                Summary = $"Project with id: {project.Id} was created successfully"
            };
        }

        public IEnumerable<ProjectReadDto> GetAllProjects()
        {
            var projects = _repository.GetAll();

            return projects.Select(project => new ProjectReadDto()
            {
                Id = project.Id,
                Title = project.Title,
                Description = project.Description,
                Category = project.Category.ToString(),
                Status = project.Status.ToString(),
            }).ToList();
        }

        public ProjectReadDto GetProjectById(int id)
        {
            var project = _repository.GetById(id);

            return new ProjectReadDto() 
            {
                Id = project.Id,
                Title = project.Title,
                Description = project.Description,
                Category = project.Category.ToString(),
                Status = project.Status.ToString(),
            };
        }

        public ProjectSummaryDto UpdateProject(int id, ProjectDto dto)
        {
            var project = _repository.GetById(id);

            project.Title = dto.Title;
            project.Description = dto.Description;
            project.Category = Project.ConvertToSoftwareCategoryEnum(dto.Category);
            project.Status = Project.ConvertToProjectStatusEnum(dto.Status);
            
            _repository.Update(id, project);

            return new ProjectSummaryDto()
            {
                Id = project.Id,
                Summary = $"Project with id: {project.Id} was updated successfully"
            };
        }

        public ProjectSummaryDto DeleteProject(int id)
        {
            _repository.Delete(id);

            return new ProjectSummaryDto()
            {
                Id = id,
                Summary = $"Project with id: {id} was deleted successfully",
            };
        }
    }
}
