using Portfolio.Application.DTOs;
using Portfolio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Application.Interfaces
{
    public interface IProjectService
    {
        ResultDto<ImmutableList<ProjectDto>> GetAllProjects();
        ResultDto<ProjectDto> GetProjectById(int id);
        ResultDto<Project> CreateProject(ProjectDto dto);
        ResultDto<Project> UpdateProject(int id, ProjectDto dto);
        ResultDto<Project> DeleteProject(int id);
    }
}
