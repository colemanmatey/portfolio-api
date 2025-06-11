using Portfolio.API.Endpoints;
using Portfolio.Application.Extensions;
using Portfolio.Infrastructure.Extensions;

namespace Portfolio.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Load user secrets from the Infrastructure assembly in development
            if (builder.Environment.IsDevelopment())
            {
                builder.Configuration.AddUserSecrets(typeof(InfrastructureServices).Assembly);
            }

            // Register services
            builder.Services.AddInfrastructureServices(builder.Configuration);
            builder.Services.AddApplicationServices();

            var app = builder.Build();

            // Register endpoints
            app.MapGet("/", () => "Welcome to Coleman's Portfolio API!");
            app.MapProjectEndpoints();

            app.Run();
        }
    }
}
