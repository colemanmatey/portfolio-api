using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Application.Features.Projects
{
    public record ProjectDto(int id, string title, string? description, string? category, string? status);


}