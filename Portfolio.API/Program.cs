using Portfolio.Infrastructure.Extensions;

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

            var app = builder.Build();

            app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}
