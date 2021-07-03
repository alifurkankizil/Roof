using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Activity : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<EmployeeActivity> EmployeeActivities { get; set; }
    }
}
