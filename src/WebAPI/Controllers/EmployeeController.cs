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

     
        /// <summary>
        /// Create employee
        /// </summary>
        /// <param name="createDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public EmployeeResponseDTO Create(EmployeeCreateDTO createDTO)
        {
            return EmployeeService.Create(createDTO);
        }

        /// <summary>
        /// Update employee
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateDTO"></param>
        /// <returns></returns>
        [HttpPut]
        public EmployeeResponseDTO Update(long id, EmployeeUpdateDTO updateDTO)
        {
            return EmployeeService.Update(id, updateDTO);
        }


        /// <summary>
        /// Get employee by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public EmployeeResponseDTO Get(long id)
        {
            return EmployeeService.Get(id);
        }

        /// <summary>
        /// All employee list
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IList<EmployeeResponseDTO> List()
        {
            return EmployeeService.List();
        }

        /// <summary>
        /// Delete employee by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public bool Delete(long id)
        {
            return EmployeeService.Delete(id);
        }


        /// <summary>
        /// Get employee activity by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}/activity")]
        public EmployeeResponseDTO GetEmployeeActivity(long id)
        {
            return EmployeeService.GetEmployeeActivity(id);
        }
    }
}
