using Portfolio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Application.DTOs
{
    public record VersionDto(string name, List<string> versions);
    public record VersionCreateDto(int major, int minor, int patch);
}
