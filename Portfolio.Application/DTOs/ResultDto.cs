using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Application.DTOs
{
    public class ResultDto<T>
    {
        public bool Success { get; set; }
        public required string Message { get; set; }
        public T? Data { get; init; }
    }
}
