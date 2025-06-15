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
    public class ProjectVersionService : VersionService<ProjectVersion, ProjectVersionDto>
    {
        public ProjectVersionService(IRepository<ProjectVersion> repository) : base(repository)
        {
        }

        protected override ProjectVersionDto MapToDto(ProjectVersion pv)
        {
            return new ProjectVersionDto(pv);
        }

        public override ResultDto<ImmutableList<ProjectVersionDto>> GetAllVersions(params Expression<Func<ProjectVersion, object>>[] includes)
        {
            // Include Project navigation property
            var results = _repository.GetAll(includes);

            var versionDtos = results.Select(MapToDto).ToImmutableList();

            return new ResultDto<ImmutableList<ProjectVersionDto>>()
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
