using Portfolio.Application.DTOs;
using Portfolio.Application.Interfaces;
using Portfolio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Application.Services
{
    public class ProjectService
    {
        private readonly IRepository<Project> _repository;
        public ProjectService(IRepository<Project> repository)
        {
            _repository = repository;
        }

        public List<ProjectDTO> GetAllProjects()
        {
            var projects = _repository.GetAll();
            return projects.Select(p => new ProjectDTO
            {
                Id = p.Id,
                Title = p.Title,
                Description = p.Description,
                Category = p.Category.ToString(),
                Status = p.Status.ToString()
            }).ToList();
        }
    }
}
