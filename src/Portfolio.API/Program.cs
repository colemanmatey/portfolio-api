using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
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

            // Register Swagger
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure Http request pipeline
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

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


            // Register endpoints
            app.MapGet("/", () => "Welcome to Coleman's Portfolio API!");
            app.MapProjectEndpoints();
            app.MapTechnologyEndpoints();
            app.MapSemanticVersionEndpoints();

            app.Run();
        }
    }
}
