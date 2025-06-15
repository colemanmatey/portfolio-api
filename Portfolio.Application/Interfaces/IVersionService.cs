using Portfolio.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Application.Interfaces
{
    public interface IVersionService<T, TDto> where T : class
    {
        ResultDto<ImmutableList<TDto>> GetAllVersions();
        ResultDto<ImmutableList<TDto>> GetAllVersions(params Expression<Func<T, object>>[] includes);
    }
}
