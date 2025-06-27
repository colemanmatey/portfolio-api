using Microsoft.AspNetCore.Mvc;
using Portfolio.Application.Features.Projects;

namespace Portfolio.API.Endpoints;

public static class ProjectEndpoints
{
    public static void MapProjectEndpoints(this WebApplication app)
    {
        // Project endpoints
        var projects = app.MapGroup("/projects");

        projects.MapGet("/", GetAllProjects);
        projects.MapPost("/", CreateProject);
        projects.MapGet("/{id:int}", GetProjectById);
        projects.MapPut("/{id:int}", UpdateProject);
        projects.MapDelete("/{id:int}", DeleteProject);
    }

    private static IResult GetAllProjects(IProjectService service)
    {
        try
        {
            var projects = service.GetAllProjects();
            return Results.Ok(projects);
        } 
        catch (Exception ex) { 
            return Results.BadRequest(new { message = $"{ex.Message}" });
        }
    }

    private static IResult CreateProject(IProjectService service, ProjectDto dto)
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
    }

    private static IResult GetProjectById(IProjectService service, int id)
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
    }

    private static IResult UpdateProject(IProjectService service, int id, ProjectDto dto)
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
    }

    private static IResult DeleteProject(IProjectService service, int id)
    {
        try
        {
            service.DeleteProject(id);
            return Results.Ok(new { message = "Project deleted successfully" });
        }
        catch (Exception ex)
        {
            return Results.BadRequest(new { message = $"{ex.Message}" });
        }
    }
   
}
