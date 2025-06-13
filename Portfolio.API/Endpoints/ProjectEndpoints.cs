using Portfolio.Application.DTOs;
using Portfolio.Application.Interfaces;

namespace Portfolio.API.Endpoints;

public static class ProjectEndpoints
{
    public static void MapProjectEndpoints(this WebApplication app) 
    {
        // Project endpoints
        var projects = app.MapGroup("/projects");

        projects.MapGet("/", (IProjectService service) =>
        {
            try
            {
                var projects = service.GetAllProjects();
                return Results.Ok(projects);
            } 
            catch (Exception ex) { 
                return Results.BadRequest(new { message = $"{ex.Message}" });
            }
        });

        projects.MapPost("/", (IProjectService service, ProjectDto dto) =>
        {
            try
            {
                var project = service.CreateProject(dto);
                return Results.Ok(project);
            }
            catch (Exception ex)
            {
                return Results.BadRequest(new { message = $"{ex.Message}" });
            }
        });


        projects.MapGet("/{id:int}", (IProjectService service, int id) =>
        {
            try
            {
                var project = service.GetProjectById(id);
                return Results.Ok(project);
            }
            catch (KeyNotFoundException ex)
            {
                return Results.BadRequest(new { message = $"{ex.Message}" });
            }
        });

        projects.MapPut("/{id:int}", (IProjectService service, int id, ProjectDto dto) =>
        {
            try
            {
                var project = Results.Ok(service.UpdateProject(id, dto));
                return Results.Ok(project);
            }
            catch (Exception ex)
            {
                return Results.BadRequest(new { message = $"{ex.Message}" });
            }
        });

        projects.MapDelete("/{id:int}", (IProjectService service, int id) =>
        {
            try
            {
                var project = Results.Ok(service.DeleteProject(id));
                return Results.Ok(project);
            }
            catch (Exception ex)
            {
                return Results.BadRequest(new { message = $"{ex.Message}" });
            }
        });
    }
}
