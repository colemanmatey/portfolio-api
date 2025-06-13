using Portfolio.Application.DTOs;
using Portfolio.Application.Interfaces;
using Portfolio.Domain.Entities;

namespace Portfolio.API.Endpoints
{
    public static class TechnologyEndpoints
    {
        public static void MapTechnologyEndpoints(this WebApplication app)
        {
            var technologies = app.MapGroup("/technologies");

            technologies.MapGet("/", (ITechnologyService service) =>
            {
                try
                {
                    var technologies = service.GetAllTechnologies();
                    return Results.Ok(technologies);
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(new { message = $"{ex.Message}" });
                }
            });

            technologies.MapPost("/", (ITechnologyService service, TechnologyDto dto) =>
            {
                try
                {
                    var technology = service.CreateTechnology(dto);
                    return Results.Ok(technology);
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(new { message = $"{ex.Message}" });
                }
            });


            technologies.MapGet("/{id:int}", (ITechnologyService service, int id) =>
            {
                try
                {
                    var technology = service.GetTechnologyById(id);
                    return Results.Ok(technology);
                }
                catch (KeyNotFoundException ex)
                {
                    return Results.BadRequest(new { message = $"{ex.Message}" });
                }
            });

            technologies.MapPut("/{id:int}", (ITechnologyService service, int id, TechnologyDto dto) =>
            {
                try
                {
                    var technology = Results.Ok(service.UpdateTechnology(id, dto));
                    return Results.Ok(technology);
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(new { message = $"{ex.Message}" });
                }
            });

            technologies.MapDelete("/{id:int}", (ITechnologyService service, int id) =>
            {
                try
                {
                    var technology = Results.Ok(service.DeleteTechnology(id));
                    return Results.Ok(technology);
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(new { message = $"{ex.Message}" });
                }
            });

        }

    }
}
