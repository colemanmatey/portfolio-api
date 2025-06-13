using Portfolio.Application.DTOs;
using Portfolio.Application.Interfaces;
using Portfolio.Domain.Entities;
using Portfolio.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Application.Services
{
    public class TechnologyService : ITechnologyService
    {
        private readonly IRepository<Technology> _repository;

        public TechnologyService(IRepository<Technology> repository)
        {
            _repository = repository;
        }
        public ResultDto<Technology> CreateTechnology(TechnologyDto dto)
        {
            var technology = new Technology(dto.Name, dto.Category);

            _repository.Create(technology);

            return new ResultDto<Technology>()
            {
                Success = true,
                Message = $"Project '{technology.Name}' has been created successfully!",
                Data = technology
            };
        }

        public ResultDto<ImmutableList<TechnologyDto>> GetAllTechnologies()
        {
            var technologies = _repository.GetAll();
            
            var technologyDtos = technologies.Select(result => new TechnologyDto
            {
                Id = result.Id,
                Name = result.Name,
                Category = result.Category.ToString()
            })
           .ToImmutableList();

            return new ResultDto<ImmutableList<TechnologyDto>>()
            {
                Success = true,
                Message = technologyDtos.Any()
                          ? "Technologies retrieved successfully."
                          : "No technologies found.",
                Data = technologyDtos
            };


        }

        public ResultDto<TechnologyDto> GetTechnologyById(int id)
        {
            var technology = _repository.GetById(id);

            return new ResultDto<TechnologyDto>()
            {
                Success = true,
                Message = $"Technology has been retrieved!",
                Data = new TechnologyDto()
                {
                    Id = id,
                    Name = technology.Name,
                    Category = technology.Category.ToString()
                }
            };
        }

        public ResultDto<Technology> UpdateTechnology(int id, TechnologyDto dto)
        {
            var technology = _repository.GetById(id);

            technology.Name = dto.Name;
            technology.Category = technology.ToTechnologyTypeEnum(dto.Category);

            _repository.Update(id, technology);

            return new ResultDto<Technology>()
            {
                Success = true,
                Message = "Technology has been updated!",
                Data = technology
            };

        }

        public ResultDto<Technology> DeleteTechnology(int id)
        {
            _repository.Delete(id);

            return new ResultDto<Technology>()
            {
                Success = true,
                Message = $"Technology with ID: '{id}' has been deleted!",
            };
        }
    }
}
