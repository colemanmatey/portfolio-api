using Microsoft.AspNetCore.Mvc;
using Portfolio.Application.DTOs;
using Portfolio.Application.Interfaces;
using Portfolio.Domain.Entities;

namespace Portfolio.API.Endpoints
{
    public static class SemanticVersionEndpoints
    {
        public static void MapSemanticVersionEndpoints(this WebApplication app)
        {
            // Technology versions
            var technologyVersions = app.MapGroup("/technologies/versions");

            technologyVersions.MapGet("/", (IVersionService<TechnologyVersion, TechnologyVersionDto> service) => 
            {
                try
                {
                    var technologyVersions = service.GetAllVersions(tv => tv.Technology);
                    return Results.Ok(technologyVersions);
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(new { message = $"{ex}" });
                }
            });


            // Project versions
            var projectVersions = app.MapGroup("/projects/versions");

            projectVersions.MapGet("/", (IVersionService<ProjectVersion, ProjectVersionDto> service) =>
            {
                try
                {
                    var projectVersions = service.GetAllVersions(pv => pv.Project);
                    return Results.Ok(projectVersions);
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(new { message = $"{ex.Message}" });
                }
            });

        }
    }
}
