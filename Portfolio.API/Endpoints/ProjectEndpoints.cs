using Portfolio.Application.DTOs.Projects;
using Portfolio.Application.Interfaces;

namespace Portfolio.API.Endpoints
{
    public static class ProjectEndpoints
    {
        public static void MapProjectEndpoints(this WebApplication app) 
        {
            // Project endpoints
            var projects = app.MapGroup("/projects");

            projects.MapGet("/", (IProjectService service) => Results.Ok(service.GetAllProjects()));
            projects.MapPost("/", (IProjectService service, ProjectDto dto) => Results.Ok(service.CreateProject(dto)));
            projects.MapGet("/{id:int}", (IProjectService service, int id) => Results.Ok(service.GetProjectById(id)));
            projects.MapPut("/{id:int}", (IProjectService service, int id, ProjectDto dto) => Results.Ok(service.UpdateProject(id, dto)));
            projects.MapDelete("/{id:int}", (IProjectService service, int id) => Results.Ok(service.DeleteProject(id)));
        }
    }
}
