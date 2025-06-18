using Microsoft.Extensions.DependencyInjection;
using Portfolio.Application.Features.Projects;
using Portfolio.Application.Features.Technologies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Application.Extensions
{
    public static class ApplicationServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<ITechnologyService, TechnologyService>();

            return services;
        }
    }
}
