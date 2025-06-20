using Microsoft.Extensions.DependencyInjection;
using Portfolio.Application.Common.Interfaces;
using Portfolio.Application.Features.Projects;
using Portfolio.Application.Features.Technologies;
using Portfolio.Domain.Entities.Projects;
using Portfolio.Domain.Entities.Technologies;

namespace Portfolio.Application.Extensions
{
    public static class ApplicationServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IVersionService<ProjectVersion>, ProjectService>();

            services.AddScoped<ITechnologyService, TechnologyService>();
            services.AddScoped<IVersionService<TechnologyVersion>, TechnologyService>();

            return services;
        }
    }
}
