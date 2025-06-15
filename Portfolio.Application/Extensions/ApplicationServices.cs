using Microsoft.Extensions.DependencyInjection;
using Portfolio.Application.DTOs;
using Portfolio.Application.Interfaces;
using Portfolio.Application.Services;
using Portfolio.Domain.Entities;
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

            services.AddScoped<IVersionService<ProjectVersion, ProjectVersionDto>, ProjectVersionService>();
            services.AddScoped<IVersionService<TechnologyVersion, TechnologyVersionDto>, TechnologyVersionService>();

            return services;
        }
    }
}
