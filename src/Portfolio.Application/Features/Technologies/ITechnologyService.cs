using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Application.Features.Technologies
{
    public interface ITechnologyService
    {
        ImmutableList<TechnologyDto> GetAllTechnologies();
        TechnologyDto GetTechnologyById(int id);
        TechnologyDto CreateTechnology(TechnologyDto dto);
        TechnologyDto UpdateTechnology(int id, TechnologyDto dto);
        void DeleteTechnology(int id);
    }
}
