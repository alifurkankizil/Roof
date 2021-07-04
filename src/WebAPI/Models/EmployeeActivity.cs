using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class EmployeeActivity
    {
        public long EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public long ActivityId { get; set; }
        public Activity Activity { get; set; }
    }
}
