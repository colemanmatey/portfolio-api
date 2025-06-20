using Microsoft.AspNetCore.Mvc;
using Portfolio.Application.Common.Interfaces;
using Portfolio.Application.Features.Projects;
using Portfolio.Application.Features.Technologies;
using Portfolio.Domain.Entities.Projects;
using Portfolio.Domain.Entities.Technologies;

namespace Portfolio.API.Endpoints
{
    public static class SemanticVersionEndpoints
    {
        public static void MapSemanticVersionEndpoints(this WebApplication app)
        {
            // Technology versions
            var technologyVersions = app.MapGroup("/technologies");

            // Get all tech versions
            technologyVersions.MapGet("/versions/all", (IProjectService service) =>
            {
                try
                {
                    var versions = service.GetAllVersions();
                    return Results.Ok(versions);
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(new { message = $"{ex}" });
                }
            });

            // Project versions
            var projectVersions = app.MapGroup("/projects");


            projectVersions.MapGet("/versions/all", (ITechnologyService service) =>
            {
                try
                {
                    var versions = service.GetAllVersions();
                    return Results.Ok(versions);
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(new { message = $"{ex}" });
                }
            });
        }
    }
}
