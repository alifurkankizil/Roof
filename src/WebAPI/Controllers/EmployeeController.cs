using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class EmployeeController : ControllerBase
    {
        ApplicationContext Context;
        public EmployeeController(ApplicationContext context)
        {
            Context = context;
        }
     
        [HttpPost]
        public void Create()
        {

        }


        [HttpGet("{id}")]
        public Employee GetById(long id)
        {
            return Context.Employees.FirstOrDefault(x => x.Id == id);
        }

        [HttpGet]
        public List<Employee> GetAll()
        {
            return Context.Employees.ToList();
        }
    }
}
