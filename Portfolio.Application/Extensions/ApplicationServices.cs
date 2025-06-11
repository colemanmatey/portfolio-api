using Microsoft.Extensions.DependencyInjection;
using Portfolio.Application.Interfaces;
using Portfolio.Application.Services;
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
            return services;
        }
    }
}
