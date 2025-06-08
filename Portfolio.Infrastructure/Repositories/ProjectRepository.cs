using Portfolio.Application.DTOs;
using Portfolio.Application.Interfaces;
using Portfolio.Domain.Entities;
using Portfolio.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Infrastructure.Repositories
{
    public class ProjectRepository : IRepository<Project>
    {

    readonly PortfolioDbContext _context;
        public ProjectRepository(PortfolioDbContext context) 
        {
            _context = context;
        }
        public List<Project> GetAll()
        {
            return _context.Projects.ToList();
        }
    }
}
