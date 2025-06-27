using Portfolio.Application.Features.Technologies;
using Portfolio.Domain.Entities.Projects;

namespace Portfolio.API.Endpoints
{
    public static class TechnologyEndpoints
    {
        public static void MapTechnologyEndpoints(this WebApplication app)
        {
            var technologies = app.MapGroup("/technologies");

            technologies.MapGet("/", GetAllTechnologies);
            technologies.MapPost("/", CreateTechnology);
            technologies.MapGet("/{id:int}", GetTechnologyById);
            technologies.MapPut("/{id:int}", UpdateTechnology);
            technologies.MapDelete("/{id:int}", DeleteTechnology);
        }

        private static IResult GetAllTechnologies(ITechnologyService service)
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
        }

        private static IResult CreateTechnology(ITechnologyService service, TechnologyDto dto)
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
        }


        private static IResult GetTechnologyById(ITechnologyService service, int id)
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
        }

        private static IResult UpdateTechnology(ITechnologyService service, int id, TechnologyDto dto)
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
        }

        private static IResult DeleteTechnology(ITechnologyService service, int id)
        {
            try
            {
                service.DeleteTechnology(id); 
                return Results.Ok(new { message = "Technology deleted successfully" });
            }
            catch (Exception ex)
            {
                return Results.BadRequest(new { message = $"{ex.Message}" });
            }
        }
    }
}
