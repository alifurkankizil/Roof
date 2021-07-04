using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data;
using WebAPI.DTO;
using WebAPI.Models;
using WebAPI.Services.Abstract;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class EmployeeController : ControllerBase , IEmployeeService
    {
        IEmployeeService EmployeeService { get; }
        public EmployeeController(IEmployeeService employeeService)
        {
            EmployeeService = employeeService;
        }
     
        [HttpPost]
        public EmployeeResponseDTO Create(EmployeeCreateDTO createDTO)
        {
            return EmployeeService.Create(createDTO);
        }

        [HttpPut]
        public EmployeeResponseDTO Update(long id, EmployeeUpdateDTO updateDTO)
        {
            return EmployeeService.Update(id, updateDTO);
        }

        [HttpGet("{id}")]
        public EmployeeResponseDTO Get(long id)
        {
            return EmployeeService.Get(id);
        }

        [HttpGet]
        public IList<EmployeeResponseDTO> List()
        {
            return EmployeeService.List();
        }

        [HttpDelete("{id}")]
        public bool Delete(long id)
        {
            return EmployeeService.Delete(id);
        }

    }
}
