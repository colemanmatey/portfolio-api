using Portfolio.Application.DTOs;
using Portfolio.Application.Interfaces;
using Portfolio.Domain.Entities;
using Portfolio.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Application.Services
{
    public abstract class VersionService<T, TDto> : IVersionService<T, TDto> where T : class
    {
        protected readonly IRepository<T> _repository;

        protected VersionService(IRepository<T> repository) 
        {
            _repository = repository;
        }

        protected abstract TDto MapToDto(T entity);

        public virtual ResultDto<ImmutableList<TDto>> GetAllVersions()
        {
            var results = _repository.GetAll();

            var versionDtos = results.Select(MapToDto).ToImmutableList();

            return new ResultDto<ImmutableList<TDto>>()
            {
                Success = true,
                Message = versionDtos.Any()
                          ? "Versions retrieved successfully."
                          : "No versions found.",
                Data = versionDtos
            };
        }
        public virtual ResultDto<ImmutableList<TDto>> GetAllVersions(params Expression<Func<T, object>>[] includes)
        {
            var results = _repository.GetAll(includes);

            var versionDtos = results.Select(MapToDto).ToImmutableList();

            return new ResultDto<ImmutableList<TDto>>()
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
