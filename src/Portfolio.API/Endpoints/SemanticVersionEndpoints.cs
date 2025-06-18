
namespace Portfolio.API.Endpoints
{
    public static class SemanticVersionEndpoints
    {
        public static void MapSemanticVersionEndpoints(this WebApplication app)
        {
            // Technology versions
            var technologyVersions = app.MapGroup("/technologies");

            // Project versions
            var projectVersions = app.MapGroup("/projects");
            
        }
    }
}
