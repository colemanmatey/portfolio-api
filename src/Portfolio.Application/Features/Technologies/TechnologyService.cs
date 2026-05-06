using Portfolio.Application.Common.Interfaces;
using Portfolio.Application.DTOs;
using Portfolio.Domain.Entities.Technologies;
using Portfolio.Domain.ValueObjects;
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

        public IEnumerable<TechnologyDto> GetTechnologies(string? category)
        {
            var technologies = _techRepo.GetAll();
            if (!string.IsNullOrEmpty(category))
            {
                technologies = technologies.Where(t => t.Category.ToString().Equals(category, StringComparison.OrdinalIgnoreCase));
            }
            return technologies.Select(t => new TechnologyDto(
                id: t.Id,
                name: t.Name,
                category: t.Category.ToString()
            ));
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
            var versions = _versionRepo.GetAll(tv => tv.Technology)
            .GroupBy(tv => tv.Technology.Name)
            .Select(g => new VersionDto(
                    name: g.Key,
                    versions: g
                        .Select(v => v.Version.ToString())
                        .ToList()
                )
            );

            return versions.ToImmutableList();
        }

        public VersionDto GetVersionsById(int id)
        {
            var versions = _versionRepo.GetAll(tv => tv.Technology)
                                .Where(v => v.TechnologyId == id);

            var technology = versions.FirstOrDefault();

            return new VersionDto(
                name: technology?.Technology?.Name ?? "Technology not found",
                versions: versions.Select(v => v.Version.ToString()).ToList()
            );
        }

        public void AddNewVersion(int id, VersionCreateDto dto)
        {
            var technology = _techRepo.GetById(id);

            if (technology == null)
            {
                throw new Exception($"Technology with ID {id} not found.");
            }

            var version = new TechnologyVersion
            {
                TechnologyId = id,
                Version = new SemanticVersion
                {
                    Major = dto.major,
                    Minor = dto.minor,
                    Patch = dto.patch
                }
            };

            _versionRepo.Create(version);
        }

        public void DeleteVersion(int id, int versionId)
        {
            var technology = _techRepo.GetById(id);
            var version = _versionRepo.GetById(versionId);

            if (technology != null && version != null)
            {
                _versionRepo.Delete(versionId);
            }
        }
    }
}
