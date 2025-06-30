using Microsoft.AspNetCore.Mvc;
using Portfolio.Application.Common.Interfaces;
using Portfolio.Application.DTOs;
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
            technologyVersions.MapGet("/versions/all", GetAllTechVersions);
            technologyVersions.MapGet("/{id:int}/versions", GetAllTechVersionsById);
            technologyVersions.MapPost("/{id:int}/versions", AddVersionToTech);
            technologyVersions.MapDelete("/{id:int}/versions/{versionId:int}", DeleteTechVersion);
                
            // Project versions
            var projectVersions = app.MapGroup("/projects");
            projectVersions.MapGet("/versions/all", GetAllProjectVersions);
            projectVersions.MapGet("/{id:int}/versions", GetAllProjectVersionsById);
            projectVersions.MapPost("/{id:int}/versions", AddVersionToProject);
            projectVersions.MapDelete("/{id:int}/versions/{versionId:int}", DeleteProjectVersion);
        }

        // Technology versions
        private static IResult GetAllTechVersions (ITechnologyService service)
        {
            try
            {
                var versions = service.GetAllVersions();
                return Results.Ok(versions);
            }
            catch (Exception ex)
            {
                return Results.BadRequest(new { message = $"{ex.Message}" });
            }
        }

        private static IResult GetAllTechVersionsById(ITechnologyService service, int id)
        {
            try
            {
                var versions = service.GetVersionsById(id);
                return Results.Ok(versions);
            }
            catch (Exception ex)
            {
                return Results.BadRequest(new { message = $"{ex}" });
            }
        }

        private static IResult AddVersionToTech(ITechnologyService service, int id, VersionCreateDto dto)
        {
            try
            {
                service.AddNewVersion(id, dto);
                return Results.Ok(new { message = "New technology version has been added!" });
   
            }
            catch (Exception ex)
            {
                return Results.BadRequest(new { message = $"{ex}" });
            }
        }

        private static IResult DeleteTechVersion(ITechnologyService service, int id, int versionId)
        {
            try
            {
                service.DeleteVersion(id, versionId);
                return Results.Ok(new { message = "Technology Version deleted successfully" });
            }
            catch (Exception ex)
            {
                return Results.BadRequest(new { message = $"{ex}" });
            }
        }

        // Project versions
        private static IResult GetAllProjectVersions(IProjectService service)
        {
            try
            {
                var versions = service.GetAllVersions();
                return Results.Ok(versions);
            }
            catch (Exception ex)
            {
                return Results.BadRequest(new { message = $"{ex.Message}" });
            }
        }

        private static IResult GetAllProjectVersionsById(IProjectService service, int id)
        {
            try
            {
                var versions = service.GetVersionsById(id);
                return Results.Ok(versions);
            }
            catch (Exception ex)
            {
                return Results.BadRequest(new { message = $"{ex}" });
            }
        }

        private static IResult AddVersionToProject(IProjectService service, int id, VersionCreateDto dto)
        {

            try
            {
                service.AddNewVersion(id, dto);
                return Results.Ok(new { message = "New project version has been added!" });

            }
            catch (Exception ex)
            {
                return Results.BadRequest(new { message = $"{ex}" });
            }
        }
        private static IResult DeleteProjectVersion(IProjectService service, int id, int versionId)
        {
            try
            {
                service.DeleteVersion(id, versionId);
                return Results.Ok(new { message = "Project Version deleted successfully" });
            }
            catch (Exception ex)
            {
                return Results.BadRequest(new { message = $"{ex}" });
            }
        }
    }
}
