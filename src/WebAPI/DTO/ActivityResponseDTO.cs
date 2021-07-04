using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.DTO
{
    public class ActivityResponseDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public EmployeeActivityResponseDTO EmployeeActivity { get; set; }
    }
}
