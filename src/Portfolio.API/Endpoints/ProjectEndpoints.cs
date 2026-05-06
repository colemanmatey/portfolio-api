using Microsoft.AspNetCore.Mvc;

using Portfolio.Application.Features.Projects;

namespace Portfolio.API.Endpoints;

public static class ProjectEndpoints
{
    public static void MapProjectEndpoints(this WebApplication app)
    {
        // Project endpoints
        var projects = app.MapGroup("/api/projects");

        projects.MapGet("/", GetProjects);
        projects.MapPost("/", CreateProject);
        projects.MapGet("/{id:int}", GetProjectById);
        projects.MapPut("/{id:int}", UpdateProject);
        projects.MapDelete("/{id:int}", DeleteProject);
    }

    private static IResult GetProjects(IProjectService service, string? category, string? status)
    {
          var projects = service.GetProjects(category, status);
          return Results.Ok(projects);
    }

    private static IResult CreateProject(IProjectService service, ProjectDto dto)
    {
        var project = service.CreateProject(dto);
        return Results.Ok(project);
    }

    private static IResult GetProjectById(IProjectService service, int id)
    {
        var project = service.GetProjectById(id);
        return Results.Ok(project);
    }

    private static IResult UpdateProject(IProjectService service, int id, ProjectDto dto)
    {
        var project = service.UpdateProject(id, dto);
        return Results.Ok(project);
    }

    private static IResult DeleteProject(IProjectService service, int id)
    {
        service.DeleteProject(id);
        return Results.Ok(new { message = "Project deleted successfully" });
    }
}
