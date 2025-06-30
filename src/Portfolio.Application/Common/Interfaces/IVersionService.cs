using Portfolio.Application.DTOs;
using System.Collections.Immutable;

namespace Portfolio.Application.Common.Interfaces
{
    public interface IVersionService<T> where T : class
    {
        ImmutableList<VersionDto> GetAllVersions();
        VersionDto GetVersionsById(int id);

        void AddNewVersion(int id, VersionCreateDto dto);
        void DeleteVersion(int id, int versionId);
    }
}
