using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Portfolio.Application.Interfaces;
using Portfolio.Domain.Entities;
using Portfolio.Infrastructure.Data;
using Portfolio.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Infrastructure.Extensions
{
    public static class InfrastructureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Set up database connection
            services.AddDbContext<PortfolioDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("PortfolioDB"))
            );

            services.AddScoped<IRepository<Project>, Repository<Project>>();
            services.AddScoped<IRepository<Technology>,  Repository<Technology>>();

            services.AddScoped<IRepository<ProjectVersion>, Repository<ProjectVersion>>();
            services.AddScoped<IRepository<TechnologyVersion>, Repository<TechnologyVersion>>();


            return services;
        }
    }
}
