using Portfolio.Application.DTOs;
using System.Collections.Immutable;

namespace Portfolio.Application.Common.Interfaces
{
    public interface IVersionService<T> where T : class
    {
        ImmutableList<VersionDto> GetAllVersions();
        VersionDto GetVersionById(int id);
    }
}
