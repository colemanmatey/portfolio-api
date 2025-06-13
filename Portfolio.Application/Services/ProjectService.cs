using Portfolio.Application.DTOs;
using Portfolio.Application.Interfaces;
using Portfolio.Domain.Entities;
using Portfolio.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
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

        // Create Project
        public ResultDto<Project> CreateProject(ProjectDto dto)
        {
            var project = new Project(dto.Title, dto.Description);
            project.Category = project.ToSoftwareCategoryEnum(dto.Category);
            project.Status = project.ToProjectStatusEnum(dto.Status);

            _repository.Create(project);

            return new ResultDto<Project>()
            {
                Success = true,
                Message = $"Project '{project.Title}' has been created successfully!",
                Data = project
            };
        }

        // Get all projects
        public ResultDto<ImmutableList<ProjectDto>> GetAllProjects()
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

            return new ResultDto<ImmutableList<ProjectDto>>()
            {
                Success = true,
                Message = projectDtos.Any()
                          ? "Projects retrieved successfully."
                          : "No projects found.",
                Data = projectDtos
            };
        }

        // Get project by ID
        public ResultDto<ProjectDto> GetProjectById(int id)
        {
            var project = _repository.GetById(id);

            return new ResultDto<ProjectDto>()
            {
                Success = true,
                Message = $"Project has been retrieved!",
                Data = new ProjectDto() {
                    Id = id,
                    Title = project.Title,
                    Description = project.Description,
                    Category = project.Category.ToString(),
                    Status = project.Status.ToString()
                }
            };
        }

        // Update project
        public ResultDto<Project> UpdateProject(int id, ProjectDto dto)
        {
            var project = _repository.GetById(id);

            project.Title = dto.Title;
            project.Description = dto.Description;
            project.Category = project.ToSoftwareCategoryEnum(dto.Category);
            project.Status = project.ToProjectStatusEnum(dto.Status);
            
            _repository.Update(id, project);

            return new ResultDto<Project>()
            {
                Success = true,
                Message = $"Project has been updated!",
                Data = project
            };
        }

        // Delete project
        public ResultDto<Project> DeleteProject(int id)
        {
            _repository.Delete(id);

            return new ResultDto<Project>()
            {
                Success = true,
                Message = $"Project with ID: '{id}' has been deleted!",
            };
        }
    }
}
