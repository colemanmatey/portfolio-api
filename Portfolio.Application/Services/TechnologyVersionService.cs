using Portfolio.Application.DTOs;
using Portfolio.Application.Interfaces;
using Portfolio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Application.Services
{
    public class TechnologyVersionService : VersionService<TechnologyVersion, TechnologyVersionDto>
    {
        public TechnologyVersionService(IRepository<TechnologyVersion> repository) : base(repository)
        {
        }

        protected override TechnologyVersionDto MapToDto(TechnologyVersion tv)
        {
            return new TechnologyVersionDto(tv);
        }

        public override ResultDto<ImmutableList<TechnologyVersionDto>> GetAllVersions(params Expression<Func<TechnologyVersion, object>>[] includes)
        {
            // Include Technology navigation property
            var results = _repository.GetAll(includes);

            var versionDtos = results.Select(MapToDto).ToImmutableList();

            return new ResultDto<ImmutableList<TechnologyVersionDto>>()
            {
                Success = true,
                Message = versionDtos.Any()
                          ? "Versions retrieved successfully."
                          : "No versions found.",
                Data = versionDtos
            };
        }
    }
}
