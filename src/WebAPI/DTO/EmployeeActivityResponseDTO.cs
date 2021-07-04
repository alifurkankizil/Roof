using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.DTO
{
    public class EmployeeActivityResponseDTO
    {
        public ActivityResponseDTO Activity { get; set; }
        public EmployeeResponseDTO Employee { get; set; }
    }
}
