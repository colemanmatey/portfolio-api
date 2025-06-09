using Portfolio.Application.Services;

namespace Portfolio.API.Endpoints
{
    public static class ProjectsEndpoints
    {
        public static void MapProjectEndpoints(this WebApplication app)
        {
            var projects = app.MapGroup("/api/projects");

            projects.MapGet("/", (ProjectService service) =>
            {
                return Results.Ok(service.GetAllProjects());
            });
        }
    }
}
