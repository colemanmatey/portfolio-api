using Portfolio.Application.Common.Interfaces;
using Portfolio.Domain.Entities.Technologies;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Application.Features.Technologies
{
    public class TechnologyService : ITechnologyService
    {
        private readonly IRepository<Technology> _repository;

        public TechnologyService(IRepository<Technology> repository)
        {
            _repository = repository;
        }

        public ImmutableList<TechnologyDto> GetAllTechnologies()
        {
            var technologies = _repository.GetAll();
            
            var technologyDtos = technologies.Select(result => new TechnologyDto
            {
                Id = result.Id,
                Name = result.Name,
                Category = result.Category.ToString()
            })
           .ToImmutableList();

            return technologyDtos;
        }

        public TechnologyDto GetTechnologyById(int id)
        {
            var technology = _repository.GetById(id);

            return new TechnologyDto()
            {
                Id = technology.Id,
                Name = technology.Name,
                Category = technology.Category.ToString()
            };
        }
        public TechnologyDto CreateTechnology(TechnologyDto dto)
        {
            var technology = new Technology(dto.Name, dto.Category);

            _repository.Create(technology);

            return new TechnologyDto()
            {
                Id = technology.Id,
                Name = technology.Name,
                Category = technology.Category.ToString()
            };
        }

        public TechnologyDto UpdateTechnology(int id, TechnologyDto dto)
        {
            var technology = _repository.GetById(id);

            technology.Name = dto.Name;
            technology.Category = technology.ToTechnologyTypeEnum(dto.Category);

            _repository.Update(id, technology);

            return new TechnologyDto()
            {
                Id = technology.Id,
                Name = technology.Name,
                Category = technology.Category.ToString()
            };

        }

        public void DeleteTechnology(int id)
        {
            _repository.Delete(id);
        }
    }
}
