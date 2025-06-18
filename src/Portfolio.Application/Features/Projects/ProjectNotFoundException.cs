using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Application.Features.Projects
{
    public class ProjectNotFoundException : Exception
    {
        public ProjectNotFoundException(int id) : base($"Project with ID {id} was not found.") 
        {
        }
    }
}
