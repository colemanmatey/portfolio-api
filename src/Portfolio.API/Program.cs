using Microsoft.AspNetCore.Diagnostics;
using Portfolio.API.Endpoints;
using Portfolio.Application.Common.Interfaces;
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
                builder.Configuration.AddUserSecrets(typeof(Infrastructure.Extensions.DependencyInjection).Assembly);
            }

            // Register services
            builder.Services.AddInfrastructureServices(builder.Configuration);
            builder.Services.AddApplicationServices();

            // Register Swagger
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure Http request pipeline
            app.UseSwagger();
            app.UseSwaggerUI();

            // Global Exception Handler
            app.UseExceptionHandler(err =>
            {
                err.Run(async context =>
                {
                    var handler = context.Features.Get<IExceptionHandlerFeature>();
                    var exception = handler?.Error;

                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "application/json";

                    await context.Response.WriteAsJsonAsync(new
                    {
                        message = exception?.Message
                    });
                });
            });


            // Register basic endpoints
            app.MapGet("/", () => Results.Json(new
            {
                name = "Portfolio API",
                author = "Coleman A. Matey",
                description = "Backend service powering Coleman's portfolio.",
                status = "running",
                apiVersion = "v1",
                environment = app.Environment.EnvironmentName,
                uptimeSeconds = Environment.TickCount64 / 1000,
                serverTime = DateTime.UtcNow,
                docs = "/swagger",
                health = "/health",
                metrics = "/metrics",
                endpoints = new[]
                {
                    "/api/v1/projects",
                    "/api/v1/technologies",
                },
                repository = "https://github.com/colemanmatey/portfolio-api"
            }));

            app.MapGet("/health", async (IHealthCheckService check) =>
            {
                return await check.CanConnectToDatabaseAsync() ? "healthy" : "unhealthy";
            });

            app.MapGet("/metrics", () => Results.Json(new
            {
                uptimeSeconds = Environment.TickCount64 / 1000,
                memoryUsedBytes = GC.GetTotalMemory(false),
                threadCount = Environment.ProcessorCount,
                serverTime = DateTime.UtcNow
            }));


            app.MapGet("/docs", () => Results.Redirect("/swagger"));


            // Register API endpoints
            app.MapProjectEndpoints();
            app.MapTechnologyEndpoints();
            app.MapSemanticVersionEndpoints();

            app.Run();
        }
    }
}
