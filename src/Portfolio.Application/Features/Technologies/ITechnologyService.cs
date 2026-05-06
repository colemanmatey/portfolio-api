using Portfolio.Application.Common.Interfaces;
using Portfolio.Domain.Entities.Technologies;
using System.Collections.Immutable;

namespace Portfolio.Application.Features.Technologies
{
    public interface ITechnologyService : IVersionService<TechnologyVersion>
    {
        IEnumerable<TechnologyDto> GetTechnologies(string? category);
        TechnologyDto GetTechnologyById(int id);
        TechnologyDto CreateTechnology(TechnologyDto dto);
        TechnologyDto UpdateTechnology(int id, TechnologyDto dto);
        void DeleteTechnology(int id);
    }
}
