using Microsoft.AspNetCore.Http.HttpResults;
using Portfolio.Application.Services;
using Portfolio.Application.Extensions;
using Portfolio.Infrastructure.Extensions;
using Portfolio.API.Endpoints;

namespace Portfolio
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Load user secrets from the Infrastructure assembly in development
            if (builder.Environment.IsDevelopment())
            {
                builder.Configuration.AddUserSecrets(typeof(InfrastructureServiceExtensions).Assembly);
            }

            // Register services
            builder.Services.AddInfrastructureServices(builder.Configuration);
            builder.Services.AddApplicationServices();

            var app = builder.Build();

            // Register endpoints
            app.MapGet("/", () => "Coleman's projects API!");
            app.MapProjectEndpoints();

            app.Run();
        }
    }
}
