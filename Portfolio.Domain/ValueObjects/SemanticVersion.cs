using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Domain.ValueObjects
{
    public class SemanticVersion
    {
        public int Major { get; set; }
        public int Minor { get; set; }
        public int Patch { get; set; }

        public override string ToString()
        {
            return $"v{Major}.{Minor}.{Patch}";
        }
    }
}
