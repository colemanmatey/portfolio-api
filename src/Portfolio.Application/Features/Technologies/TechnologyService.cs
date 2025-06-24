using Portfolio.Application.Common.Interfaces;
using Portfolio.Application.DTOs;
using Portfolio.Domain.Entities.Technologies;
using System.Collections.Immutable;
namespace Portfolio.Application.Features.Technologies
{
    public class TechnologyService : ITechnologyService
    {
        private readonly IRepository<Technology> _techRepo;
        private readonly IRepository<TechnologyVersion> _versionRepo;

        public TechnologyService(IRepository<Technology> techRepo, IRepository<TechnologyVersion> versionRepo)
        {
            _techRepo = techRepo;
            _versionRepo = versionRepo;

        }

        public ImmutableList<TechnologyDto> GetAllTechnologies()
        {
            var technologies = _techRepo.GetAll();

            var technologyDtos = technologies.Select(technology => new TechnologyDto(
                 technology.Id,
                 technology.Name,
                 technology.Category.ToString()
            ))
           .ToImmutableList();

            return technologyDtos;
        }

        public TechnologyDto GetTechnologyById(int id)
        {
            var technology = _techRepo.GetById(id);

            return new TechnologyDto(
                 technology.Id,
                 technology.Name,
                 technology.Category.ToString()
            );
        }
        public TechnologyDto CreateTechnology(TechnologyDto dto)
        {
            var technology = new Technology(dto.name, dto.category);

            _techRepo.Create(technology);

            return new TechnologyDto(
                 technology.Id,
                 technology.Name,
                 technology.Category.ToString()
            );
        }

        public TechnologyDto UpdateTechnology(int id, TechnologyDto dto)
        {
            var technology = _techRepo.GetById(id);

            technology.Name = dto.name;
            technology.Category = technology.ToTechnologyTypeEnum(dto.category);

            _techRepo.Update(id, technology);

            return new TechnologyDto(
                 technology.Id,
                 technology.Name,
                 technology.Category.ToString()
            );

        }

        public void DeleteTechnology(int id)
        {
            _techRepo.Delete(id);
        }

        public ImmutableList<VersionDto> GetAllVersions()
        {
            var versions = _versionRepo.GetAll(tv => tv.Technology);

            return versions.Select(
                tv => new VersionDto(
                    tv.Technology.Name, 
                    tv.Version.ToString()
                )
            )
            .ToImmutableList();
        }

        public ImmutableList<VersionDto> GetVersionsById(int id)
        {
            var versions = _versionRepo.GetAll(tv => tv.Technology);

            return versions.Where(v => v.TechnologyId == id)          
                .Select(tv => new VersionDto(tv.Technology.Name, tv.Version.ToString())
            )
            .ToImmutableList();
        }
    }
}
