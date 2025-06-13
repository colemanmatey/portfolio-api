using Portfolio.Application.DTOs;
using Portfolio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Application.Interfaces
{
    public interface ITechnologyService
    {
        ResultDto<ImmutableList<Technology>> GetAllTechnologies();
        ResultDto<Technology> GetTechnologyById(int id);
        ResultDto<Technology> CreateTechnology(TechnologyDto dto);
        ResultDto<Technology> UpdateTechnology(int id, TechnologyDto dto);
        ResultDto<Technology> DeleteTechnology(int id);
    }
}
